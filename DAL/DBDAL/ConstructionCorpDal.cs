using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class ConstructionCorpDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ConstructionCorp WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ConstructionCorp WHERE {where};") > 0;

        public int Add(ConstructionCorp model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboConstructionCorp(");
            strSql.Append("CorpName,ContactPerson,ContactPersonTel,WinXinNo,OrganizationCode,Password,CorpStatus,RegisterDate");
            strSql.Append(") VALUES (");
            strSql.Append("@CorpName,@ContactPerson,@ContactPersonTel,@WinXinNo,@OrganizationCode,@Password,@CorpStatus,@RegisterDate);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ConstructionCorp model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboConstructionCorp SET ");
            strSql.Append("CorpName = @CorpName,ContactPerson = @ContactPerson,ContactPersonTel = @ContactPersonTel,WinXinNo = @WinXinNo,OrganizationCode = @OrganizationCode,Password = @Password,CorpStatus = @CorpStatus,RegisterDate = @RegisterDate");
            strSql.Append(" WHERE CorpID = @CorpID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboConstructionCorp SET ");
            strSql.Append("CorpName = @CorpName,ContactPerson = @ContactPerson,ContactPersonTel = @ContactPersonTel,WinXinNo = @WinXinNo,OrganizationCode = @OrganizationCode,Password = @Password,CorpStatus = @CorpStatus,RegisterDate = @RegisterDate");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ConstructionCorp WHERE CorpID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ConstructionCorp WHERE 1 = 1 {where}");

        public ConstructionCorp GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ConstructionCorp WHERE CorpID = @key";
            return DbClient.Query<ConstructionCorp>(strSql, new { key }).FirstOrDefault();
        }

        public List<ConstructionCorp> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ConstructionCorp WHERE {where}";
            return DbClient.Query<ConstructionCorp>(strSql).ToList();
        }

        public List<ConstructionCorp> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ConstructionCorp ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ConstructionCorp WHERE {where};");
            return DbClient.Query<ConstructionCorp>(strSql.ToString()).ToList();
        }

    }
}
