using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class EmployeesDal
    {
        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.Employees WHERE {where};") > 0;

        public void Add(Employees model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboEmployees(");
            strSql.Append("EmployeeID,EmployeeCode,EmployeeName,Mobile,Telephone,Email,EmployeeContent,Department,Post,Photo,EmployeeRoles,IdCard,Employeesign");
            strSql.Append(") VALUES (");
            strSql.Append("@EmployeeID,@EmployeeCode,@EmployeeName,@Mobile,@Telephone,@Email,@EmployeeContent,@Department,@Post,@Photo,@EmployeeRoles,@IdCard,@Employeesign);");
            DbClient.Excute(strSql.ToString(), model);
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboEmployees SET ");
            strSql.Append("EmployeeID = @EmployeeID,EmployeeCode = @EmployeeCode,EmployeeName = @EmployeeName,Mobile = @Mobile,Telephone = @Telephone,Email = @Email,EmployeeContent = @EmployeeContent,Department = @Department,Post = @Post,Photo = @Photo,EmployeeRoles = @EmployeeRoles,IdCard = @IdCard,Employeesign = @Employeesign");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.Employees WHERE 1 = 1 {where}");

        public List<Employees> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.Employees WHERE {where}";
            return DbClient.Query<Employees>(strSql).ToList();
        }

        public List<Employees> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.Employees ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.Employees WHERE {where};");
            return DbClient.Query<Employees>(strSql.ToString()).ToList();
        }

    }
}
