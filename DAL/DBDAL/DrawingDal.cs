using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class DrawingDal
    {
        public bool Exists(string primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.Drawing WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.Drawing WHERE {where};") > 0;

        public string Add(Drawing model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboDrawing(");
             strSql.Append("DrawingID,RowGuid,DrawingNumber,DrawingEdition,DrawingName,DrawingSize,DrawingSpace,DrawingDesigner,DrawingUploadTime,DrawingSubmitTime,DrawingSignatureTime,DrawingSignatureStatus,CheckTime,CheckSignatureStatus,AllottedTime,ReviewTime,ReviewSignatureStatus,ReviewStatus,TaskID,ProjectID,ProjectSupType,Profession,ProfessionValue,DCID,DrawingClassifyName,DrawingStatus,BlueprintType,BlueprintSize,BlueprintPath,SignatureBlueprintPath,BlueprintDescription,IsSignature,AttachmentTypeID");
             strSql.Append(") VALUES (");
             strSql.Append("@DrawingID,@RowGuid,@DrawingNumber,@DrawingEdition,@DrawingName,@DrawingSize,@DrawingSpace,@DrawingDesigner,@DrawingUploadTime,@DrawingSubmitTime,@DrawingSignatureTime,@DrawingSignatureStatus,@CheckTime,@CheckSignatureStatus,@AllottedTime,@ReviewTime,@ReviewSignatureStatus,@ReviewStatus,@TaskID,@ProjectID,@ProjectSupType,@Profession,@ProfessionValue,@DCID,@DrawingClassifyName,@DrawingStatus,@BlueprintType,@BlueprintSize,@BlueprintPath,@SignatureBlueprintPath,@BlueprintDescription,@IsSignature,@AttachmentTypeID);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<string>(strSql.ToString(), model);
        }

        public bool Update(Drawing model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDrawing SET ");
            strSql.Append("DrawingNumber = @DrawingNumber,DrawingEdition = @DrawingEdition,DrawingName = @DrawingName,DrawingSize = @DrawingSize,DrawingSpace = @DrawingSpace,DrawingDesigner = @DrawingDesigner,DrawingUploadTime = @DrawingUploadTime,DrawingSubmitTime = @DrawingSubmitTime,DrawingSignatureTime = @DrawingSignatureTime,DrawingSignatureStatus = @DrawingSignatureStatus,CheckTime = @CheckTime,CheckSignatureStatus = @CheckSignatureStatus,AllottedTime = @AllottedTime,ReviewTime = @ReviewTime,ReviewSignatureStatus = @ReviewSignatureStatus,ReviewStatus = @ReviewStatus,TaskID = @TaskID,ProjectID = @ProjectID,ProjectSupType = @ProjectSupType,Profession = @Profession,ProfessionValue = @ProfessionValue,DCID = @DCID,DrawingClassifyName = @DrawingClassifyName,DrawingStatus = @DrawingStatus,BlueprintType = @BlueprintType,BlueprintSize = @BlueprintSize,BlueprintPath = @BlueprintPath,SignatureBlueprintPath = @SignatureBlueprintPath,BlueprintDescription = @BlueprintDescription,IsSignature = @IsSignature,AttachmentTypeID = @AttachmentTypeID");
            strSql.Append(" WHERE RowGuid = @RowGuid");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDrawing SET ");
            strSql.Append("DrawingNumber = @DrawingNumber,DrawingEdition = @DrawingEdition,DrawingName = @DrawingName,DrawingSize = @DrawingSize,DrawingSpace = @DrawingSpace,DrawingDesigner = @DrawingDesigner,DrawingUploadTime = @DrawingUploadTime,DrawingSubmitTime = @DrawingSubmitTime,DrawingSignatureTime = @DrawingSignatureTime,DrawingSignatureStatus = @DrawingSignatureStatus,CheckTime = @CheckTime,CheckSignatureStatus = @CheckSignatureStatus,AllottedTime = @AllottedTime,ReviewTime = @ReviewTime,ReviewSignatureStatus = @ReviewSignatureStatus,ReviewStatus = @ReviewStatus,TaskID = @TaskID,ProjectID = @ProjectID,ProjectSupType = @ProjectSupType,Profession = @Profession,ProfessionValue = @ProfessionValue,DCID = @DCID,DrawingClassifyName = @DrawingClassifyName,DrawingStatus = @DrawingStatus,BlueprintType = @BlueprintType,BlueprintSize = @BlueprintSize,BlueprintPath = @BlueprintPath,SignatureBlueprintPath = @SignatureBlueprintPath,BlueprintDescription = @BlueprintDescription,IsSignature = @IsSignature,AttachmentTypeID = @AttachmentTypeID");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(string key)
        {
            var strSql = "DELETE FROM DJES.dbo.Drawing WHERE RowGuid = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.Drawing WHERE 1 = 1 {where}");

        public Drawing GetModel(string key)
        {
            var strSql = "SELECT * FROM DJES.dbo.Drawing WHERE RowGuid = @key";
            return DbClient.Query<Drawing>(strSql, new { key }).FirstOrDefault();
        }

        public List<Drawing> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.Drawing WHERE {where}";
            return DbClient.Query<Drawing>(strSql).ToList();
        }

        public List<Drawing> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.Drawing ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.Drawing WHERE {where};");
            return DbClient.Query<Drawing>(strSql.ToString()).ToList();
        }

    }
}
