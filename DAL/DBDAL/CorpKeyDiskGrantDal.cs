using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class CorpKeyDiskGrantDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.CorpKeyDiskGrant WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CorpKeyDiskGrant WHERE {where};") > 0;

        public int Add(CorpKeyDiskGrant model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboCorpKeyDiskGrant(");
            strSql.Append("CorpKeyDiskNumber,CorpKeyDiskName,CorpKeyDiskPassWord,CorpID,CorpName,Remark");
            strSql.Append(") VALUES (");
            strSql.Append("@CorpKeyDiskNumber,@CorpKeyDiskName,@CorpKeyDiskPassWord,@CorpID,@CorpName,@Remark);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CorpKeyDiskGrant model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCorpKeyDiskGrant SET ");
            strSql.Append("CorpKeyDiskNumber = @CorpKeyDiskNumber,CorpKeyDiskName = @CorpKeyDiskName,CorpKeyDiskPassWord = @CorpKeyDiskPassWord,CorpID = @CorpID,CorpName = @CorpName,Remark = @Remark");
            strSql.Append(" WHERE CorpKeyDiskGrantID = @CorpKeyDiskGrantID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCorpKeyDiskGrant SET ");
            strSql.Append("CorpKeyDiskNumber = @CorpKeyDiskNumber,CorpKeyDiskName = @CorpKeyDiskName,CorpKeyDiskPassWord = @CorpKeyDiskPassWord,CorpID = @CorpID,CorpName = @CorpName,Remark = @Remark");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.CorpKeyDiskGrant WHERE CorpKeyDiskGrantID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.CorpKeyDiskGrant WHERE 1 = 1 {where}");

        public CorpKeyDiskGrant GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.CorpKeyDiskGrant WHERE CorpKeyDiskGrantID = @key";
            return DbClient.Query<CorpKeyDiskGrant>(strSql, new { key }).FirstOrDefault();
        }

        public List<CorpKeyDiskGrant> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.CorpKeyDiskGrant WHERE {where}";
            return DbClient.Query<CorpKeyDiskGrant>(strSql).ToList();
        }

        public List<CorpKeyDiskGrant> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.CorpKeyDiskGrant ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CorpKeyDiskGrant WHERE {where};");
            return DbClient.Query<CorpKeyDiskGrant>(strSql.ToString()).ToList();
        }

    }
}
