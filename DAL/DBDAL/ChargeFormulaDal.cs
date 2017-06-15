using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class ChargeFormulaDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ChargeFormula WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ChargeFormula WHERE {where};") > 0;

        public int Add(ChargeFormula model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboChargeFormula(");
            strSql.Append("FormulaID,CustomerID,FormulaName,FormulaType,DisplayFormulaContent,MinChargeAmount,PreferentialQuota,PreferentialDiscount,MaxChargeAmount,ISPreferentia");
            strSql.Append(") VALUES (");
            strSql.Append("@FormulaID,@CustomerID,@FormulaName,@FormulaType,@DisplayFormulaContent,@MinChargeAmount,@PreferentialQuota,@PreferentialDiscount,@MaxChargeAmount,@ISPreferentia);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ChargeFormula model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboChargeFormula SET ");
            strSql.Append("CustomerID = @CustomerID,FormulaName = @FormulaName,FormulaType = @FormulaType,DisplayFormulaContent = @DisplayFormulaContent,MinChargeAmount = @MinChargeAmount,PreferentialQuota = @PreferentialQuota,PreferentialDiscount = @PreferentialDiscount,MaxChargeAmount = @MaxChargeAmount,ISPreferentia = @ISPreferentia");
            strSql.Append(" WHERE FormulaID = @FormulaID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboChargeFormula SET ");
            strSql.Append("CustomerID = @CustomerID,FormulaName = @FormulaName,FormulaType = @FormulaType,DisplayFormulaContent = @DisplayFormulaContent,MinChargeAmount = @MinChargeAmount,PreferentialQuota = @PreferentialQuota,PreferentialDiscount = @PreferentialDiscount,MaxChargeAmount = @MaxChargeAmount,ISPreferentia = @ISPreferentia");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ChargeFormula WHERE FormulaID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ChargeFormula WHERE 1 = 1 {where}");

        public ChargeFormula GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ChargeFormula WHERE FormulaID = @key";
            return DbClient.Query<ChargeFormula>(strSql, new { key }).FirstOrDefault();
        }

        public List<ChargeFormula> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ChargeFormula WHERE {where}";
            return DbClient.Query<ChargeFormula>(strSql).ToList();
        }

        public List<ChargeFormula> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ChargeFormula ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ChargeFormula WHERE {where};");
            return DbClient.Query<ChargeFormula>(strSql.ToString()).ToList();
        }

    }
}
