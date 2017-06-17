using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class DrawingSignatureSiteDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.DrawingSignatureSite WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.DrawingSignatureSite WHERE {where};") > 0;

        public int Add(DrawingSignatureSite model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboDrawingSignatureSite(");
            strSql.Append("DrawingSpace,DesignCorpSiteX,DesignCorpSiteY,CensorCorpSiteX,CensorCorpSiteY,ExpertSiteX,ExpertSiteY,Remarks");
            strSql.Append(") VALUES (");
            strSql.Append("@DrawingSpace,@DesignCorpSiteX,@DesignCorpSiteY,@CensorCorpSiteX,@CensorCorpSiteY,@ExpertSiteX,@ExpertSiteY,@Remarks);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(DrawingSignatureSite model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDrawingSignatureSite SET ");
            strSql.Append("DrawingSpace = @DrawingSpace,DesignCorpSiteX = @DesignCorpSiteX,DesignCorpSiteY = @DesignCorpSiteY,CensorCorpSiteX = @CensorCorpSiteX,CensorCorpSiteY = @CensorCorpSiteY,ExpertSiteX = @ExpertSiteX,ExpertSiteY = @ExpertSiteY,Remarks = @Remarks");
            strSql.Append(" WHERE SiteID = @SiteID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDrawingSignatureSite SET ");
            strSql.Append("DrawingSpace = @DrawingSpace,DesignCorpSiteX = @DesignCorpSiteX,DesignCorpSiteY = @DesignCorpSiteY,CensorCorpSiteX = @CensorCorpSiteX,CensorCorpSiteY = @CensorCorpSiteY,ExpertSiteX = @ExpertSiteX,ExpertSiteY = @ExpertSiteY,Remarks = @Remarks");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.DrawingSignatureSite WHERE SiteID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.DrawingSignatureSite WHERE 1 = 1 {where}");

        public DrawingSignatureSite GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.DrawingSignatureSite WHERE SiteID = @key";
            return DbClient.Query<DrawingSignatureSite>(strSql, new { key }).FirstOrDefault();
        }

        public List<DrawingSignatureSite> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.DrawingSignatureSite WHERE {where}";
            return DbClient.Query<DrawingSignatureSite>(strSql).ToList();
        }

        public List<DrawingSignatureSite> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.DrawingSignatureSite ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.DrawingSignatureSite WHERE {where};");
            return DbClient.Query<DrawingSignatureSite>(strSql.ToString()).ToList();
        }

    }
}
