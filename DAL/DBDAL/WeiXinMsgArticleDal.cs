using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class WeiXinMsgArticleDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.WeiXinMsgArticle WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinMsgArticle WHERE {where};") > 0;

        public int Add(WeiXinMsgArticle model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboWeiXinMsgArticle(");
            strSql.Append("MID,AID");
            strSql.Append(") VALUES (");
            strSql.Append("@MID,@AID);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(WeiXinMsgArticle model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinMsgArticle SET ");
            strSql.Append("MID = @MID,AID = @AID");
            strSql.Append(" WHERE MAID = @MAID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinMsgArticle SET ");
            strSql.Append("MID = @MID,AID = @AID");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.WeiXinMsgArticle WHERE MAID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.WeiXinMsgArticle WHERE 1 = 1 {where}");

        public WeiXinMsgArticle GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.WeiXinMsgArticle WHERE MAID = @key";
            return DbClient.Query<WeiXinMsgArticle>(strSql, new { key }).FirstOrDefault();
        }

        public List<WeiXinMsgArticle> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.WeiXinMsgArticle WHERE {where}";
            return DbClient.Query<WeiXinMsgArticle>(strSql).ToList();
        }

        public List<WeiXinMsgArticle> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.WeiXinMsgArticle ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinMsgArticle WHERE {where};");
            return DbClient.Query<WeiXinMsgArticle>(strSql.ToString()).ToList();
        }

    }
}
