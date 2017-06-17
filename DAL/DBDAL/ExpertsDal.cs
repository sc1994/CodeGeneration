using System.Collections.Generic;
using System.Linq;
using Model.DBModel;
using System.Text;

namespace DAL.DBDAL
{
    public partial class ExpertsDal
    {
        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.Experts WHERE {where};") > 0;

        public void Add(Experts model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboExperts(");
            strSql.Append("ExpertCode,ExpertName,Mobile,Telephone,Email,CertificateID,Profession,PersonalIntroduction,RoomNum,Photo,ExpertType,IdCard,Expertsign");
            strSql.Append(") VALUES (");
            strSql.Append("@ExpertCode,@ExpertName,@Mobile,@Telephone,@Email,@CertificateID,@Profession,@PersonalIntroduction,@RoomNum,@Photo,@ExpertType,@IdCard,@Expertsign);");
            DbClient.Excute(strSql.ToString(), model);
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboExperts SET ");
            strSql.Append("ExpertCode = @ExpertCode,ExpertName = @ExpertName,Mobile = @Mobile,Telephone = @Telephone,Email = @Email,CertificateID = @CertificateID,Profession = @Profession,PersonalIntroduction = @PersonalIntroduction,RoomNum = @RoomNum,Photo = @Photo,ExpertType = @ExpertType,IdCard = @IdCard,Expertsign = @Expertsign");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.Experts WHERE 1 = 1 {where}");

        public List<Experts> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.Experts WHERE {where}";
            return DbClient.Query<Experts>(strSql).ToList();
        }

        public List<Experts> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.Experts ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.Experts WHERE {where};");
            return DbClient.Query<Experts>(strSql.ToString()).ToList();
        }

    }
}
