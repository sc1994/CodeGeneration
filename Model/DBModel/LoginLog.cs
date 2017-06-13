using System;

namespace Model
{
    public class LoginLog : BaseModel
    {
        public static string PrimaryKey = "ID";
        public static string IdentityKey = "ID";

        /// <summary>
        /// 
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 登录Ip
        /// </summary>
        public string LogIP { get; set; } = string.Empty;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime CreateTime { get; set; } = ToDateTime("");

        /// <summary>
        /// 记录类型0登录 1退出
        /// </summary>
        public int LogType { get; set; }

    }


    public enum LoginLogEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ID,
        /// <summary>
        /// 登录Ip
        /// </summary>
        LogIP,
        /// <summary>
        /// 用户ID
        /// </summary>
        UserID,
        /// <summary>
        /// 记录时间
        /// </summary>
        CreateTime,
        /// <summary>
        /// 记录类型0登录 1退出
        /// </summary>
        LogType,
    }
}
