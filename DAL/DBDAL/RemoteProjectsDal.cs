using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class RemoteProjectsDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.RemoteProjects WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RemoteProjects WHERE {where};") > 0;

        public int Add(RemoteProjects model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboRemoteProjects(");
            strSql.Append("YCTaskID,ProjectSubType,ProjectName,SurveyReportID,SurveyReportName,Areas,Floors,High,Investment,Sffz,PartFloors,UndergroundFloors,AtticFloors,PartHigh,CraneTonnage,ProjectLevel,AseismaticType,Structure,AseismaticLevel,WallMaterials,FieldType,Foundation,FireproofLevel,UnderFireproofLevel,RoofWaterproofLevel,UnderWaterproofLevel,DefendLevel,PlantSpan,AccountReceivable,Demo,FormulaContent,ChargeAmount,ISPreferentia,FormulaName,MinChargeAmount,DrawingNum,Lng,Lat");
            strSql.Append(") VALUES (");
            strSql.Append("@YCTaskID,@ProjectSubType,@ProjectName,@SurveyReportID,@SurveyReportName,@Areas,@Floors,@High,@Investment,@Sffz,@PartFloors,@UndergroundFloors,@AtticFloors,@PartHigh,@CraneTonnage,@ProjectLevel,@AseismaticType,@Structure,@AseismaticLevel,@WallMaterials,@FieldType,@Foundation,@FireproofLevel,@UnderFireproofLevel,@RoofWaterproofLevel,@UnderWaterproofLevel,@DefendLevel,@PlantSpan,@AccountReceivable,@Demo,@FormulaContent,@ChargeAmount,@ISPreferentia,@FormulaName,@MinChargeAmount,@DrawingNum,@Lng,@Lat);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(RemoteProjects model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRemoteProjects SET ");
            strSql.Append("YCTaskID = @YCTaskID,ProjectSubType = @ProjectSubType,ProjectName = @ProjectName,SurveyReportID = @SurveyReportID,SurveyReportName = @SurveyReportName,Areas = @Areas,Floors = @Floors,High = @High,Investment = @Investment,Sffz = @Sffz,PartFloors = @PartFloors,UndergroundFloors = @UndergroundFloors,AtticFloors = @AtticFloors,PartHigh = @PartHigh,CraneTonnage = @CraneTonnage,ProjectLevel = @ProjectLevel,AseismaticType = @AseismaticType,Structure = @Structure,AseismaticLevel = @AseismaticLevel,WallMaterials = @WallMaterials,FieldType = @FieldType,Foundation = @Foundation,FireproofLevel = @FireproofLevel,UnderFireproofLevel = @UnderFireproofLevel,RoofWaterproofLevel = @RoofWaterproofLevel,UnderWaterproofLevel = @UnderWaterproofLevel,DefendLevel = @DefendLevel,PlantSpan = @PlantSpan,AccountReceivable = @AccountReceivable,Demo = @Demo,FormulaContent = @FormulaContent,ChargeAmount = @ChargeAmount,ISPreferentia = @ISPreferentia,FormulaName = @FormulaName,MinChargeAmount = @MinChargeAmount,DrawingNum = @DrawingNum,Lng = @Lng,Lat = @Lat");
            strSql.Append(" WHERE ProjectID = @ProjectID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRemoteProjects SET ");
            strSql.Append("YCTaskID = @YCTaskID,ProjectSubType = @ProjectSubType,ProjectName = @ProjectName,SurveyReportID = @SurveyReportID,SurveyReportName = @SurveyReportName,Areas = @Areas,Floors = @Floors,High = @High,Investment = @Investment,Sffz = @Sffz,PartFloors = @PartFloors,UndergroundFloors = @UndergroundFloors,AtticFloors = @AtticFloors,PartHigh = @PartHigh,CraneTonnage = @CraneTonnage,ProjectLevel = @ProjectLevel,AseismaticType = @AseismaticType,Structure = @Structure,AseismaticLevel = @AseismaticLevel,WallMaterials = @WallMaterials,FieldType = @FieldType,Foundation = @Foundation,FireproofLevel = @FireproofLevel,UnderFireproofLevel = @UnderFireproofLevel,RoofWaterproofLevel = @RoofWaterproofLevel,UnderWaterproofLevel = @UnderWaterproofLevel,DefendLevel = @DefendLevel,PlantSpan = @PlantSpan,AccountReceivable = @AccountReceivable,Demo = @Demo,FormulaContent = @FormulaContent,ChargeAmount = @ChargeAmount,ISPreferentia = @ISPreferentia,FormulaName = @FormulaName,MinChargeAmount = @MinChargeAmount,DrawingNum = @DrawingNum,Lng = @Lng,Lat = @Lat");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.RemoteProjects WHERE ProjectID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.RemoteProjects WHERE 1 = 1 {where}");

        public RemoteProjects GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.RemoteProjects WHERE ProjectID = @key";
            return DbClient.Query<RemoteProjects>(strSql, new { key }).FirstOrDefault();
        }

        public List<RemoteProjects> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.RemoteProjects WHERE {where}";
            return DbClient.Query<RemoteProjects>(strSql).ToList();
        }

        public List<RemoteProjects> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.RemoteProjects ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RemoteProjects WHERE {where};");
            return DbClient.Query<RemoteProjects>(strSql.ToString()).ToList();
        }

    }
}