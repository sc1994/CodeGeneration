using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ReCensorProblemDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ReCensorProblem WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ReCensorProblem WHERE {where};") > 0;

        public int Add(ReCensorProblem model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboReCensorProblem(");
             strSql.Append("ReProblemID,ReExamineID,TaskID,ProjectID,Profession,ReProblemDescription,ReProblemType,ReProblemSubMajor,ReProblemSetNo,InputUser");
             strSql.Append(") VALUES (");
             strSql.Append("@ReProblemID,@ReExamineID,@TaskID,@ProjectID,@Profession,@ReProblemDescription,@ReProblemType,@ReProblemSubMajor,@ReProblemSetNo,@InputUser);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ReCensorProblem model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboReCensorProblem SET ");
            strSql.Append("ReExamineID = @ReExamineID,TaskID = @TaskID,ProjectID = @ProjectID,Profession = @Profession,ReProblemDescription = @ReProblemDescription,ReProblemType = @ReProblemType,ReProblemSubMajor = @ReProblemSubMajor,ReProblemSetNo = @ReProblemSetNo,InputUser = @InputUser");
            strSql.Append(" WHERE ReProblemID = @ReProblemID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboReCensorProblem SET ");
            strSql.Append("ReExamineID = @ReExamineID,TaskID = @TaskID,ProjectID = @ProjectID,Profession = @Profession,ReProblemDescription = @ReProblemDescription,ReProblemType = @ReProblemType,ReProblemSubMajor = @ReProblemSubMajor,ReProblemSetNo = @ReProblemSetNo,InputUser = @InputUser");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ReCensorProblem WHERE ReProblemID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ReCensorProblem WHERE 1 = 1 {where}");

        public ReCensorProblem GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ReCensorProblem WHERE ReProblemID = @key";
            return DbClient.Query<ReCensorProblem>(strSql, new { key }).FirstOrDefault();
        }

        public List<ReCensorProblem> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ReCensorProblem WHERE {where}";
            return DbClient.Query<ReCensorProblem>(strSql).ToList();
        }

        public List<ReCensorProblem> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ReCensorProblem ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ReCensorProblem WHERE {where};");
            return DbClient.Query<ReCensorProblem>(strSql.ToString()).ToList();
        }

    }
}
