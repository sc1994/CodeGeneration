using System;

namespace Model
{
    public class CorpKeyDiskGrant : BaseModel
    {
        public string PrimaryKey = "CorpKeyDiskGrantID";
        public string IdentityKey = "CorpKeyDiskGrantID";

        /// <summary>
        /// 发放ID
        /// </summary>
        public int CorpKeyDiskGrantID { get; set; }

        /// <summary>
        /// 密钥盘序列号
        /// </summary>
        public string CorpKeyDiskNumber { get; set; } = string.Empty;

        /// <summary>
        /// 签章名字
        /// </summary>
        public string CorpKeyDiskName { get; set; } = string.Empty;

        /// <summary>
        /// 签章密码
        /// </summary>
        public string CorpKeyDiskPassWord { get; set; } = string.Empty;

        /// <summary>
        /// 单位ID
        /// </summary>
        public int CorpID { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string CorpName { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;

    }


    public enum CorpKeyDiskGrantEnum
    {
        /// <summary>
        /// 发放ID
        /// </summary>
        CorpKeyDiskGrantID,
        /// <summary>
        /// 密钥盘序列号
        /// </summary>
        CorpKeyDiskNumber,
        /// <summary>
        /// 签章名字
        /// </summary>
        CorpKeyDiskName,
        /// <summary>
        /// 签章密码
        /// </summary>
        CorpKeyDiskPassWord,
        /// <summary>
        /// 单位ID
        /// </summary>
        CorpID,
        /// <summary>
        /// 单位名称
        /// </summary>
        CorpName,
        /// <summary>
        /// 备注
        /// </summary>
        Remark,
    }
}
