using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class RegionInfoDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.RegionInfo WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RegionInfo WHERE {where};") > 0;

        public int Add(RegionInfo model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboRegionInfo(");
             strSql.Append("RegionID,RegionName,RegionNo,Sfld,Sffz,dzjsd");
             strSql.Append(") VALUES (");
             strSql.Append("@RegionID,@RegionName,@RegionNo,@Sfld,@Sffz,@dzjsd);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(RegionInfo model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRegionInfo SET ");
            strSql.Append("RegionName = @RegionName,RegionNo = @RegionNo,Sfld = @Sfld,Sffz = @Sffz,dzjsd = @dzjsd");
            strSql.Append(" WHERE RegionID = @RegionID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboRegionInfo SET ");
            strSql.Append("RegionName = @RegionName,RegionNo = @RegionNo,Sfld = @Sfld,Sffz = @Sffz,dzjsd = @dzjsd");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.RegionInfo WHERE RegionID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.RegionInfo WHERE 1 = 1 {where}");

        public RegionInfo GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.RegionInfo WHERE RegionID = @key";
            return DbClient.Query<RegionInfo>(strSql, new { key }).FirstOrDefault();
        }

        public List<RegionInfo> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.RegionInfo WHERE {where}";
            return DbClient.Query<RegionInfo>(strSql).ToList();
        }

        public List<RegionInfo> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.RegionInfo ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.RegionInfo WHERE {where};");
            return DbClient.Query<RegionInfo>(strSql.ToString()).ToList();
        }

    }
}
