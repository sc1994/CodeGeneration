using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class LoginLogDal
    {
        public bool Exists(long primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.LoginLog WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.LoginLog WHERE {where};") > 0;

        public long Add(LoginLog model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboLoginLog(");
            strSql.Append("LogIP,UserID,CreateTime,LogType");
            strSql.Append(") VALUES (");
            strSql.Append("@LogIP,@UserID,@CreateTime,@LogType);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<long>(strSql.ToString(), model);
        }

        public bool Update(LoginLog model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboLoginLog SET ");
            strSql.Append("LogIP = @LogIP,UserID = @UserID,CreateTime = @CreateTime,LogType = @LogType");
            strSql.Append(" WHERE ID = @ID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboLoginLog SET ");
            strSql.Append("LogIP = @LogIP,UserID = @UserID,CreateTime = @CreateTime,LogType = @LogType");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(long key)
        {
            var strSql = "DELETE FROM DJES.dbo.LoginLog WHERE ID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.LoginLog WHERE 1 = 1 {where}");

        public LoginLog GetModel(long key)
        {
            var strSql = "SELECT * FROM DJES.dbo.LoginLog WHERE ID = @key";
            return DbClient.Query<LoginLog>(strSql, new { key }).FirstOrDefault();
        }

        public List<LoginLog> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.LoginLog WHERE {where}";
            return DbClient.Query<LoginLog>(strSql).ToList();
        }

        public List<LoginLog> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.LoginLog ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.LoginLog WHERE {where};");
            return DbClient.Query<LoginLog>(strSql.ToString()).ToList();
        }

    }
}
