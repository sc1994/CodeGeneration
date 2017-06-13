using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public partial class WaitHandleDal
    {
        public bool Exists(string primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.WaitHandle WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WaitHandle WHERE {where};") > 0;

        public string Add(WaitHandle model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboWaitHandle(");
             strSql.Append("ID,RowGuid,ShowTitle,ShowContent,TargetUser,TaskID,LinkUrl,CreateTime,IsShow,PlanFinishTime");
             strSql.Append(") VALUES (");
             strSql.Append("@ID,@RowGuid,@ShowTitle,@ShowContent,@TargetUser,@TaskID,@LinkUrl,@CreateTime,@IsShow,@PlanFinishTime);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<string>(strSql.ToString(), model);
        }

        public bool Update(WaitHandle model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWaitHandle SET ");
            strSql.Append("ShowTitle = @ShowTitle,ShowContent = @ShowContent,TargetUser = @TargetUser,TaskID = @TaskID,LinkUrl = @LinkUrl,CreateTime = @CreateTime,IsShow = @IsShow,PlanFinishTime = @PlanFinishTime");
            strSql.Append(" WHERE RowGuid = @RowGuid");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWaitHandle SET ");
            strSql.Append("ShowTitle = @ShowTitle,ShowContent = @ShowContent,TargetUser = @TargetUser,TaskID = @TaskID,LinkUrl = @LinkUrl,CreateTime = @CreateTime,IsShow = @IsShow,PlanFinishTime = @PlanFinishTime");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(string key)
        {
            var strSql = "DELETE FROM DJES.dbo.WaitHandle WHERE RowGuid = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.WaitHandle WHERE 1 = 1 {where}");

        public WaitHandle GetModel(string key)
        {
            var strSql = "SELECT * FROM DJES.dbo.WaitHandle WHERE RowGuid = @key";
            return DbClient.Query<WaitHandle>(strSql, new { key }).FirstOrDefault();
        }

        public List<WaitHandle> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.WaitHandle WHERE {where}";
            return DbClient.Query<WaitHandle>(strSql).ToList();
        }

        public List<WaitHandle> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.WaitHandle ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WaitHandle WHERE {where};");
            return DbClient.Query<WaitHandle>(strSql.ToString()).ToList();
        }

    }
}
