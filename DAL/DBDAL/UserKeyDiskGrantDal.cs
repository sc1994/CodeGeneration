using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class UserKeyDiskGrantDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.UserKeyDiskGrant WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.UserKeyDiskGrant WHERE {where};") > 0;

        public int Add(UserKeyDiskGrant model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboUserKeyDiskGrant(");
            strSql.Append("UserKeyDiskNumber,UserKeyDiskName,UserKeyDiskPassWord,UserID,UserName,Remark");
            strSql.Append(") VALUES (");
            strSql.Append("@UserKeyDiskNumber,@UserKeyDiskName,@UserKeyDiskPassWord,@UserID,@UserName,@Remark);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(UserKeyDiskGrant model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboUserKeyDiskGrant SET ");
            strSql.Append("UserKeyDiskNumber = @UserKeyDiskNumber,UserKeyDiskName = @UserKeyDiskName,UserKeyDiskPassWord = @UserKeyDiskPassWord,UserID = @UserID,UserName = @UserName,Remark = @Remark");
            strSql.Append(" WHERE UserKeyDiskGrantID = @UserKeyDiskGrantID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboUserKeyDiskGrant SET ");
            strSql.Append("UserKeyDiskNumber = @UserKeyDiskNumber,UserKeyDiskName = @UserKeyDiskName,UserKeyDiskPassWord = @UserKeyDiskPassWord,UserID = @UserID,UserName = @UserName,Remark = @Remark");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.UserKeyDiskGrant WHERE UserKeyDiskGrantID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.UserKeyDiskGrant WHERE 1 = 1 {where}");

        public UserKeyDiskGrant GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.UserKeyDiskGrant WHERE UserKeyDiskGrantID = @key";
            return DbClient.Query<UserKeyDiskGrant>(strSql, new { key }).FirstOrDefault();
        }

        public List<UserKeyDiskGrant> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.UserKeyDiskGrant WHERE {where}";
            return DbClient.Query<UserKeyDiskGrant>(strSql).ToList();
        }

        public List<UserKeyDiskGrant> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.UserKeyDiskGrant ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.UserKeyDiskGrant WHERE {where};");
            return DbClient.Query<UserKeyDiskGrant>(strSql.ToString()).ToList();
        }

    }
}
