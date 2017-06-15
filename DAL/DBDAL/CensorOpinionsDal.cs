using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class CensorOpinionsDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.CensorOpinions WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CensorOpinions WHERE {where};") > 0;

        public int Add(CensorOpinions model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboCensorOpinions(");
            strSql.Append("ExamineID,TaskID,CustomerID,Profession,AssignTime,PlanFinishTime,Designer,MajorRespose,Assessor,Regester,SealNo,CensorOpinions_Field,DisobeyItems,DisobeyStandards,MasterCensor,MCertifieateID,SecondCensor,SCertifieateID,CensorDate,Opinioner,OpinionerDate,TaskAssigner,DrawingNum,IsSignature,MasterCensorDate,SecondCensorDate,CensorOpinionsType");
            strSql.Append(") VALUES (");
            strSql.Append("@ExamineID,@TaskID,@CustomerID,@Profession,@AssignTime,@PlanFinishTime,@Designer,@MajorRespose,@Assessor,@Regester,@SealNo,@CensorOpinions_Field,@DisobeyItems,@DisobeyStandards,@MasterCensor,@MCertifieateID,@SecondCensor,@SCertifieateID,@CensorDate,@Opinioner,@OpinionerDate,@TaskAssigner,@DrawingNum,@IsSignature,@MasterCensorDate,@SecondCensorDate,@CensorOpinionsType);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CensorOpinions model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCensorOpinions SET ");
            strSql.Append("TaskID = @TaskID,CustomerID = @CustomerID,Profession = @Profession,AssignTime = @AssignTime,PlanFinishTime = @PlanFinishTime,Designer = @Designer,MajorRespose = @MajorRespose,Assessor = @Assessor,Regester = @Regester,SealNo = @SealNo,CensorOpinions_Field = @CensorOpinions_Field,DisobeyItems = @DisobeyItems,DisobeyStandards = @DisobeyStandards,MasterCensor = @MasterCensor,MCertifieateID = @MCertifieateID,SecondCensor = @SecondCensor,SCertifieateID = @SCertifieateID,CensorDate = @CensorDate,Opinioner = @Opinioner,OpinionerDate = @OpinionerDate,TaskAssigner = @TaskAssigner,DrawingNum = @DrawingNum,IsSignature = @IsSignature,MasterCensorDate = @MasterCensorDate,SecondCensorDate = @SecondCensorDate,CensorOpinionsType = @CensorOpinionsType");
            strSql.Append(" WHERE ExamineID = @ExamineID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCensorOpinions SET ");
            strSql.Append("TaskID = @TaskID,CustomerID = @CustomerID,Profession = @Profession,AssignTime = @AssignTime,PlanFinishTime = @PlanFinishTime,Designer = @Designer,MajorRespose = @MajorRespose,Assessor = @Assessor,Regester = @Regester,SealNo = @SealNo,CensorOpinions_Field = @CensorOpinions_Field,DisobeyItems = @DisobeyItems,DisobeyStandards = @DisobeyStandards,MasterCensor = @MasterCensor,MCertifieateID = @MCertifieateID,SecondCensor = @SecondCensor,SCertifieateID = @SCertifieateID,CensorDate = @CensorDate,Opinioner = @Opinioner,OpinionerDate = @OpinionerDate,TaskAssigner = @TaskAssigner,DrawingNum = @DrawingNum,IsSignature = @IsSignature,MasterCensorDate = @MasterCensorDate,SecondCensorDate = @SecondCensorDate,CensorOpinionsType = @CensorOpinionsType");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.CensorOpinions WHERE ExamineID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.CensorOpinions WHERE 1 = 1 {where}");

        public CensorOpinions GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.CensorOpinions WHERE ExamineID = @key";
            return DbClient.Query<CensorOpinions>(strSql, new { key }).FirstOrDefault();
        }

        public List<CensorOpinions> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.CensorOpinions WHERE {where}";
            return DbClient.Query<CensorOpinions>(strSql).ToList();
        }

        public List<CensorOpinions> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.CensorOpinions ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CensorOpinions WHERE {where};");
            return DbClient.Query<CensorOpinions>(strSql.ToString()).ToList();
        }

    }
}
