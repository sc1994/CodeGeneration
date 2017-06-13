using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ProjectsTypeDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ProjectsType WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ProjectsType WHERE {where};") > 0;

        public int Add(ProjectsType model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboProjectsType(");
             strSql.Append("ProjectTypeID,CustomerID,ProjectSupType,ProjectSubType,ProfessionArchiveName,Profession,ProfessionValue");
             strSql.Append(") VALUES (");
             strSql.Append("@ProjectTypeID,@CustomerID,@ProjectSupType,@ProjectSubType,@ProfessionArchiveName,@Profession,@ProfessionValue);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ProjectsType model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboProjectsType SET ");
            strSql.Append("CustomerID = @CustomerID,ProjectSupType = @ProjectSupType,ProjectSubType = @ProjectSubType,ProfessionArchiveName = @ProfessionArchiveName,Profession = @Profession,ProfessionValue = @ProfessionValue");
            strSql.Append(" WHERE ProjectTypeID = @ProjectTypeID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboProjectsType SET ");
            strSql.Append("CustomerID = @CustomerID,ProjectSupType = @ProjectSupType,ProjectSubType = @ProjectSubType,ProfessionArchiveName = @ProfessionArchiveName,Profession = @Profession,ProfessionValue = @ProfessionValue");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ProjectsType WHERE ProjectTypeID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ProjectsType WHERE 1 = 1 {where}");

        public ProjectsType GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ProjectsType WHERE ProjectTypeID = @key";
            return DbClient.Query<ProjectsType>(strSql, new { key }).FirstOrDefault();
        }

        public List<ProjectsType> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ProjectsType WHERE {where}";
            return DbClient.Query<ProjectsType>(strSql).ToList();
        }

        public List<ProjectsType> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ProjectsType ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ProjectsType WHERE {where};");
            return DbClient.Query<ProjectsType>(strSql.ToString()).ToList();
        }

    }
}
