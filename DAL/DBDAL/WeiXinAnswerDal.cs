using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class WeiXinAnswerDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.WeiXinAnswer WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinAnswer WHERE {where};") > 0;

        public int Add(WeiXinAnswer model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboWeiXinAnswer(");
            strSql.Append("WeiXinNo,IDNumber,Name,Phone,SelectAnswer,JudgmentAnswer,Score,AnswerTime");
            strSql.Append(") VALUES (");
            strSql.Append("@WeiXinNo,@IDNumber,@Name,@Phone,@SelectAnswer,@JudgmentAnswer,@Score,@AnswerTime);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(WeiXinAnswer model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinAnswer SET ");
            strSql.Append("WeiXinNo = @WeiXinNo,IDNumber = @IDNumber,Name = @Name,Phone = @Phone,SelectAnswer = @SelectAnswer,JudgmentAnswer = @JudgmentAnswer,Score = @Score,AnswerTime = @AnswerTime");
            strSql.Append(" WHERE ID = @ID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinAnswer SET ");
            strSql.Append("WeiXinNo = @WeiXinNo,IDNumber = @IDNumber,Name = @Name,Phone = @Phone,SelectAnswer = @SelectAnswer,JudgmentAnswer = @JudgmentAnswer,Score = @Score,AnswerTime = @AnswerTime");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.WeiXinAnswer WHERE ID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.WeiXinAnswer WHERE 1 = 1 {where}");

        public WeiXinAnswer GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.WeiXinAnswer WHERE ID = @key";
            return DbClient.Query<WeiXinAnswer>(strSql, new { key }).FirstOrDefault();
        }

        public List<WeiXinAnswer> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.WeiXinAnswer WHERE {where}";
            return DbClient.Query<WeiXinAnswer>(strSql).ToList();
        }

        public List<WeiXinAnswer> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.WeiXinAnswer ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinAnswer WHERE {where};");
            return DbClient.Query<WeiXinAnswer>(strSql.ToString()).ToList();
        }

    }
}
