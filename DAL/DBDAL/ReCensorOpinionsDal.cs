using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class ReCensorOpinionsDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ReCensorOpinions WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ReCensorOpinions WHERE {where};") > 0;

        public int Add(ReCensorOpinions model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboReCensorOpinions(");
            strSql.Append("ReExamineID,TaskID,Profession,ReviewDate,ReAssignTime,RePlanFinishTime,MasterCensor,ReCensorDate,ReAttachment,ReState,ReCensorNum,ReCensorChangeNum,TaskResponsibleMan,TaskResponsibleCensorDate");
            strSql.Append(") VALUES (");
            strSql.Append("@ReExamineID,@TaskID,@Profession,@ReviewDate,@ReAssignTime,@RePlanFinishTime,@MasterCensor,@ReCensorDate,@ReAttachment,@ReState,@ReCensorNum,@ReCensorChangeNum,@TaskResponsibleMan,@TaskResponsibleCensorDate);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ReCensorOpinions model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboReCensorOpinions SET ");
            strSql.Append("TaskID = @TaskID,Profession = @Profession,ReviewDate = @ReviewDate,ReAssignTime = @ReAssignTime,RePlanFinishTime = @RePlanFinishTime,MasterCensor = @MasterCensor,ReCensorDate = @ReCensorDate,ReAttachment = @ReAttachment,ReState = @ReState,ReCensorNum = @ReCensorNum,ReCensorChangeNum = @ReCensorChangeNum,TaskResponsibleMan = @TaskResponsibleMan,TaskResponsibleCensorDate = @TaskResponsibleCensorDate");
            strSql.Append(" WHERE ReExamineID = @ReExamineID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboReCensorOpinions SET ");
            strSql.Append("TaskID = @TaskID,Profession = @Profession,ReviewDate = @ReviewDate,ReAssignTime = @ReAssignTime,RePlanFinishTime = @RePlanFinishTime,MasterCensor = @MasterCensor,ReCensorDate = @ReCensorDate,ReAttachment = @ReAttachment,ReState = @ReState,ReCensorNum = @ReCensorNum,ReCensorChangeNum = @ReCensorChangeNum,TaskResponsibleMan = @TaskResponsibleMan,TaskResponsibleCensorDate = @TaskResponsibleCensorDate");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ReCensorOpinions WHERE ReExamineID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ReCensorOpinions WHERE 1 = 1 {where}");

        public ReCensorOpinions GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ReCensorOpinions WHERE ReExamineID = @key";
            return DbClient.Query<ReCensorOpinions>(strSql, new { key }).FirstOrDefault();
        }

        public List<ReCensorOpinions> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ReCensorOpinions WHERE {where}";
            return DbClient.Query<ReCensorOpinions>(strSql).ToList();
        }

        public List<ReCensorOpinions> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ReCensorOpinions ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ReCensorOpinions WHERE {where};");
            return DbClient.Query<ReCensorOpinions>(strSql.ToString()).ToList();
        }

    }
}
