using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public partial class CensorProblemDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.CensorProblem WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CensorProblem WHERE {where};") > 0;

        public int Add(CensorProblem model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboCensorProblem(");
             strSql.Append("ProblemID,TaskID,TextID,DrawingX,DrawingX2,DrawingY,DrawingY2,Profession,ProblemDescription,ProblemType,ProblemSubMajor,ProblemSetNo,IsHiddenDanger,InputUser,PageAge,DrawingGuId");
             strSql.Append(") VALUES (");
             strSql.Append("@ProblemID,@TaskID,@TextID,@DrawingX,@DrawingX2,@DrawingY,@DrawingY2,@Profession,@ProblemDescription,@ProblemType,@ProblemSubMajor,@ProblemSetNo,@IsHiddenDanger,@InputUser,@PageAge,@DrawingGuId);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CensorProblem model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCensorProblem SET ");
            strSql.Append("TaskID = @TaskID,TextID = @TextID,DrawingX = @DrawingX,DrawingX2 = @DrawingX2,DrawingY = @DrawingY,DrawingY2 = @DrawingY2,Profession = @Profession,ProblemDescription = @ProblemDescription,ProblemType = @ProblemType,ProblemSubMajor = @ProblemSubMajor,ProblemSetNo = @ProblemSetNo,IsHiddenDanger = @IsHiddenDanger,InputUser = @InputUser,PageAge = @PageAge,DrawingGuId = @DrawingGuId");
            strSql.Append(" WHERE ProblemID = @ProblemID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCensorProblem SET ");
            strSql.Append("TaskID = @TaskID,TextID = @TextID,DrawingX = @DrawingX,DrawingX2 = @DrawingX2,DrawingY = @DrawingY,DrawingY2 = @DrawingY2,Profession = @Profession,ProblemDescription = @ProblemDescription,ProblemType = @ProblemType,ProblemSubMajor = @ProblemSubMajor,ProblemSetNo = @ProblemSetNo,IsHiddenDanger = @IsHiddenDanger,InputUser = @InputUser,PageAge = @PageAge,DrawingGuId = @DrawingGuId");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.CensorProblem WHERE ProblemID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.CensorProblem WHERE 1 = 1 {where}");

        public CensorProblem GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.CensorProblem WHERE ProblemID = @key";
            return DbClient.Query<CensorProblem>(strSql, new { key }).FirstOrDefault();
        }

        public List<CensorProblem> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.CensorProblem WHERE {where}";
            return DbClient.Query<CensorProblem>(strSql).ToList();
        }

        public List<CensorProblem> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.CensorProblem ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CensorProblem WHERE {where};");
            return DbClient.Query<CensorProblem>(strSql.ToString()).ToList();
        }

    }
}
