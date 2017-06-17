using System;

namespace Model.DBModel
{
    public class ConstructionCorp : BaseModel
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
        /// 联系人
        /// </summary>
        public string ContactPerson { get; set; } = string.Empty;

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactPersonTel { get; set; } = string.Empty;

        /// <summary>
        /// 建设单位微信号
        /// </summary>
        public string WinXinNo { get; set; } = string.Empty;

        /// <summary>
        /// 代码证
        /// </summary>
        public string OrganizationCode { get; set; } = string.Empty;

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 状态
        /// </summary>
        public int CorpStatus { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime RegisterDate { get; set; } = ToDateTime("1900-01-01");

    }


    public enum ConstructionCorpEnum
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
        /// 联系人
        /// </summary>
        ContactPerson,
        /// <summary>
        /// 联系人电话
        /// </summary>
        ContactPersonTel,
        /// <summary>
        /// 建设单位微信号
        /// </summary>
        WinXinNo,
        /// <summary>
        /// 代码证
        /// </summary>
        OrganizationCode,
        /// <summary>
        /// 登录密码
        /// </summary>
        Password,
        /// <summary>
        /// 状态
        /// </summary>
        CorpStatus,
        /// <summary>
        /// 注册日期
        /// </summary>
        RegisterDate,
    }
}
