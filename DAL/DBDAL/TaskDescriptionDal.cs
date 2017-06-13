using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class TaskDescriptionDal
    {
        public bool Exists(string primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.TaskDescription WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.TaskDescription WHERE {where};") > 0;

        public string Add(TaskDescription model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboTaskDescription(");
             strSql.Append("RowID,RowGuid,Creator,CreateDate,OperateType,Description,TaskID,IsShow,UpdateTime");
             strSql.Append(") VALUES (");
             strSql.Append("@RowID,@RowGuid,@Creator,@CreateDate,@OperateType,@Description,@TaskID,@IsShow,@UpdateTime);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<string>(strSql.ToString(), model);
        }

        public bool Update(TaskDescription model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboTaskDescription SET ");
            strSql.Append("Creator = @Creator,CreateDate = @CreateDate,OperateType = @OperateType,Description = @Description,TaskID = @TaskID,IsShow = @IsShow,UpdateTime = @UpdateTime");
            strSql.Append(" WHERE RowGuid = @RowGuid");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboTaskDescription SET ");
            strSql.Append("Creator = @Creator,CreateDate = @CreateDate,OperateType = @OperateType,Description = @Description,TaskID = @TaskID,IsShow = @IsShow,UpdateTime = @UpdateTime");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(string key)
        {
            var strSql = "DELETE FROM DJES.dbo.TaskDescription WHERE RowGuid = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.TaskDescription WHERE 1 = 1 {where}");

        public TaskDescription GetModel(string key)
        {
            var strSql = "SELECT * FROM DJES.dbo.TaskDescription WHERE RowGuid = @key";
            return DbClient.Query<TaskDescription>(strSql, new { key }).FirstOrDefault();
        }

        public List<TaskDescription> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.TaskDescription WHERE {where}";
            return DbClient.Query<TaskDescription>(strSql).ToList();
        }

        public List<TaskDescription> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.TaskDescription ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.TaskDescription WHERE {where};");
            return DbClient.Query<TaskDescription>(strSql.ToString()).ToList();
        }

    }
}
