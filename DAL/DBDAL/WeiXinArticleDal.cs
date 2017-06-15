using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class WeiXinArticleDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.WeiXinArticle WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinArticle WHERE {where};") > 0;

        public int Add(WeiXinArticle model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboWeiXinArticle(");
            strSql.Append("AID,Title,Description,Image,Url,WXContent,AddTime");
            strSql.Append(") VALUES (");
            strSql.Append("@AID,@Title,@Description,@Image,@Url,@WXContent,@AddTime);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(WeiXinArticle model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinArticle SET ");
            strSql.Append("Title = @Title,Description = @Description,Image = @Image,Url = @Url,WXContent = @WXContent,AddTime = @AddTime");
            strSql.Append(" WHERE AID = @AID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinArticle SET ");
            strSql.Append("Title = @Title,Description = @Description,Image = @Image,Url = @Url,WXContent = @WXContent,AddTime = @AddTime");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.WeiXinArticle WHERE AID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.WeiXinArticle WHERE 1 = 1 {where}");

        public WeiXinArticle GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.WeiXinArticle WHERE AID = @key";
            return DbClient.Query<WeiXinArticle>(strSql, new { key }).FirstOrDefault();
        }

        public List<WeiXinArticle> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.WeiXinArticle WHERE {where}";
            return DbClient.Query<WeiXinArticle>(strSql).ToList();
        }

        public List<WeiXinArticle> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.WeiXinArticle ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinArticle WHERE {where};");
            return DbClient.Query<WeiXinArticle>(strSql.ToString()).ToList();
        }

    }
}
