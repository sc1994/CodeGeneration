using System;

namespace Model
{
    public class DesignCorp : BaseModel
    {
        public static string PrimaryKey = "CorpID";
        public static string IdentityKey = "CorpID";

        /// <summary>
        /// 
        /// </summary>
        public int CorpID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CorpName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string CorpGrade { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ContactPerson { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ContactPersonTel { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string CorpRegion { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string OrganizationCode { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string CertificateNo { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string LegalPerson { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string LegalPersonPosition { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Postcode { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Supervisor { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string TelePhone { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Provinces { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Cities { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string District { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime EstablishedTime { get; set; } = ToDateTime("('1900-1-1')");

        /// <summary>
        /// 
        /// </summary>
        public DateTime RegisteredTime { get; set; } = ToDateTime("('1900-1-1')");

        /// <summary>
        /// 
        /// </summary>
        public int RegisteredCapital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RegistrationNumber { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string BusinessType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Seed { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Remark { get; set; } = string.Empty;

    }


    public enum DesignCorpEnum
    {
        /// <summary>
        /// 
        /// </summary>
        CorpID,
        /// <summary>
        /// 
        /// </summary>
        CorpName,
        /// <summary>
        /// 
        /// </summary>
        CorpGrade,
        /// <summary>
        /// 
        /// </summary>
        ContactPerson,
        /// <summary>
        /// 
        /// </summary>
        ContactPersonTel,
        /// <summary>
        /// 
        /// </summary>
        CorpRegion,
        /// <summary>
        /// 
        /// </summary>
        OrganizationCode,
        /// <summary>
        /// 
        /// </summary>
        CertificateNo,
        /// <summary>
        /// 
        /// </summary>
        LegalPerson,
        /// <summary>
        /// 
        /// </summary>
        LegalPersonPosition,
        /// <summary>
        /// 
        /// </summary>
        Address,
        /// <summary>
        /// 
        /// </summary>
        Postcode,
        /// <summary>
        /// 
        /// </summary>
        Supervisor,
        /// <summary>
        /// 
        /// </summary>
        TelePhone,
        /// <summary>
        /// 
        /// </summary>
        Provinces,
        /// <summary>
        /// 
        /// </summary>
        Cities,
        /// <summary>
        /// 
        /// </summary>
        District,
        /// <summary>
        /// 
        /// </summary>
        EstablishedTime,
        /// <summary>
        /// 
        /// </summary>
        RegisteredTime,
        /// <summary>
        /// 
        /// </summary>
        RegisteredCapital,
        /// <summary>
        /// 
        /// </summary>
        RegistrationNumber,
        /// <summary>
        /// 
        /// </summary>
        BusinessType,
        /// <summary>
        /// 
        /// </summary>
        Token,
        /// <summary>
        /// 
        /// </summary>
        Seed,
        /// <summary>
        /// 
        /// </summary>
        Remark,
    }
}
