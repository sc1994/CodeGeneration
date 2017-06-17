using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class ReArchivesAttachmentDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ReArchivesAttachment WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ReArchivesAttachment WHERE {where};") > 0;

        public int Add(ReArchivesAttachment model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboReArchivesAttachment(");
            strSql.Append("ReExamineID,Profession,TaskID,ReAttachmentName,ReAttachmentPath,YuanAttachmentPath,ReState,Edition,ReViewType");
            strSql.Append(") VALUES (");
            strSql.Append("@ReExamineID,@Profession,@TaskID,@ReAttachmentName,@ReAttachmentPath,@YuanAttachmentPath,@ReState,@Edition,@ReViewType);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ReArchivesAttachment model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboReArchivesAttachment SET ");
            strSql.Append("ReExamineID = @ReExamineID,Profession = @Profession,TaskID = @TaskID,ReAttachmentName = @ReAttachmentName,ReAttachmentPath = @ReAttachmentPath,YuanAttachmentPath = @YuanAttachmentPath,ReState = @ReState,Edition = @Edition,ReViewType = @ReViewType");
            strSql.Append(" WHERE ReAttachmentID = @ReAttachmentID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboReArchivesAttachment SET ");
            strSql.Append("ReExamineID = @ReExamineID,Profession = @Profession,TaskID = @TaskID,ReAttachmentName = @ReAttachmentName,ReAttachmentPath = @ReAttachmentPath,YuanAttachmentPath = @YuanAttachmentPath,ReState = @ReState,Edition = @Edition,ReViewType = @ReViewType");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ReArchivesAttachment WHERE ReAttachmentID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ReArchivesAttachment WHERE 1 = 1 {where}");

        public ReArchivesAttachment GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ReArchivesAttachment WHERE ReAttachmentID = @key";
            return DbClient.Query<ReArchivesAttachment>(strSql, new { key }).FirstOrDefault();
        }

        public List<ReArchivesAttachment> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ReArchivesAttachment WHERE {where}";
            return DbClient.Query<ReArchivesAttachment>(strSql).ToList();
        }

        public List<ReArchivesAttachment> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ReArchivesAttachment ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ReArchivesAttachment WHERE {where};");
            return DbClient.Query<ReArchivesAttachment>(strSql.ToString()).ToList();
        }

    }
}
