using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ProjectArchivesAttachmentDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ProjectArchivesAttachment WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ProjectArchivesAttachment WHERE {where};") > 0;

        public int Add(ProjectArchivesAttachment model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboProjectArchivesAttachment(");
             strSql.Append("ProjectAttachmentID,ProjectArchiveID,ProjectArchiveName,TaskID,ProjectAttachmentName,ProjectAttachmentPath");
             strSql.Append(") VALUES (");
             strSql.Append("@ProjectAttachmentID,@ProjectArchiveID,@ProjectArchiveName,@TaskID,@ProjectAttachmentName,@ProjectAttachmentPath);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ProjectArchivesAttachment model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboProjectArchivesAttachment SET ");
            strSql.Append("ProjectArchiveID = @ProjectArchiveID,ProjectArchiveName = @ProjectArchiveName,TaskID = @TaskID,ProjectAttachmentName = @ProjectAttachmentName,ProjectAttachmentPath = @ProjectAttachmentPath");
            strSql.Append(" WHERE ProjectAttachmentID = @ProjectAttachmentID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboProjectArchivesAttachment SET ");
            strSql.Append("ProjectArchiveID = @ProjectArchiveID,ProjectArchiveName = @ProjectArchiveName,TaskID = @TaskID,ProjectAttachmentName = @ProjectAttachmentName,ProjectAttachmentPath = @ProjectAttachmentPath");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ProjectArchivesAttachment WHERE ProjectAttachmentID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ProjectArchivesAttachment WHERE 1 = 1 {where}");

        public ProjectArchivesAttachment GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ProjectArchivesAttachment WHERE ProjectAttachmentID = @key";
            return DbClient.Query<ProjectArchivesAttachment>(strSql, new { key }).FirstOrDefault();
        }

        public List<ProjectArchivesAttachment> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ProjectArchivesAttachment WHERE {where}";
            return DbClient.Query<ProjectArchivesAttachment>(strSql).ToList();
        }

        public List<ProjectArchivesAttachment> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ProjectArchivesAttachment ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ProjectArchivesAttachment WHERE {where};");
            return DbClient.Query<ProjectArchivesAttachment>(strSql.ToString()).ToList();
        }

    }
}
