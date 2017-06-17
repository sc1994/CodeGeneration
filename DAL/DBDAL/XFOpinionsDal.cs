using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class XFOpinionsDal
    {
        public bool Exists(long primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.XFOpinions WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.XFOpinions WHERE {where};") > 0;

        public long Add(XFOpinions model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboXFOpinions(");
            strSql.Append("CustomerID,TaskID,WordPath,PDFPath,SignatureBlueprintPath");
            strSql.Append(") VALUES (");
            strSql.Append("@CustomerID,@TaskID,@WordPath,@PDFPath,@SignatureBlueprintPath);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<long>(strSql.ToString(), model);
        }

        public bool Update(XFOpinions model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboXFOpinions SET ");
            strSql.Append("CustomerID = @CustomerID,TaskID = @TaskID,WordPath = @WordPath,PDFPath = @PDFPath,SignatureBlueprintPath = @SignatureBlueprintPath");
            strSql.Append(" WHERE OpinionsID = @OpinionsID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboXFOpinions SET ");
            strSql.Append("CustomerID = @CustomerID,TaskID = @TaskID,WordPath = @WordPath,PDFPath = @PDFPath,SignatureBlueprintPath = @SignatureBlueprintPath");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(long key)
        {
            var strSql = "DELETE FROM DJES.dbo.XFOpinions WHERE OpinionsID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.XFOpinions WHERE 1 = 1 {where}");

        public XFOpinions GetModel(long key)
        {
            var strSql = "SELECT * FROM DJES.dbo.XFOpinions WHERE OpinionsID = @key";
            return DbClient.Query<XFOpinions>(strSql, new { key }).FirstOrDefault();
        }

        public List<XFOpinions> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.XFOpinions WHERE {where}";
            return DbClient.Query<XFOpinions>(strSql).ToList();
        }

        public List<XFOpinions> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.XFOpinions ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.XFOpinions WHERE {where};");
            return DbClient.Query<XFOpinions>(strSql.ToString()).ToList();
        }

    }
}
