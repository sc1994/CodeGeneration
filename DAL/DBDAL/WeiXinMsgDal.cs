using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class WeiXinMsgDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.WeiXinMsg WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinMsg WHERE {where};") > 0;

        public int Add(WeiXinMsg model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboWeiXinMsg(");
            strSql.Append("MsgType,Keyword,WXMContent,SendTime");
            strSql.Append(") VALUES (");
            strSql.Append("@MsgType,@Keyword,@WXMContent,@SendTime);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(WeiXinMsg model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinMsg SET ");
            strSql.Append("MsgType = @MsgType,Keyword = @Keyword,WXMContent = @WXMContent,SendTime = @SendTime");
            strSql.Append(" WHERE MID = @MID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinMsg SET ");
            strSql.Append("MsgType = @MsgType,Keyword = @Keyword,WXMContent = @WXMContent,SendTime = @SendTime");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.WeiXinMsg WHERE MID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.WeiXinMsg WHERE 1 = 1 {where}");

        public WeiXinMsg GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.WeiXinMsg WHERE MID = @key";
            return DbClient.Query<WeiXinMsg>(strSql, new { key }).FirstOrDefault();
        }

        public List<WeiXinMsg> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.WeiXinMsg WHERE {where}";
            return DbClient.Query<WeiXinMsg>(strSql).ToList();
        }

        public List<WeiXinMsg> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.WeiXinMsg ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinMsg WHERE {where};");
            return DbClient.Query<WeiXinMsg>(strSql.ToString()).ToList();
        }

    }
}
