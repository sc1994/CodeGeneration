using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ProjectArchivesDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ProjectArchives WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ProjectArchives WHERE {where};") > 0;

        public int Add(ProjectArchives model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboProjectArchives(");
             strSql.Append("ProjectArchiveID,ProjectID,ProjectArchiveName,Profession,ProfessionValue,ProjectArchiveStatus,ProjectArchiveAttachment,AttachmentTypeID");
             strSql.Append(") VALUES (");
             strSql.Append("@ProjectArchiveID,@ProjectID,@ProjectArchiveName,@Profession,@ProfessionValue,@ProjectArchiveStatus,@ProjectArchiveAttachment,@AttachmentTypeID);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ProjectArchives model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboProjectArchives SET ");
            strSql.Append("ProjectID = @ProjectID,ProjectArchiveName = @ProjectArchiveName,Profession = @Profession,ProfessionValue = @ProfessionValue,ProjectArchiveStatus = @ProjectArchiveStatus,ProjectArchiveAttachment = @ProjectArchiveAttachment,AttachmentTypeID = @AttachmentTypeID");
            strSql.Append(" WHERE ProjectArchiveID = @ProjectArchiveID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboProjectArchives SET ");
            strSql.Append("ProjectID = @ProjectID,ProjectArchiveName = @ProjectArchiveName,Profession = @Profession,ProfessionValue = @ProfessionValue,ProjectArchiveStatus = @ProjectArchiveStatus,ProjectArchiveAttachment = @ProjectArchiveAttachment,AttachmentTypeID = @AttachmentTypeID");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ProjectArchives WHERE ProjectArchiveID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ProjectArchives WHERE 1 = 1 {where}");

        public ProjectArchives GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ProjectArchives WHERE ProjectArchiveID = @key";
            return DbClient.Query<ProjectArchives>(strSql, new { key }).FirstOrDefault();
        }

        public List<ProjectArchives> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ProjectArchives WHERE {where}";
            return DbClient.Query<ProjectArchives>(strSql).ToList();
        }

        public List<ProjectArchives> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ProjectArchives ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ProjectArchives WHERE {where};");
            return DbClient.Query<ProjectArchives>(strSql.ToString()).ToList();
        }

    }
}
