using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class CensorTasksDal
    {
        public bool Exists(string primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.CensorTasks WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CensorTasks WHERE {where};") > 0;

        public string Add(CensorTasks model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboCensorTasks(");
            strSql.Append("TaskID,CustomerID,DisplayProjectName,CardNo,YTTaskID,SJTaskID,Location,ProjectSupType,ProjectSupTypeRemark,ConstructCorp,ContactPerson,ContactPersonTel,SurveyCorp,SurveyCorpGrade,SurveyCorpRegion,DesignCorp,DesignCorpGrade,DesignCorpRegion,AirDefenseDesignCorp,AirDefenseDesignCorpGrade,AirDefenseDesignCorpRegion,DeliverDate,IssueDate,CensorCircs,ApplyState,ApplyExplain,CensorOpinion1,CensorOpinion2,ValidateCode,ConstructionNo,SeismicNo,TaskResponsibleMan,TechResponsibleMan,RevertNote,ReportedState,sbxmid,ReportedID,ReportedTime,TaskApplyer,TaskApprover,ApproveDate,Awarder,WinXinNo,UnAllotProfessionNum,AllotProfessionNum,UnCensorProfessionNum,CensorProfessionNum,DrawingTotalNum,DrawingSubmitDate,TaskAcceptDate,TaskAllotDate,ReplySubmitDate,ReplyCompleteDate,AwardDate,IsUnion,AcceptCustomers,SerialNo,OperateStaus,CensorOpinionDate,DownLoadDate");
            strSql.Append(") VALUES (");
            strSql.Append("@TaskID,@CustomerID,@DisplayProjectName,@CardNo,@YTTaskID,@SJTaskID,@Location,@ProjectSupType,@ProjectSupTypeRemark,@ConstructCorp,@ContactPerson,@ContactPersonTel,@SurveyCorp,@SurveyCorpGrade,@SurveyCorpRegion,@DesignCorp,@DesignCorpGrade,@DesignCorpRegion,@AirDefenseDesignCorp,@AirDefenseDesignCorpGrade,@AirDefenseDesignCorpRegion,@DeliverDate,@IssueDate,@CensorCircs,@ApplyState,@ApplyExplain,@CensorOpinion1,@CensorOpinion2,@ValidateCode,@ConstructionNo,@SeismicNo,@TaskResponsibleMan,@TechResponsibleMan,@RevertNote,@ReportedState,@sbxmid,@ReportedID,@ReportedTime,@TaskApplyer,@TaskApprover,@ApproveDate,@Awarder,@WinXinNo,@UnAllotProfessionNum,@AllotProfessionNum,@UnCensorProfessionNum,@CensorProfessionNum,@DrawingTotalNum,@DrawingSubmitDate,@TaskAcceptDate,@TaskAllotDate,@ReplySubmitDate,@ReplyCompleteDate,@AwardDate,@IsUnion,@AcceptCustomers,@SerialNo,@OperateStaus,@CensorOpinionDate,@DownLoadDate);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<string>(strSql.ToString(), model);
        }

        public bool Update(CensorTasks model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCensorTasks SET ");
            strSql.Append("CustomerID = @CustomerID,DisplayProjectName = @DisplayProjectName,CardNo = @CardNo,YTTaskID = @YTTaskID,SJTaskID = @SJTaskID,Location = @Location,ProjectSupType = @ProjectSupType,ProjectSupTypeRemark = @ProjectSupTypeRemark,ConstructCorp = @ConstructCorp,ContactPerson = @ContactPerson,ContactPersonTel = @ContactPersonTel,SurveyCorp = @SurveyCorp,SurveyCorpGrade = @SurveyCorpGrade,SurveyCorpRegion = @SurveyCorpRegion,DesignCorp = @DesignCorp,DesignCorpGrade = @DesignCorpGrade,DesignCorpRegion = @DesignCorpRegion,AirDefenseDesignCorp = @AirDefenseDesignCorp,AirDefenseDesignCorpGrade = @AirDefenseDesignCorpGrade,AirDefenseDesignCorpRegion = @AirDefenseDesignCorpRegion,DeliverDate = @DeliverDate,IssueDate = @IssueDate,CensorCircs = @CensorCircs,ApplyState = @ApplyState,ApplyExplain = @ApplyExplain,CensorOpinion1 = @CensorOpinion1,CensorOpinion2 = @CensorOpinion2,ValidateCode = @ValidateCode,ConstructionNo = @ConstructionNo,SeismicNo = @SeismicNo,TaskResponsibleMan = @TaskResponsibleMan,TechResponsibleMan = @TechResponsibleMan,RevertNote = @RevertNote,ReportedState = @ReportedState,sbxmid = @sbxmid,ReportedID = @ReportedID,ReportedTime = @ReportedTime,TaskApplyer = @TaskApplyer,TaskApprover = @TaskApprover,ApproveDate = @ApproveDate,Awarder = @Awarder,WinXinNo = @WinXinNo,UnAllotProfessionNum = @UnAllotProfessionNum,AllotProfessionNum = @AllotProfessionNum,UnCensorProfessionNum = @UnCensorProfessionNum,CensorProfessionNum = @CensorProfessionNum,DrawingTotalNum = @DrawingTotalNum,DrawingSubmitDate = @DrawingSubmitDate,TaskAcceptDate = @TaskAcceptDate,TaskAllotDate = @TaskAllotDate,ReplySubmitDate = @ReplySubmitDate,ReplyCompleteDate = @ReplyCompleteDate,AwardDate = @AwardDate,IsUnion = @IsUnion,AcceptCustomers = @AcceptCustomers,SerialNo = @SerialNo,OperateStaus = @OperateStaus,CensorOpinionDate = @CensorOpinionDate,DownLoadDate = @DownLoadDate");
            strSql.Append(" WHERE TaskID = @TaskID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCensorTasks SET ");
            strSql.Append("CustomerID = @CustomerID,DisplayProjectName = @DisplayProjectName,CardNo = @CardNo,YTTaskID = @YTTaskID,SJTaskID = @SJTaskID,Location = @Location,ProjectSupType = @ProjectSupType,ProjectSupTypeRemark = @ProjectSupTypeRemark,ConstructCorp = @ConstructCorp,ContactPerson = @ContactPerson,ContactPersonTel = @ContactPersonTel,SurveyCorp = @SurveyCorp,SurveyCorpGrade = @SurveyCorpGrade,SurveyCorpRegion = @SurveyCorpRegion,DesignCorp = @DesignCorp,DesignCorpGrade = @DesignCorpGrade,DesignCorpRegion = @DesignCorpRegion,AirDefenseDesignCorp = @AirDefenseDesignCorp,AirDefenseDesignCorpGrade = @AirDefenseDesignCorpGrade,AirDefenseDesignCorpRegion = @AirDefenseDesignCorpRegion,DeliverDate = @DeliverDate,IssueDate = @IssueDate,CensorCircs = @CensorCircs,ApplyState = @ApplyState,ApplyExplain = @ApplyExplain,CensorOpinion1 = @CensorOpinion1,CensorOpinion2 = @CensorOpinion2,ValidateCode = @ValidateCode,ConstructionNo = @ConstructionNo,SeismicNo = @SeismicNo,TaskResponsibleMan = @TaskResponsibleMan,TechResponsibleMan = @TechResponsibleMan,RevertNote = @RevertNote,ReportedState = @ReportedState,sbxmid = @sbxmid,ReportedID = @ReportedID,ReportedTime = @ReportedTime,TaskApplyer = @TaskApplyer,TaskApprover = @TaskApprover,ApproveDate = @ApproveDate,Awarder = @Awarder,WinXinNo = @WinXinNo,UnAllotProfessionNum = @UnAllotProfessionNum,AllotProfessionNum = @AllotProfessionNum,UnCensorProfessionNum = @UnCensorProfessionNum,CensorProfessionNum = @CensorProfessionNum,DrawingTotalNum = @DrawingTotalNum,DrawingSubmitDate = @DrawingSubmitDate,TaskAcceptDate = @TaskAcceptDate,TaskAllotDate = @TaskAllotDate,ReplySubmitDate = @ReplySubmitDate,ReplyCompleteDate = @ReplyCompleteDate,AwardDate = @AwardDate,IsUnion = @IsUnion,AcceptCustomers = @AcceptCustomers,SerialNo = @SerialNo,OperateStaus = @OperateStaus,CensorOpinionDate = @CensorOpinionDate,DownLoadDate = @DownLoadDate");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(string key)
        {
            var strSql = "DELETE FROM DJES.dbo.CensorTasks WHERE TaskID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.CensorTasks WHERE 1 = 1 {where}");

        public CensorTasks GetModel(string key)
        {
            var strSql = "SELECT * FROM DJES.dbo.CensorTasks WHERE TaskID = @key";
            return DbClient.Query<CensorTasks>(strSql, new { key }).FirstOrDefault();
        }

        public List<CensorTasks> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.CensorTasks WHERE {where}";
            return DbClient.Query<CensorTasks>(strSql).ToList();
        }

        public List<CensorTasks> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.CensorTasks ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CensorTasks WHERE {where};");
            return DbClient.Query<CensorTasks>(strSql.ToString()).ToList();
        }

    }
}
