using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class SubProfessionDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.SubProfession WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.SubProfession WHERE {where};") > 0;

        public int Add(SubProfession model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboSubProfession(");
            strSql.Append("SubProfessionID,SubProfession_Field,Profession");
            strSql.Append(") VALUES (");
            strSql.Append("@SubProfessionID,@SubProfession_Field,@Profession);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(SubProfession model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboSubProfession SET ");
            strSql.Append("SubProfession_Field = @SubProfession_Field,Profession = @Profession");
            strSql.Append(" WHERE SubProfessionID = @SubProfessionID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboSubProfession SET ");
            strSql.Append("SubProfession_Field = @SubProfession_Field,Profession = @Profession");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.SubProfession WHERE SubProfessionID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.SubProfession WHERE 1 = 1 {where}");

        public SubProfession GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.SubProfession WHERE SubProfessionID = @key";
            return DbClient.Query<SubProfession>(strSql, new { key }).FirstOrDefault();
        }

        public List<SubProfession> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.SubProfession WHERE {where}";
            return DbClient.Query<SubProfession>(strSql).ToList();
        }

        public List<SubProfession> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.SubProfession ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.SubProfession WHERE {where};");
            return DbClient.Query<SubProfession>(strSql.ToString()).ToList();
        }

    }
}
