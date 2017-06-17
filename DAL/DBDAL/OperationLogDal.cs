using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class OperationLogDal
    {
        public bool Exists(long primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.OperationLog WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.OperationLog WHERE {where};") > 0;

        public long Add(OperationLog model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboOperationLog(");
            strSql.Append("LogType,LogTitle,LogMessage,LogRecorder,LogFavoree,LogStatus,LogStatusDescribe,LogCreationTime");
            strSql.Append(") VALUES (");
            strSql.Append("@LogType,@LogTitle,@LogMessage,@LogRecorder,@LogFavoree,@LogStatus,@LogStatusDescribe,@LogCreationTime);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<long>(strSql.ToString(), model);
        }

        public bool Update(OperationLog model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboOperationLog SET ");
            strSql.Append("LogType = @LogType,LogTitle = @LogTitle,LogMessage = @LogMessage,LogRecorder = @LogRecorder,LogFavoree = @LogFavoree,LogStatus = @LogStatus,LogStatusDescribe = @LogStatusDescribe,LogCreationTime = @LogCreationTime");
            strSql.Append(" WHERE LogId = @LogId");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboOperationLog SET ");
            strSql.Append("LogType = @LogType,LogTitle = @LogTitle,LogMessage = @LogMessage,LogRecorder = @LogRecorder,LogFavoree = @LogFavoree,LogStatus = @LogStatus,LogStatusDescribe = @LogStatusDescribe,LogCreationTime = @LogCreationTime");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(long key)
        {
            var strSql = "DELETE FROM DJES.dbo.OperationLog WHERE LogId = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.OperationLog WHERE 1 = 1 {where}");

        public OperationLog GetModel(long key)
        {
            var strSql = "SELECT * FROM DJES.dbo.OperationLog WHERE LogId = @key";
            return DbClient.Query<OperationLog>(strSql, new { key }).FirstOrDefault();
        }

        public List<OperationLog> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.OperationLog WHERE {where}";
            return DbClient.Query<OperationLog>(strSql).ToList();
        }

        public List<OperationLog> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.OperationLog ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.OperationLog WHERE {where};");
            return DbClient.Query<OperationLog>(strSql.ToString()).ToList();
        }

    }
}
