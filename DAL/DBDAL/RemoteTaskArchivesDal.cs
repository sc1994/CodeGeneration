using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class RemoteTaskArchivesDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.RemoteTaskArchives WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RemoteTaskArchives WHERE {where};") > 0;

        public int Add(RemoteTaskArchives model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboRemoteTaskArchives(");
            strSql.Append("YCTaskID,ConstructCorp,ArchiveName,ArchiveStatus,ArchiveAttachment,PolicyArchiveType");
            strSql.Append(") VALUES (");
            strSql.Append("@YCTaskID,@ConstructCorp,@ArchiveName,@ArchiveStatus,@ArchiveAttachment,@PolicyArchiveType);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(RemoteTaskArchives model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRemoteTaskArchives SET ");
            strSql.Append("YCTaskID = @YCTaskID,ConstructCorp = @ConstructCorp,ArchiveName = @ArchiveName,ArchiveStatus = @ArchiveStatus,ArchiveAttachment = @ArchiveAttachment,PolicyArchiveType = @PolicyArchiveType");
            strSql.Append(" WHERE ArchiveID = @ArchiveID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRemoteTaskArchives SET ");
            strSql.Append("YCTaskID = @YCTaskID,ConstructCorp = @ConstructCorp,ArchiveName = @ArchiveName,ArchiveStatus = @ArchiveStatus,ArchiveAttachment = @ArchiveAttachment,PolicyArchiveType = @PolicyArchiveType");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.RemoteTaskArchives WHERE ArchiveID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.RemoteTaskArchives WHERE 1 = 1 {where}");

        public RemoteTaskArchives GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.RemoteTaskArchives WHERE ArchiveID = @key";
            return DbClient.Query<RemoteTaskArchives>(strSql, new { key }).FirstOrDefault();
        }

        public List<RemoteTaskArchives> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.RemoteTaskArchives WHERE {where}";
            return DbClient.Query<RemoteTaskArchives>(strSql).ToList();
        }

        public List<RemoteTaskArchives> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.RemoteTaskArchives ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RemoteTaskArchives WHERE {where};");
            return DbClient.Query<RemoteTaskArchives>(strSql.ToString()).ToList();
        }

    }
}
