using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class WeiXinJudgmentDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.WeiXinJudgment WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinJudgment WHERE {where};") > 0;

        public int Add(WeiXinJudgment model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboWeiXinJudgment(");
            strSql.Append("Subject,Answer");
            strSql.Append(") VALUES (");
            strSql.Append("@Subject,@Answer);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(WeiXinJudgment model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinJudgment SET ");
            strSql.Append("Subject = @Subject,Answer = @Answer");
            strSql.Append(" WHERE ID = @ID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinJudgment SET ");
            strSql.Append("Subject = @Subject,Answer = @Answer");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.WeiXinJudgment WHERE ID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.WeiXinJudgment WHERE 1 = 1 {where}");

        public WeiXinJudgment GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.WeiXinJudgment WHERE ID = @key";
            return DbClient.Query<WeiXinJudgment>(strSql, new { key }).FirstOrDefault();
        }

        public List<WeiXinJudgment> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.WeiXinJudgment WHERE {where}";
            return DbClient.Query<WeiXinJudgment>(strSql).ToList();
        }

        public List<WeiXinJudgment> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.WeiXinJudgment ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinJudgment WHERE {where};");
            return DbClient.Query<WeiXinJudgment>(strSql.ToString()).ToList();
        }

    }
}
