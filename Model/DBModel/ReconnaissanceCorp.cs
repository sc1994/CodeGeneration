using System;

namespace Model
{
    public class ReconnaissanceCorp : BaseModel
    {
        public static string PrimaryKey = "CorpID";
        public static string IdentityKey = "CorpID";

        /// <summary>
        /// 单位ID
        /// </summary>
        public int CorpID { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string CorpName { get; set; } = string.Empty;

        /// <summary>
        /// 资质等级
        /// </summary>
        public string CorpGrade { get; set; } = string.Empty;

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactPerson { get; set; } = string.Empty;

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactPersonTel { get; set; } = string.Empty;

        /// <summary>
        /// 所属区域
        /// </summary>
        public string CorpRegion { get; set; } = string.Empty;

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrganizationCode { get; set; } = string.Empty;

        /// <summary>
        /// 资质证书号
        /// </summary>
        public string CertificateNo { get; set; } = string.Empty;

        /// <summary>
        /// 法定代表人
        /// </summary>
        public string LegalPerson { get; set; } = string.Empty;

        /// <summary>
        /// 法定代表人职务
        /// </summary>
        public string LegalPersonPosition { get; set; } = string.Empty;

        /// <summary>
        /// 单位地址
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Postcode { get; set; } = string.Empty;

        /// <summary>
        /// 企业上级主管
        /// </summary>
        public string Supervisor { get; set; } = string.Empty;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelePhone { get; set; } = string.Empty;

        /// <summary>
        /// 所属省份
        /// </summary>
        public string Provinces { get; set; } = string.Empty;

        /// <summary>
        /// 所属地市
        /// </summary>
        public string Cities { get; set; } = string.Empty;

        /// <summary>
        /// 所属区县
        /// </summary>
        public string District { get; set; } = string.Empty;

        /// <summary>
        /// 最早成立时间
        /// </summary>
        public DateTime EstablishedTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 工商注册时间
        /// </summary>
        public DateTime RegisteredTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 注册资本
        /// </summary>
        public int RegisteredCapital { get; set; }

        /// <summary>
        /// 营业执照注册号
        /// </summary>
        public string RegistrationNumber { get; set; } = string.Empty;

        /// <summary>
        /// 企业类型
        /// </summary>
        public string BusinessType { get; set; } = string.Empty;

        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// 种子
        /// </summary>
        public string Seed { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;

    }


    public enum ReconnaissanceCorpEnum
    {
        /// <summary>
        /// 单位ID
        /// </summary>
        CorpID,
        /// <summary>
        /// 单位名称
        /// </summary>
        CorpName,
        /// <summary>
        /// 资质等级
        /// </summary>
        CorpGrade,
        /// <summary>
        /// 联系人
        /// </summary>
        ContactPerson,
        /// <summary>
        /// 联系人电话
        /// </summary>
        ContactPersonTel,
        /// <summary>
        /// 所属区域
        /// </summary>
        CorpRegion,
        /// <summary>
        /// 组织机构代码
        /// </summary>
        OrganizationCode,
        /// <summary>
        /// 资质证书号
        /// </summary>
        CertificateNo,
        /// <summary>
        /// 法定代表人
        /// </summary>
        LegalPerson,
        /// <summary>
        /// 法定代表人职务
        /// </summary>
        LegalPersonPosition,
        /// <summary>
        /// 单位地址
        /// </summary>
        Address,
        /// <summary>
        /// 邮政编码
        /// </summary>
        Postcode,
        /// <summary>
        /// 企业上级主管
        /// </summary>
        Supervisor,
        /// <summary>
        /// 联系电话
        /// </summary>
        TelePhone,
        /// <summary>
        /// 所属省份
        /// </summary>
        Provinces,
        /// <summary>
        /// 所属地市
        /// </summary>
        Cities,
        /// <summary>
        /// 所属区县
        /// </summary>
        District,
        /// <summary>
        /// 最早成立时间
        /// </summary>
        EstablishedTime,
        /// <summary>
        /// 工商注册时间
        /// </summary>
        RegisteredTime,
        /// <summary>
        /// 注册资本
        /// </summary>
        RegisteredCapital,
        /// <summary>
        /// 营业执照注册号
        /// </summary>
        RegistrationNumber,
        /// <summary>
        /// 企业类型
        /// </summary>
        BusinessType,
        /// <summary>
        /// 令牌
        /// </summary>
        Token,
        /// <summary>
        /// 种子
        /// </summary>
        Seed,
        /// <summary>
        /// 备注
        /// </summary>
        Remark,
    }
}
