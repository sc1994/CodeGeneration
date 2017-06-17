using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class ProfessionalRelationshipDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ProfessionalRelationship WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ProfessionalRelationship WHERE {where};") > 0;

        public int Add(ProfessionalRelationship model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboProfessionalRelationship(");
            strSql.Append("CustomerID,Profession,MaterialProfession,MaterialProfessionValue");
            strSql.Append(") VALUES (");
            strSql.Append("@CustomerID,@Profession,@MaterialProfession,@MaterialProfessionValue);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ProfessionalRelationship model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboProfessionalRelationship SET ");
            strSql.Append("CustomerID = @CustomerID,Profession = @Profession,MaterialProfession = @MaterialProfession,MaterialProfessionValue = @MaterialProfessionValue");
            strSql.Append(" WHERE PRID = @PRID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboProfessionalRelationship SET ");
            strSql.Append("CustomerID = @CustomerID,Profession = @Profession,MaterialProfession = @MaterialProfession,MaterialProfessionValue = @MaterialProfessionValue");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ProfessionalRelationship WHERE PRID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ProfessionalRelationship WHERE 1 = 1 {where}");

        public ProfessionalRelationship GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ProfessionalRelationship WHERE PRID = @key";
            return DbClient.Query<ProfessionalRelationship>(strSql, new { key }).FirstOrDefault();
        }

        public List<ProfessionalRelationship> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ProfessionalRelationship WHERE {where}";
            return DbClient.Query<ProfessionalRelationship>(strSql).ToList();
        }

        public List<ProfessionalRelationship> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ProfessionalRelationship ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ProfessionalRelationship WHERE {where};");
            return DbClient.Query<ProfessionalRelationship>(strSql.ToString()).ToList();
        }

    }
}
