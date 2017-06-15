using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class DrawingClassifyDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.DrawingClassify WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.DrawingClassify WHERE {where};") > 0;

        public int Add(DrawingClassify model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboDrawingClassify(");
            strSql.Append("DCID,ProjectSupType,DrawingClassifyName,DrawingClassifyMark,DCRemarks");
            strSql.Append(") VALUES (");
            strSql.Append("@DCID,@ProjectSupType,@DrawingClassifyName,@DrawingClassifyMark,@DCRemarks);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(DrawingClassify model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDrawingClassify SET ");
            strSql.Append("ProjectSupType = @ProjectSupType,DrawingClassifyName = @DrawingClassifyName,DrawingClassifyMark = @DrawingClassifyMark,DCRemarks = @DCRemarks");
            strSql.Append(" WHERE DCID = @DCID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDrawingClassify SET ");
            strSql.Append("ProjectSupType = @ProjectSupType,DrawingClassifyName = @DrawingClassifyName,DrawingClassifyMark = @DrawingClassifyMark,DCRemarks = @DCRemarks");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.DrawingClassify WHERE DCID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.DrawingClassify WHERE 1 = 1 {where}");

        public DrawingClassify GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.DrawingClassify WHERE DCID = @key";
            return DbClient.Query<DrawingClassify>(strSql, new { key }).FirstOrDefault();
        }

        public List<DrawingClassify> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.DrawingClassify WHERE {where}";
            return DbClient.Query<DrawingClassify>(strSql).ToList();
        }

        public List<DrawingClassify> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.DrawingClassify ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.DrawingClassify WHERE {where};");
            return DbClient.Query<DrawingClassify>(strSql.ToString()).ToList();
        }

    }
}
