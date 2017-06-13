using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class DongleTokenDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.DongleToken WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.DongleToken WHERE {where};") > 0;

        public int Add(DongleToken model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboDongleToken(");
             strSql.Append("Id,Token,Seed,Status,IssuingName");
             strSql.Append(") VALUES (");
             strSql.Append("@Id,@Token,@Seed,@Status,@IssuingName);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(DongleToken model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDongleToken SET ");
            strSql.Append("Token = @Token,Seed = @Seed,Status = @Status,IssuingName = @IssuingName");
            strSql.Append(" WHERE Id = @Id");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDongleToken SET ");
            strSql.Append("Token = @Token,Seed = @Seed,Status = @Status,IssuingName = @IssuingName");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.DongleToken WHERE Id = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.DongleToken WHERE 1 = 1 {where}");

        public DongleToken GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.DongleToken WHERE Id = @key";
            return DbClient.Query<DongleToken>(strSql, new { key }).FirstOrDefault();
        }

        public List<DongleToken> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.DongleToken WHERE {where}";
            return DbClient.Query<DongleToken>(strSql).ToList();
        }

        public List<DongleToken> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.DongleToken ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.DongleToken WHERE {where};");
            return DbClient.Query<DongleToken>(strSql.ToString()).ToList();
        }

    }
}
