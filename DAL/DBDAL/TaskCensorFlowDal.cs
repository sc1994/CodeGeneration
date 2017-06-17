using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class TaskCensorFlowDal
    {
        public bool Exists(string primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.TaskCensorFlow WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.TaskCensorFlow WHERE {where};") > 0;

        public string Add(TaskCensorFlow model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboTaskCensorFlow(");
            strSql.Append("RowGuid,TaskID,OperationNode,OperationItem,OperationMan,OperationDate,OperationDuration,IsOverTime,Description");
            strSql.Append(") VALUES (");
            strSql.Append("@RowGuid,@TaskID,@OperationNode,@OperationItem,@OperationMan,@OperationDate,@OperationDuration,@IsOverTime,@Description);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<string>(strSql.ToString(), model);
        }

        public bool Update(TaskCensorFlow model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboTaskCensorFlow SET ");
            strSql.Append("TaskID = @TaskID,OperationNode = @OperationNode,OperationItem = @OperationItem,OperationMan = @OperationMan,OperationDate = @OperationDate,OperationDuration = @OperationDuration,IsOverTime = @IsOverTime,Description = @Description");
            strSql.Append(" WHERE RowGuid = @RowGuid");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboTaskCensorFlow SET ");
            strSql.Append("TaskID = @TaskID,OperationNode = @OperationNode,OperationItem = @OperationItem,OperationMan = @OperationMan,OperationDate = @OperationDate,OperationDuration = @OperationDuration,IsOverTime = @IsOverTime,Description = @Description");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(string key)
        {
            var strSql = "DELETE FROM DJES.dbo.TaskCensorFlow WHERE RowGuid = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.TaskCensorFlow WHERE 1 = 1 {where}");

        public TaskCensorFlow GetModel(string key)
        {
            var strSql = "SELECT * FROM DJES.dbo.TaskCensorFlow WHERE RowGuid = @key";
            return DbClient.Query<TaskCensorFlow>(strSql, new { key }).FirstOrDefault();
        }

        public List<TaskCensorFlow> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.TaskCensorFlow WHERE {where}";
            return DbClient.Query<TaskCensorFlow>(strSql).ToList();
        }

        public List<TaskCensorFlow> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.TaskCensorFlow ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.TaskCensorFlow WHERE {where};");
            return DbClient.Query<TaskCensorFlow>(strSql.ToString()).ToList();
        }

    }
}
