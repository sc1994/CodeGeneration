using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class FormulaColumnDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.FormulaColumn WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.FormulaColumn WHERE {where};") > 0;

        public int Add(FormulaColumn model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboFormulaColumn(");
            strSql.Append("FormulaID,FormulaColumnName,FormulaColumnmodulu");
            strSql.Append(") VALUES (");
            strSql.Append("@FormulaID,@FormulaColumnName,@FormulaColumnmodulu);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(FormulaColumn model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboFormulaColumn SET ");
            strSql.Append("FormulaID = @FormulaID,FormulaColumnName = @FormulaColumnName,FormulaColumnmodulu = @FormulaColumnmodulu");
            strSql.Append(" WHERE FormulaColumnID = @FormulaColumnID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboFormulaColumn SET ");
            strSql.Append("FormulaID = @FormulaID,FormulaColumnName = @FormulaColumnName,FormulaColumnmodulu = @FormulaColumnmodulu");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.FormulaColumn WHERE FormulaColumnID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.FormulaColumn WHERE 1 = 1 {where}");

        public FormulaColumn GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.FormulaColumn WHERE FormulaColumnID = @key";
            return DbClient.Query<FormulaColumn>(strSql, new { key }).FirstOrDefault();
        }

        public List<FormulaColumn> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.FormulaColumn WHERE {where}";
            return DbClient.Query<FormulaColumn>(strSql).ToList();
        }

        public List<FormulaColumn> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.FormulaColumn ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.FormulaColumn WHERE {where};");
            return DbClient.Query<FormulaColumn>(strSql.ToString()).ToList();
        }

    }
}
