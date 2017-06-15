using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class PolicyReviewArchiveDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.PolicyReviewArchive WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.PolicyReviewArchive WHERE {where};") > 0;

        public int Add(PolicyReviewArchive model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboPolicyReviewArchive(");
            strSql.Append("PolicyReviewArchiveID,CustomerID,ProjectSupType,PolicyReviewArchiveName,PolicyArchiveType");
            strSql.Append(") VALUES (");
            strSql.Append("@PolicyReviewArchiveID,@CustomerID,@ProjectSupType,@PolicyReviewArchiveName,@PolicyArchiveType);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(PolicyReviewArchive model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboPolicyReviewArchive SET ");
            strSql.Append("CustomerID = @CustomerID,ProjectSupType = @ProjectSupType,PolicyReviewArchiveName = @PolicyReviewArchiveName,PolicyArchiveType = @PolicyArchiveType");
            strSql.Append(" WHERE PolicyReviewArchiveID = @PolicyReviewArchiveID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboPolicyReviewArchive SET ");
            strSql.Append("CustomerID = @CustomerID,ProjectSupType = @ProjectSupType,PolicyReviewArchiveName = @PolicyReviewArchiveName,PolicyArchiveType = @PolicyArchiveType");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.PolicyReviewArchive WHERE PolicyReviewArchiveID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.PolicyReviewArchive WHERE 1 = 1 {where}");

        public PolicyReviewArchive GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.PolicyReviewArchive WHERE PolicyReviewArchiveID = @key";
            return DbClient.Query<PolicyReviewArchive>(strSql, new { key }).FirstOrDefault();
        }

        public List<PolicyReviewArchive> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.PolicyReviewArchive WHERE {where}";
            return DbClient.Query<PolicyReviewArchive>(strSql).ToList();
        }

        public List<PolicyReviewArchive> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.PolicyReviewArchive ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.PolicyReviewArchive WHERE {where};");
            return DbClient.Query<PolicyReviewArchive>(strSql.ToString()).ToList();
        }

    }
}
