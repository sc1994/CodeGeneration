using System;

namespace Model
{
    public class ConstructionCorp : BaseModel
    {
        public string PrimaryKey = "CorpID";
        public string IdentityKey = "CorpID";

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
    }
}
