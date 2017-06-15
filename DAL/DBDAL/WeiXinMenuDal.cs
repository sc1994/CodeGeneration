using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class WeiXinMenuDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.WeiXinMenu WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinMenu WHERE {where};") > 0;

        public int Add(WeiXinMenu model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboWeiXinMenu(");
            strSql.Append("MenuId,MenuName,MenuType,MenuKey,MenuUrl,FID");
            strSql.Append(") VALUES (");
            strSql.Append("@MenuId,@MenuName,@MenuType,@MenuKey,@MenuUrl,@FID);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(WeiXinMenu model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinMenu SET ");
            strSql.Append("MenuName = @MenuName,MenuType = @MenuType,MenuKey = @MenuKey,MenuUrl = @MenuUrl,FID = @FID");
            strSql.Append(" WHERE MenuId = @MenuId");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinMenu SET ");
            strSql.Append("MenuName = @MenuName,MenuType = @MenuType,MenuKey = @MenuKey,MenuUrl = @MenuUrl,FID = @FID");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.WeiXinMenu WHERE MenuId = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.WeiXinMenu WHERE 1 = 1 {where}");

        public WeiXinMenu GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.WeiXinMenu WHERE MenuId = @key";
            return DbClient.Query<WeiXinMenu>(strSql, new { key }).FirstOrDefault();
        }

        public List<WeiXinMenu> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.WeiXinMenu WHERE {where}";
            return DbClient.Query<WeiXinMenu>(strSql).ToList();
        }

        public List<WeiXinMenu> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.WeiXinMenu ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinMenu WHERE {where};");
            return DbClient.Query<WeiXinMenu>(strSql.ToString()).ToList();
        }

    }
}
