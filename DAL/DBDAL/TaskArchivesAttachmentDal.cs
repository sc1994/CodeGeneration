using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class TaskArchivesAttachmentDal
    {
        public bool Exists(string primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.TaskArchivesAttachment WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.TaskArchivesAttachment WHERE {where};") > 0;

        public string Add(TaskArchivesAttachment model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboTaskArchivesAttachment(");
             strSql.Append("AttachmentID,RowGuid,ArchiveID,ArchiveName,TaskID,AttachmentName,AttachmentPath,OriginalName");
             strSql.Append(") VALUES (");
             strSql.Append("@AttachmentID,@RowGuid,@ArchiveID,@ArchiveName,@TaskID,@AttachmentName,@AttachmentPath,@OriginalName);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<string>(strSql.ToString(), model);
        }

        public bool Update(TaskArchivesAttachment model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboTaskArchivesAttachment SET ");
            strSql.Append("ArchiveID = @ArchiveID,ArchiveName = @ArchiveName,TaskID = @TaskID,AttachmentName = @AttachmentName,AttachmentPath = @AttachmentPath,OriginalName = @OriginalName");
            strSql.Append(" WHERE RowGuid = @RowGuid");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboTaskArchivesAttachment SET ");
            strSql.Append("ArchiveID = @ArchiveID,ArchiveName = @ArchiveName,TaskID = @TaskID,AttachmentName = @AttachmentName,AttachmentPath = @AttachmentPath,OriginalName = @OriginalName");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(string key)
        {
            var strSql = "DELETE FROM DJES.dbo.TaskArchivesAttachment WHERE RowGuid = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.TaskArchivesAttachment WHERE 1 = 1 {where}");

        public TaskArchivesAttachment GetModel(string key)
        {
            var strSql = "SELECT * FROM DJES.dbo.TaskArchivesAttachment WHERE RowGuid = @key";
            return DbClient.Query<TaskArchivesAttachment>(strSql, new { key }).FirstOrDefault();
        }

        public List<TaskArchivesAttachment> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.TaskArchivesAttachment WHERE {where}";
            return DbClient.Query<TaskArchivesAttachment>(strSql).ToList();
        }

        public List<TaskArchivesAttachment> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.TaskArchivesAttachment ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.TaskArchivesAttachment WHERE {where};");
            return DbClient.Query<TaskArchivesAttachment>(strSql.ToString()).ToList();
        }

    }
}
