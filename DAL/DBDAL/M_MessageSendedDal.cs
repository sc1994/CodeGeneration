using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class M_MessageSendedDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.M_MessageSended WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.M_MessageSended WHERE {where};") > 0;

        public int Add(M_MessageSended model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboM_MessageSended(");
            strSql.Append("ReceiveTelNumber,SendTime,MessageContent");
            strSql.Append(") VALUES (");
            strSql.Append("@ReceiveTelNumber,@SendTime,@MessageContent);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(M_MessageSended model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboM_MessageSended SET ");
            strSql.Append("ReceiveTelNumber = @ReceiveTelNumber,SendTime = @SendTime,MessageContent = @MessageContent");
            strSql.Append(" WHERE MID = @MID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboM_MessageSended SET ");
            strSql.Append("ReceiveTelNumber = @ReceiveTelNumber,SendTime = @SendTime,MessageContent = @MessageContent");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.M_MessageSended WHERE MID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.M_MessageSended WHERE 1 = 1 {where}");

        public M_MessageSended GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.M_MessageSended WHERE MID = @key";
            return DbClient.Query<M_MessageSended>(strSql, new { key }).FirstOrDefault();
        }

        public List<M_MessageSended> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.M_MessageSended WHERE {where}";
            return DbClient.Query<M_MessageSended>(strSql).ToList();
        }

        public List<M_MessageSended> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.M_MessageSended ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.M_MessageSended WHERE {where};");
            return DbClient.Query<M_MessageSended>(strSql.ToString()).ToList();
        }

    }
}
