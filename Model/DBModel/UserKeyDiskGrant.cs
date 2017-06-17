using System;

namespace Model.DBModel
{
    public class UserKeyDiskGrant : BaseModel
    {
        public static string PrimaryKey = "UserKeyDiskGrantID";
        public static string IdentityKey = "UserKeyDiskGrantID";

        /// <summary>
        /// 发放ID
        /// </summary>
        public int UserKeyDiskGrantID { get; set; }

        /// <summary>
        /// 密钥盘序列号
        /// </summary>
        public string UserKeyDiskNumber { get; set; } = string.Empty;

        /// <summary>
        /// 签章名字
        /// </summary>
        public string UserKeyDiskName { get; set; } = string.Empty;

        /// <summary>
        /// 签章密码
        /// </summary>
        public string UserKeyDiskPassWord { get; set; } = string.Empty;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;

    }


    public enum UserKeyDiskGrantEnum
    {
        /// <summary>
        /// 发放ID
        /// </summary>
        UserKeyDiskGrantID,
        /// <summary>
        /// 密钥盘序列号
        /// </summary>
        UserKeyDiskNumber,
        /// <summary>
        /// 签章名字
        /// </summary>
        UserKeyDiskName,
        /// <summary>
        /// 签章密码
        /// </summary>
        UserKeyDiskPassWord,
        /// <summary>
        /// 用户ID
        /// </summary>
        UserID,
        /// <summary>
        /// 用户名称
        /// </summary>
        UserName,
        /// <summary>
        /// 备注
        /// </summary>
        Remark,
    }
}
