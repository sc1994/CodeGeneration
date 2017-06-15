using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class ModuleDal
    {
        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.Module WHERE {where};") > 0;

        public void Add(Module model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboModule(");
            strSql.Append("ModuleId,ModuleName,ModuleURL,ModuleImage,ParementModuleID,Sequence,Roles,EmployeeRoles");
            strSql.Append(") VALUES (");
            strSql.Append("@ModuleId,@ModuleName,@ModuleURL,@ModuleImage,@ParementModuleID,@Sequence,@Roles,@EmployeeRoles);");
            DbClient.Excute(strSql.ToString(), model);
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboModule SET ");
            strSql.Append("ModuleId = @ModuleId,ModuleName = @ModuleName,ModuleURL = @ModuleURL,ModuleImage = @ModuleImage,ParementModuleID = @ParementModuleID,Sequence = @Sequence,Roles = @Roles,EmployeeRoles = @EmployeeRoles");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.Module WHERE 1 = 1 {where}");

        public List<Module> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.Module WHERE {where}";
            return DbClient.Query<Module>(strSql).ToList();
        }

        public List<Module> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.Module ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.Module WHERE {where};");
            return DbClient.Query<Module>(strSql.ToString()).ToList();
        }

    }
}
