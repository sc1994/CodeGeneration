using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class CensorChargeDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.CensorCharge WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CensorCharge WHERE {where};") > 0;

        public int Add(CensorCharge model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboCensorCharge(");
            strSql.Append("TaskID,CustomerID,AccountReceivable,RealSum,ReduceReason,ChargeState,ChargeDate,Calculationer,Reviewer,Charger");
            strSql.Append(") VALUES (");
            strSql.Append("@TaskID,@CustomerID,@AccountReceivable,@RealSum,@ReduceReason,@ChargeState,@ChargeDate,@Calculationer,@Reviewer,@Charger);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CensorCharge model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCensorCharge SET ");
            strSql.Append("TaskID = @TaskID,CustomerID = @CustomerID,AccountReceivable = @AccountReceivable,RealSum = @RealSum,ReduceReason = @ReduceReason,ChargeState = @ChargeState,ChargeDate = @ChargeDate,Calculationer = @Calculationer,Reviewer = @Reviewer,Charger = @Charger");
            strSql.Append(" WHERE ID = @ID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCensorCharge SET ");
            strSql.Append("TaskID = @TaskID,CustomerID = @CustomerID,AccountReceivable = @AccountReceivable,RealSum = @RealSum,ReduceReason = @ReduceReason,ChargeState = @ChargeState,ChargeDate = @ChargeDate,Calculationer = @Calculationer,Reviewer = @Reviewer,Charger = @Charger");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.CensorCharge WHERE ID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.CensorCharge WHERE 1 = 1 {where}");

        public CensorCharge GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.CensorCharge WHERE ID = @key";
            return DbClient.Query<CensorCharge>(strSql, new { key }).FirstOrDefault();
        }

        public List<CensorCharge> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.CensorCharge WHERE {where}";
            return DbClient.Query<CensorCharge>(strSql).ToList();
        }

        public List<CensorCharge> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.CensorCharge ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CensorCharge WHERE {where};");
            return DbClient.Query<CensorCharge>(strSql.ToString()).ToList();
        }

    }
}
