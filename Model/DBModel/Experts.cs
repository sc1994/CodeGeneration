using System;

namespace Model
{
    public class Experts : BaseModel
    {
        public static string PrimaryKey = "";
        public static string IdentityKey = "";

        /// <summary>
        /// 专家编号
        /// </summary>
        public int ExpertCode { get; set; }

        /// <summary>
        /// 专家姓名
        /// </summary>
        public string ExpertName { get; set; } = string.Empty;

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Telephone { get; set; } = string.Empty;

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 认定证书号
        /// </summary>
        public string CertificateID { get; set; } = string.Empty;

        /// <summary>
        /// 审查专业(CensorProfession表)
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 简介
        /// </summary>
        public string PersonalIntroduction { get; set; } = string.Empty;

        /// <summary>
        /// 门牌号
        /// </summary>
        public string RoomNum { get; set; } = string.Empty;

        /// <summary>
        /// 图片
        /// </summary>
        public object Photo { get; set; } = new object();

        /// <summary>
        /// 专家类型
        /// </summary>
        public string ExpertType { get; set; } = string.Empty;

        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCard { get; set; } = string.Empty;

        /// <summary>
        /// 专家签名
        /// </summary>
        public string Expertsign { get; set; } = string.Empty;

    }


    public enum ExpertsEnum
    {
        /// <summary>
        /// 专家编号
        /// </summary>
        ExpertCode,
        /// <summary>
        /// 专家姓名
        /// </summary>
        ExpertName,
        /// <summary>
        /// 手机号码
        /// </summary>
        Mobile,
        /// <summary>
        /// 电话号码
        /// </summary>
        Telephone,
        /// <summary>
        /// 邮箱
        /// </summary>
        Email,
        /// <summary>
        /// 认定证书号
        /// </summary>
        CertificateID,
        /// <summary>
        /// 审查专业(CensorProfession表)
        /// </summary>
        Profession,
        /// <summary>
        /// 简介
        /// </summary>
        PersonalIntroduction,
        /// <summary>
        /// 门牌号
        /// </summary>
        RoomNum,
        /// <summary>
        /// 图片
        /// </summary>
        Photo,
        /// <summary>
        /// 专家类型
        /// </summary>
        ExpertType,
        /// <summary>
        /// 身份证
        /// </summary>
        IdCard,
        /// <summary>
        /// 专家签名
        /// </summary>
        Expertsign,
    }
}
