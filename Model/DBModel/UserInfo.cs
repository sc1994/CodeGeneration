using System;

namespace Model
{
    public class UserInfo : BaseModel
    {
        public string PrimaryKey = "UserID";
        public string IdentityKey = "UserID";

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserNo { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 角色
        /// </summary>
        public int Roles { get; set; }

        /// <summary>
        /// 用户身份
        /// </summary>
        public int UserIdentity { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 刷新时间
        /// </summary>
        public DateTime RefreshTime { get; set; } = ToDateTime("('1900-1-1')");

        /// <summary>
        /// 微信号
        /// </summary>
        public string WinXinNo { get; set; } = string.Empty;

        /// <summary>
        /// 负责区域
        /// </summary>
        public string Areas { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Ticket { get; set; } = string.Empty;

    }


    public enum UserInfoEnum
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        UserID,
        /// <summary>
        /// 客户编号
        /// </summary>
        CustomerID,
        /// <summary>
        /// 用户编号
        /// </summary>
        UserNo,
        /// <summary>
        /// 用户名
        /// </summary>
        UserName,
        /// <summary>
        /// 密码
        /// </summary>
        Password,
        /// <summary>
        /// 角色
        /// </summary>
        Roles,
        /// <summary>
        /// 用户身份
        /// </summary>
        UserIdentity,
        /// <summary>
        /// 用户状态
        /// </summary>
        Status,
        /// <summary>
        /// 刷新时间
        /// </summary>
        RefreshTime,
        /// <summary>
        /// 微信号
        /// </summary>
        WinXinNo,
        /// <summary>
        /// 负责区域
        /// </summary>
        Areas,
        /// <summary>
        /// 
        /// </summary>
        Ticket,
    }
}
