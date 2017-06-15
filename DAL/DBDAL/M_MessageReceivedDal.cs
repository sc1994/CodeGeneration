using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class M_MessageReceivedDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.M_MessageReceived WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.M_MessageReceived WHERE {where};") > 0;

        public int Add(M_MessageReceived model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboM_MessageReceived(");
            strSql.Append("MID,SendTelNumber,ReceiveTime,MessageContent,IsReaded");
            strSql.Append(") VALUES (");
            strSql.Append("@MID,@SendTelNumber,@ReceiveTime,@MessageContent,@IsReaded);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(M_MessageReceived model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboM_MessageReceived SET ");
            strSql.Append("SendTelNumber = @SendTelNumber,ReceiveTime = @ReceiveTime,MessageContent = @MessageContent,IsReaded = @IsReaded");
            strSql.Append(" WHERE MID = @MID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboM_MessageReceived SET ");
            strSql.Append("SendTelNumber = @SendTelNumber,ReceiveTime = @ReceiveTime,MessageContent = @MessageContent,IsReaded = @IsReaded");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.M_MessageReceived WHERE MID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.M_MessageReceived WHERE 1 = 1 {where}");

        public M_MessageReceived GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.M_MessageReceived WHERE MID = @key";
            return DbClient.Query<M_MessageReceived>(strSql, new { key }).FirstOrDefault();
        }

        public List<M_MessageReceived> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.M_MessageReceived WHERE {where}";
            return DbClient.Query<M_MessageReceived>(strSql).ToList();
        }

        public List<M_MessageReceived> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.M_MessageReceived ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.M_MessageReceived WHERE {where};");
            return DbClient.Query<M_MessageReceived>(strSql.ToString()).ToList();
        }

    }
}
