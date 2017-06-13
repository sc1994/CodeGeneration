using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class CensorProblemRelationDal
    {
        public bool Exists(string primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.CensorProblemRelation WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CensorProblemRelation WHERE {where};") > 0;

        public string Add(CensorProblemRelation model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboCensorProblemRelation(");
             strSql.Append("ID,RowGuid,ProblemID,ProjectID,DrawingRowGuid,DrawingX1,DrawingY1,DrawingX2,DrawingY2,PageNumber");
             strSql.Append(") VALUES (");
             strSql.Append("@ID,@RowGuid,@ProblemID,@ProjectID,@DrawingRowGuid,@DrawingX1,@DrawingY1,@DrawingX2,@DrawingY2,@PageNumber);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<string>(strSql.ToString(), model);
        }

        public bool Update(CensorProblemRelation model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCensorProblemRelation SET ");
            strSql.Append("ProblemID = @ProblemID,ProjectID = @ProjectID,DrawingRowGuid = @DrawingRowGuid,DrawingX1 = @DrawingX1,DrawingY1 = @DrawingY1,DrawingX2 = @DrawingX2,DrawingY2 = @DrawingY2,PageNumber = @PageNumber");
            strSql.Append(" WHERE RowGuid = @RowGuid");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCensorProblemRelation SET ");
            strSql.Append("ProblemID = @ProblemID,ProjectID = @ProjectID,DrawingRowGuid = @DrawingRowGuid,DrawingX1 = @DrawingX1,DrawingY1 = @DrawingY1,DrawingX2 = @DrawingX2,DrawingY2 = @DrawingY2,PageNumber = @PageNumber");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(string key)
        {
            var strSql = "DELETE FROM DJES.dbo.CensorProblemRelation WHERE RowGuid = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.CensorProblemRelation WHERE 1 = 1 {where}");

        public CensorProblemRelation GetModel(string key)
        {
            var strSql = "SELECT * FROM DJES.dbo.CensorProblemRelation WHERE RowGuid = @key";
            return DbClient.Query<CensorProblemRelation>(strSql, new { key }).FirstOrDefault();
        }

        public List<CensorProblemRelation> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.CensorProblemRelation WHERE {where}";
            return DbClient.Query<CensorProblemRelation>(strSql).ToList();
        }

        public List<CensorProblemRelation> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.CensorProblemRelation ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CensorProblemRelation WHERE {where};");
            return DbClient.Query<CensorProblemRelation>(strSql.ToString()).ToList();
        }

    }
}
