using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class TaskCertificateDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.TaskCertificate WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.TaskCertificate WHERE {where};") > 0;

        public int Add(TaskCertificate model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboTaskCertificate(");
            strSql.Append("TaskID,ConstructCorp,SurveyCorp,DesignCorp,ProjectIDs,ProjectName,ProjectLocation,ProjectType,ProjectLevel,FieldType,AseismaGrouptic,AseismaticLevel,AseismaticType,Structure,HighFloors,Foundation,Areas,CensorRange,CensorDateDate,ConstructionNo,SeismicNo,CertificateNote,AwardDate,Awarder");
            strSql.Append(") VALUES (");
            strSql.Append("@TaskID,@ConstructCorp,@SurveyCorp,@DesignCorp,@ProjectIDs,@ProjectName,@ProjectLocation,@ProjectType,@ProjectLevel,@FieldType,@AseismaGrouptic,@AseismaticLevel,@AseismaticType,@Structure,@HighFloors,@Foundation,@Areas,@CensorRange,@CensorDateDate,@ConstructionNo,@SeismicNo,@CertificateNote,@AwardDate,@Awarder);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(TaskCertificate model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboTaskCertificate SET ");
            strSql.Append("TaskID = @TaskID,ConstructCorp = @ConstructCorp,SurveyCorp = @SurveyCorp,DesignCorp = @DesignCorp,ProjectIDs = @ProjectIDs,ProjectName = @ProjectName,ProjectLocation = @ProjectLocation,ProjectType = @ProjectType,ProjectLevel = @ProjectLevel,FieldType = @FieldType,AseismaGrouptic = @AseismaGrouptic,AseismaticLevel = @AseismaticLevel,AseismaticType = @AseismaticType,Structure = @Structure,HighFloors = @HighFloors,Foundation = @Foundation,Areas = @Areas,CensorRange = @CensorRange,CensorDateDate = @CensorDateDate,ConstructionNo = @ConstructionNo,SeismicNo = @SeismicNo,CertificateNote = @CertificateNote,AwardDate = @AwardDate,Awarder = @Awarder");
            strSql.Append(" WHERE CID = @CID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboTaskCertificate SET ");
            strSql.Append("TaskID = @TaskID,ConstructCorp = @ConstructCorp,SurveyCorp = @SurveyCorp,DesignCorp = @DesignCorp,ProjectIDs = @ProjectIDs,ProjectName = @ProjectName,ProjectLocation = @ProjectLocation,ProjectType = @ProjectType,ProjectLevel = @ProjectLevel,FieldType = @FieldType,AseismaGrouptic = @AseismaGrouptic,AseismaticLevel = @AseismaticLevel,AseismaticType = @AseismaticType,Structure = @Structure,HighFloors = @HighFloors,Foundation = @Foundation,Areas = @Areas,CensorRange = @CensorRange,CensorDateDate = @CensorDateDate,ConstructionNo = @ConstructionNo,SeismicNo = @SeismicNo,CertificateNote = @CertificateNote,AwardDate = @AwardDate,Awarder = @Awarder");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.TaskCertificate WHERE CID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.TaskCertificate WHERE 1 = 1 {where}");

        public TaskCertificate GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.TaskCertificate WHERE CID = @key";
            return DbClient.Query<TaskCertificate>(strSql, new { key }).FirstOrDefault();
        }

        public List<TaskCertificate> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.TaskCertificate WHERE {where}";
            return DbClient.Query<TaskCertificate>(strSql).ToList();
        }

        public List<TaskCertificate> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.TaskCertificate ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.TaskCertificate WHERE {where};");
            return DbClient.Query<TaskCertificate>(strSql.ToString()).ToList();
        }

    }
}
