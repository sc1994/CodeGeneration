using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class CooperationDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.Cooperation WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.Cooperation WHERE {where};") > 0;

        public int Add(Cooperation model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboCooperation(");
            strSql.Append("CorpID,CustomerID,CorpName,ContactPerson,ContactPersonTel,Location");
            strSql.Append(") VALUES (");
            strSql.Append("@CorpID,@CustomerID,@CorpName,@ContactPerson,@ContactPersonTel,@Location);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(Cooperation model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCooperation SET ");
            strSql.Append("CustomerID = @CustomerID,CorpName = @CorpName,ContactPerson = @ContactPerson,ContactPersonTel = @ContactPersonTel,Location = @Location");
            strSql.Append(" WHERE CorpID = @CorpID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCooperation SET ");
            strSql.Append("CustomerID = @CustomerID,CorpName = @CorpName,ContactPerson = @ContactPerson,ContactPersonTel = @ContactPersonTel,Location = @Location");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.Cooperation WHERE CorpID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.Cooperation WHERE 1 = 1 {where}");

        public Cooperation GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.Cooperation WHERE CorpID = @key";
            return DbClient.Query<Cooperation>(strSql, new { key }).FirstOrDefault();
        }

        public List<Cooperation> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.Cooperation WHERE {where}";
            return DbClient.Query<Cooperation>(strSql).ToList();
        }

        public List<Cooperation> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.Cooperation ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.Cooperation WHERE {where};");
            return DbClient.Query<Cooperation>(strSql.ToString()).ToList();
        }

    }
}
