using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class DesignCorpEmployeesDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.DesignCorpEmployees WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.DesignCorpEmployees WHERE {where};") > 0;

        public int Add(DesignCorpEmployees model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboDesignCorpEmployees(");
            strSql.Append("DCEID,DCECorpID,DCEName,DCEProfession,DCERegisterSN,DCEType");
            strSql.Append(") VALUES (");
            strSql.Append("@DCEID,@DCECorpID,@DCEName,@DCEProfession,@DCERegisterSN,@DCEType);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(DesignCorpEmployees model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDesignCorpEmployees SET ");
            strSql.Append("DCECorpID = @DCECorpID,DCEName = @DCEName,DCEProfession = @DCEProfession,DCERegisterSN = @DCERegisterSN,DCEType = @DCEType");
            strSql.Append(" WHERE DCEID = @DCEID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDesignCorpEmployees SET ");
            strSql.Append("DCECorpID = @DCECorpID,DCEName = @DCEName,DCEProfession = @DCEProfession,DCERegisterSN = @DCERegisterSN,DCEType = @DCEType");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.DesignCorpEmployees WHERE DCEID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.DesignCorpEmployees WHERE 1 = 1 {where}");

        public DesignCorpEmployees GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.DesignCorpEmployees WHERE DCEID = @key";
            return DbClient.Query<DesignCorpEmployees>(strSql, new { key }).FirstOrDefault();
        }

        public List<DesignCorpEmployees> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.DesignCorpEmployees WHERE {where}";
            return DbClient.Query<DesignCorpEmployees>(strSql).ToList();
        }

        public List<DesignCorpEmployees> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.DesignCorpEmployees ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.DesignCorpEmployees WHERE {where};");
            return DbClient.Query<DesignCorpEmployees>(strSql.ToString()).ToList();
        }

    }
}
