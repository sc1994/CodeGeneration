using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class ConfigTableDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ConfigTable WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ConfigTable WHERE {where};") > 0;

        public int Add(ConfigTable model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboConfigTable(");
            strSql.Append("ID,ConfigType,Text,Value,ConfigOrder,Remarks");
            strSql.Append(") VALUES (");
            strSql.Append("@ID,@ConfigType,@Text,@Value,@ConfigOrder,@Remarks);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ConfigTable model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboConfigTable SET ");
            strSql.Append("ConfigType = @ConfigType,Text = @Text,Value = @Value,ConfigOrder = @ConfigOrder,Remarks = @Remarks");
            strSql.Append(" WHERE ID = @ID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboConfigTable SET ");
            strSql.Append("ConfigType = @ConfigType,Text = @Text,Value = @Value,ConfigOrder = @ConfigOrder,Remarks = @Remarks");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ConfigTable WHERE ID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ConfigTable WHERE 1 = 1 {where}");

        public ConfigTable GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ConfigTable WHERE ID = @key";
            return DbClient.Query<ConfigTable>(strSql, new { key }).FirstOrDefault();
        }

        public List<ConfigTable> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ConfigTable WHERE {where}";
            return DbClient.Query<ConfigTable>(strSql).ToList();
        }

        public List<ConfigTable> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ConfigTable ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ConfigTable WHERE {where};");
            return DbClient.Query<ConfigTable>(strSql.ToString()).ToList();
        }

    }
}
