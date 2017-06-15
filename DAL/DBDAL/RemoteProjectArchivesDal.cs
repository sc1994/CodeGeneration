using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class RemoteProjectArchivesDal
    {
        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RemoteProjectArchives WHERE {where};") > 0;

        public void Add(RemoteProjectArchives model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboRemoteProjectArchives(");
            strSql.Append("ProjectArchiveID,ProjectID,ProjectArchiveName,Profession,ProfessionValue,ProjectArchiveStatus,ProjectArchiveAttachment,AttachmentTypeID");
            strSql.Append(") VALUES (");
            strSql.Append("@ProjectArchiveID,@ProjectID,@ProjectArchiveName,@Profession,@ProfessionValue,@ProjectArchiveStatus,@ProjectArchiveAttachment,@AttachmentTypeID);");
            DbClient.Excute(strSql.ToString(), model);
        }

        public bool Update(RemoteProjectArchives model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRemoteProjectArchives SET ");
            strSql.Append("ProjectID = @ProjectID,ProjectArchiveName = @ProjectArchiveName,Profession = @Profession,ProfessionValue = @ProfessionValue,ProjectArchiveStatus = @ProjectArchiveStatus,ProjectArchiveAttachment = @ProjectArchiveAttachment,AttachmentTypeID = @AttachmentTypeID");
            strSql.Append(" WHERE ProjectArchiveID = @ProjectArchiveID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRemoteProjectArchives SET ");
            strSql.Append("ProjectID = @ProjectID,ProjectArchiveName = @ProjectArchiveName,Profession = @Profession,ProfessionValue = @ProfessionValue,ProjectArchiveStatus = @ProjectArchiveStatus,ProjectArchiveAttachment = @ProjectArchiveAttachment,AttachmentTypeID = @AttachmentTypeID");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.RemoteProjectArchives WHERE 1 = 1 {where}");

        public List<RemoteProjectArchives> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.RemoteProjectArchives WHERE {where}";
            return DbClient.Query<RemoteProjectArchives>(strSql).ToList();
        }

        public List<RemoteProjectArchives> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.RemoteProjectArchives ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RemoteProjectArchives WHERE {where};");
            return DbClient.Query<RemoteProjectArchives>(strSql.ToString()).ToList();
        }

    }
}
