using System;

namespace Model.DBModel
{
    public class CustomerInfo : BaseModel
    {
        public static string PrimaryKey = "";
        public static string IdentityKey = "";

        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// 客户显示名称
        /// </summary>
        public string DisplayCustomerName { get; set; } = string.Empty;

        /// <summary>
        /// 客户类型
        /// </summary>
        public string CustomerType { get; set; } = string.Empty;

        /// <summary>
        /// 部门类型
        /// </summary>
        public int CustomerTypeCode { get; set; }

        /// <summary>
        /// 省系统登录密码
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 开户行
        /// </summary>
        public string Bank { get; set; } = string.Empty;

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 网址
        /// </summary>
        public string Website { get; set; } = string.Empty;

        /// <summary>
        /// 机构组织机构代码
        /// </summary>
        public string Jgzzjgdm { get; set; } = string.Empty;

        /// <summary>
        /// 机构认定证书号
        /// </summary>
        public string Jgrdzsh { get; set; } = string.Empty;

        /// <summary>
        /// 初设批准机关
        /// </summary>
        public string Cspzjg { get; set; } = string.Empty;

        /// <summary>
        /// 批准文号
        /// </summary>
        public string Pzwh { get; set; } = string.Empty;

        /// <summary>
        /// 批准日期
        /// </summary>
        public DateTime Pzrq { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 机构类型
        /// </summary>
        public string Jglx { get; set; } = string.Empty;

        /// <summary>
        /// LOGO
        /// </summary>
        public string Logo { get; set; } = string.Empty;

        /// <summary>
        /// 有效日期
        /// </summary>
        public DateTime ValidDay { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 客户状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 最低收费额
        /// </summary>
        public decimal MinChargeAmount { get; set; }

        /// <summary>
        /// 优惠限额
        /// </summary>
        public decimal PreferentialQuota { get; set; }

        /// <summary>
        /// 优惠限额折扣
        /// </summary>
        public decimal PreferentialDiscount { get; set; }

        /// <summary>
        /// 最高收费额
        /// </summary>
        public decimal MaxChargeAmount { get; set; }

        /// <summary>
        /// 微信图片
        /// </summary>
        public string WeiXinPicture { get; set; } = string.Empty;

        /// <summary>
        /// 友情提醒
        /// </summary>
        public string Remind { get; set; } = string.Empty;

        /// <summary>
        /// 微信上用
        /// </summary>
        public string AppId { get; set; } = string.Empty;

        /// <summary>
        /// 微信上用
        /// </summary>
        public string AppSecret { get; set; } = string.Empty;

        /// <summary>
        /// 微信上用
        /// </summary>
        public string AppToken { get; set; } = string.Empty;

        /// <summary>
        /// 微信上用
        /// </summary>
        public string AppEncodingAesKey { get; set; } = string.Empty;

        /// <summary>
        /// 合格证抬头
        /// </summary>
        public string ConstructHeading { get; set; } = string.Empty;

        /// <summary>
        /// 抗震证书抬头
        /// </summary>
        public string SeismicHeading { get; set; } = string.Empty;

        /// <summary>
        /// 短信接口地址
        /// </summary>
        public string Message_POST_URL { get; set; } = string.Empty;

        /// <summary>
        /// 短信接口账号
        /// </summary>
        public string Message_ACCOUNT { get; set; } = string.Empty;

        /// <summary>
        /// 短信接口密钥
        /// </summary>
        public string Message_AUTHKEY { get; set; } = string.Empty;

        /// <summary>
        /// 短信通道组编号
        /// </summary>
        public int Message_CGID { get; set; }

        /// <summary>
        /// 微信企业号
        /// </summary>
        public string WX_CorpId { get; set; } = string.Empty;

        /// <summary>
        /// 微信企业号
        /// </summary>
        public string WX_CorpSecret { get; set; } = string.Empty;

        /// <summary>
        /// 微信企业号
        /// </summary>
        public string WX_CorpToken { get; set; } = string.Empty;

        /// <summary>
        /// 微信企业号
        /// </summary>
        public string WX_EncodingAESKey { get; set; } = string.Empty;

        /// <summary>
        /// 微信企业号
        /// </summary>
        public string WX_Agentid { get; set; } = string.Empty;

        /// <summary>
        /// 签章服务器地址
        /// </summary>
        public string SignatureServer { get; set; } = string.Empty;

    }


    public enum CustomerInfoEnum
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        CustomerID,
        /// <summary>
        /// 客户名称
        /// </summary>
        CustomerName,
        /// <summary>
        /// 客户显示名称
        /// </summary>
        DisplayCustomerName,
        /// <summary>
        /// 客户类型
        /// </summary>
        CustomerType,
        /// <summary>
        /// 部门类型
        /// </summary>
        CustomerTypeCode,
        /// <summary>
        /// 省系统登录密码
        /// </summary>
        Password,
        /// <summary>
        /// 开户行
        /// </summary>
        Bank,
        /// <summary>
        /// 账号
        /// </summary>
        Account,
        /// <summary>
        /// 网址
        /// </summary>
        Website,
        /// <summary>
        /// 机构组织机构代码
        /// </summary>
        Jgzzjgdm,
        /// <summary>
        /// 机构认定证书号
        /// </summary>
        Jgrdzsh,
        /// <summary>
        /// 初设批准机关
        /// </summary>
        Cspzjg,
        /// <summary>
        /// 批准文号
        /// </summary>
        Pzwh,
        /// <summary>
        /// 批准日期
        /// </summary>
        Pzrq,
        /// <summary>
        /// 机构类型
        /// </summary>
        Jglx,
        /// <summary>
        /// LOGO
        /// </summary>
        Logo,
        /// <summary>
        /// 有效日期
        /// </summary>
        ValidDay,
        /// <summary>
        /// 客户状态
        /// </summary>
        Status,
        /// <summary>
        /// 最低收费额
        /// </summary>
        MinChargeAmount,
        /// <summary>
        /// 优惠限额
        /// </summary>
        PreferentialQuota,
        /// <summary>
        /// 优惠限额折扣
        /// </summary>
        PreferentialDiscount,
        /// <summary>
        /// 最高收费额
        /// </summary>
        MaxChargeAmount,
        /// <summary>
        /// 微信图片
        /// </summary>
        WeiXinPicture,
        /// <summary>
        /// 友情提醒
        /// </summary>
        Remind,
        /// <summary>
        /// 微信上用
        /// </summary>
        AppId,
        /// <summary>
        /// 微信上用
        /// </summary>
        AppSecret,
        /// <summary>
        /// 微信上用
        /// </summary>
        AppToken,
        /// <summary>
        /// 微信上用
        /// </summary>
        AppEncodingAesKey,
        /// <summary>
        /// 合格证抬头
        /// </summary>
        ConstructHeading,
        /// <summary>
        /// 抗震证书抬头
        /// </summary>
        SeismicHeading,
        /// <summary>
        /// 短信接口地址
        /// </summary>
        Message_POST_URL,
        /// <summary>
        /// 短信接口账号
        /// </summary>
        Message_ACCOUNT,
        /// <summary>
        /// 短信接口密钥
        /// </summary>
        Message_AUTHKEY,
        /// <summary>
        /// 短信通道组编号
        /// </summary>
        Message_CGID,
        /// <summary>
        /// 微信企业号
        /// </summary>
        WX_CorpId,
        /// <summary>
        /// 微信企业号
        /// </summary>
        WX_CorpSecret,
        /// <summary>
        /// 微信企业号
        /// </summary>
        WX_CorpToken,
        /// <summary>
        /// 微信企业号
        /// </summary>
        WX_EncodingAESKey,
        /// <summary>
        /// 微信企业号
        /// </summary>
        WX_Agentid,
        /// <summary>
        /// 签章服务器地址
        /// </summary>
        SignatureServer,
    }
}
