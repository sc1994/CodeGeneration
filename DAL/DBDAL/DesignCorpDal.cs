using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class DesignCorpDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.DesignCorp WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.DesignCorp WHERE {where};") > 0;

        public int Add(DesignCorp model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboDesignCorp(");
             strSql.Append("CorpID,CorpName,CorpGrade,ContactPerson,ContactPersonTel,CorpRegion,OrganizationCode,CertificateNo,LegalPerson,LegalPersonPosition,Address,Postcode,Supervisor,TelePhone,Provinces,Cities,District,EstablishedTime,RegisteredTime,RegisteredCapital,RegistrationNumber,BusinessType,Token,Seed,Remark");
             strSql.Append(") VALUES (");
             strSql.Append("@CorpID,@CorpName,@CorpGrade,@ContactPerson,@ContactPersonTel,@CorpRegion,@OrganizationCode,@CertificateNo,@LegalPerson,@LegalPersonPosition,@Address,@Postcode,@Supervisor,@TelePhone,@Provinces,@Cities,@District,@EstablishedTime,@RegisteredTime,@RegisteredCapital,@RegistrationNumber,@BusinessType,@Token,@Seed,@Remark);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(DesignCorp model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDesignCorp SET ");
            strSql.Append("CorpName = @CorpName,CorpGrade = @CorpGrade,ContactPerson = @ContactPerson,ContactPersonTel = @ContactPersonTel,CorpRegion = @CorpRegion,OrganizationCode = @OrganizationCode,CertificateNo = @CertificateNo,LegalPerson = @LegalPerson,LegalPersonPosition = @LegalPersonPosition,Address = @Address,Postcode = @Postcode,Supervisor = @Supervisor,TelePhone = @TelePhone,Provinces = @Provinces,Cities = @Cities,District = @District,EstablishedTime = @EstablishedTime,RegisteredTime = @RegisteredTime,RegisteredCapital = @RegisteredCapital,RegistrationNumber = @RegistrationNumber,BusinessType = @BusinessType,Token = @Token,Seed = @Seed,Remark = @Remark");
            strSql.Append(" WHERE CorpID = @CorpID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboDesignCorp SET ");
            strSql.Append("CorpName = @CorpName,CorpGrade = @CorpGrade,ContactPerson = @ContactPerson,ContactPersonTel = @ContactPersonTel,CorpRegion = @CorpRegion,OrganizationCode = @OrganizationCode,CertificateNo = @CertificateNo,LegalPerson = @LegalPerson,LegalPersonPosition = @LegalPersonPosition,Address = @Address,Postcode = @Postcode,Supervisor = @Supervisor,TelePhone = @TelePhone,Provinces = @Provinces,Cities = @Cities,District = @District,EstablishedTime = @EstablishedTime,RegisteredTime = @RegisteredTime,RegisteredCapital = @RegisteredCapital,RegistrationNumber = @RegistrationNumber,BusinessType = @BusinessType,Token = @Token,Seed = @Seed,Remark = @Remark");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.DesignCorp WHERE CorpID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.DesignCorp WHERE 1 = 1 {where}");

        public DesignCorp GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.DesignCorp WHERE CorpID = @key";
            return DbClient.Query<DesignCorp>(strSql, new { key }).FirstOrDefault();
        }

        public List<DesignCorp> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.DesignCorp WHERE {where}";
            return DbClient.Query<DesignCorp>(strSql).ToList();
        }

        public List<DesignCorp> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.DesignCorp ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.DesignCorp WHERE {where};");
            return DbClient.Query<DesignCorp>(strSql.ToString()).ToList();
        }

    }
}
