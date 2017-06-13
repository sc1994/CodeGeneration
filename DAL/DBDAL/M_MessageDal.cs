using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class M_MessageDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.M_Message WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.M_Message WHERE {where};") > 0;

        public int Add(M_Message model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboM_Message(");
             strSql.Append("iMessageID,vMessageContent,vMessageName");
             strSql.Append(") VALUES (");
             strSql.Append("@iMessageID,@vMessageContent,@vMessageName);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(M_Message model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboM_Message SET ");
            strSql.Append("vMessageContent = @vMessageContent,vMessageName = @vMessageName");
            strSql.Append(" WHERE iMessageID = @iMessageID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboM_Message SET ");
            strSql.Append("vMessageContent = @vMessageContent,vMessageName = @vMessageName");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.M_Message WHERE iMessageID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.M_Message WHERE 1 = 1 {where}");

        public M_Message GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.M_Message WHERE iMessageID = @key";
            return DbClient.Query<M_Message>(strSql, new { key }).FirstOrDefault();
        }

        public List<M_Message> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.M_Message WHERE {where}";
            return DbClient.Query<M_Message>(strSql).ToList();
        }

        public List<M_Message> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.M_Message ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.M_Message WHERE {where};");
            return DbClient.Query<M_Message>(strSql.ToString()).ToList();
        }

    }
}
