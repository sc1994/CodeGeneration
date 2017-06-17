using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class RemoteTaskArchivesAttachmentDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.RemoteTaskArchivesAttachment WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RemoteTaskArchivesAttachment WHERE {where};") > 0;

        public int Add(RemoteTaskArchivesAttachment model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboRemoteTaskArchivesAttachment(");
            strSql.Append("RowGuid,ArchiveID,ArchiveName,YCTaskID,AttachmentName,AttachmentPath,OriginalName");
            strSql.Append(") VALUES (");
            strSql.Append("@RowGuid,@ArchiveID,@ArchiveName,@YCTaskID,@AttachmentName,@AttachmentPath,@OriginalName);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(RemoteTaskArchivesAttachment model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRemoteTaskArchivesAttachment SET ");
            strSql.Append("RowGuid = @RowGuid,ArchiveID = @ArchiveID,ArchiveName = @ArchiveName,YCTaskID = @YCTaskID,AttachmentName = @AttachmentName,AttachmentPath = @AttachmentPath,OriginalName = @OriginalName");
            strSql.Append(" WHERE AttachmentID = @AttachmentID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRemoteTaskArchivesAttachment SET ");
            strSql.Append("RowGuid = @RowGuid,ArchiveID = @ArchiveID,ArchiveName = @ArchiveName,YCTaskID = @YCTaskID,AttachmentName = @AttachmentName,AttachmentPath = @AttachmentPath,OriginalName = @OriginalName");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.RemoteTaskArchivesAttachment WHERE AttachmentID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.RemoteTaskArchivesAttachment WHERE 1 = 1 {where}");

        public RemoteTaskArchivesAttachment GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.RemoteTaskArchivesAttachment WHERE AttachmentID = @key";
            return DbClient.Query<RemoteTaskArchivesAttachment>(strSql, new { key }).FirstOrDefault();
        }

        public List<RemoteTaskArchivesAttachment> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.RemoteTaskArchivesAttachment WHERE {where}";
            return DbClient.Query<RemoteTaskArchivesAttachment>(strSql).ToList();
        }

        public List<RemoteTaskArchivesAttachment> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.RemoteTaskArchivesAttachment ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RemoteTaskArchivesAttachment WHERE {where};");
            return DbClient.Query<RemoteTaskArchivesAttachment>(strSql.ToString()).ToList();
        }

    }
}
