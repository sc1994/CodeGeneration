using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class RemoteProjectArchivesAttachmentDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.RemoteProjectArchivesAttachment WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RemoteProjectArchivesAttachment WHERE {where};") > 0;

        public int Add(RemoteProjectArchivesAttachment model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboRemoteProjectArchivesAttachment(");
            strSql.Append("ProjectAttachmentID,ProjectArchiveID,ProjectArchiveName,YCTaskID,ProjectAttachmentName,ProjectAttachmentPath");
            strSql.Append(") VALUES (");
            strSql.Append("@ProjectAttachmentID,@ProjectArchiveID,@ProjectArchiveName,@YCTaskID,@ProjectAttachmentName,@ProjectAttachmentPath);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(RemoteProjectArchivesAttachment model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRemoteProjectArchivesAttachment SET ");
            strSql.Append("ProjectArchiveID = @ProjectArchiveID,ProjectArchiveName = @ProjectArchiveName,YCTaskID = @YCTaskID,ProjectAttachmentName = @ProjectAttachmentName,ProjectAttachmentPath = @ProjectAttachmentPath");
            strSql.Append(" WHERE ProjectAttachmentID = @ProjectAttachmentID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRemoteProjectArchivesAttachment SET ");
            strSql.Append("ProjectArchiveID = @ProjectArchiveID,ProjectArchiveName = @ProjectArchiveName,YCTaskID = @YCTaskID,ProjectAttachmentName = @ProjectAttachmentName,ProjectAttachmentPath = @ProjectAttachmentPath");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.RemoteProjectArchivesAttachment WHERE ProjectAttachmentID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.RemoteProjectArchivesAttachment WHERE 1 = 1 {where}");

        public RemoteProjectArchivesAttachment GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.RemoteProjectArchivesAttachment WHERE ProjectAttachmentID = @key";
            return DbClient.Query<RemoteProjectArchivesAttachment>(strSql, new { key }).FirstOrDefault();
        }

        public List<RemoteProjectArchivesAttachment> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.RemoteProjectArchivesAttachment WHERE {where}";
            return DbClient.Query<RemoteProjectArchivesAttachment>(strSql).ToList();
        }

        public List<RemoteProjectArchivesAttachment> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.RemoteProjectArchivesAttachment ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RemoteProjectArchivesAttachment WHERE {where};");
            return DbClient.Query<RemoteProjectArchivesAttachment>(strSql.ToString()).ToList();
        }

    }
}
