using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class UserInfoDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.UserInfo WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.UserInfo WHERE {where};") > 0;

        public int Add(UserInfo model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboUserInfo(");
             strSql.Append("UserID,CustomerID,UserNo,UserName,Password,Roles,UserIdentity,Status,RefreshTime,WinXinNo,Areas,Ticket");
             strSql.Append(") VALUES (");
             strSql.Append("@UserID,@CustomerID,@UserNo,@UserName,@Password,@Roles,@UserIdentity,@Status,@RefreshTime,@WinXinNo,@Areas,@Ticket);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(UserInfo model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboUserInfo SET ");
            strSql.Append("CustomerID = @CustomerID,UserNo = @UserNo,UserName = @UserName,Password = @Password,Roles = @Roles,UserIdentity = @UserIdentity,Status = @Status,RefreshTime = @RefreshTime,WinXinNo = @WinXinNo,Areas = @Areas,Ticket = @Ticket");
            strSql.Append(" WHERE UserID = @UserID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboUserInfo SET ");
            strSql.Append("CustomerID = @CustomerID,UserNo = @UserNo,UserName = @UserName,Password = @Password,Roles = @Roles,UserIdentity = @UserIdentity,Status = @Status,RefreshTime = @RefreshTime,WinXinNo = @WinXinNo,Areas = @Areas,Ticket = @Ticket");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.UserInfo WHERE UserID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.UserInfo WHERE 1 = 1 {where}");

        public UserInfo GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.UserInfo WHERE UserID = @key";
            return DbClient.Query<UserInfo>(strSql, new { key }).FirstOrDefault();
        }

        public List<UserInfo> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.UserInfo WHERE {where}";
            return DbClient.Query<UserInfo>(strSql).ToList();
        }

        public List<UserInfo> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.UserInfo ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.UserInfo WHERE {where};");
            return DbClient.Query<UserInfo>(strSql.ToString()).ToList();
        }

    }
}
