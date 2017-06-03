using System;

namespace Model
{
    public class Cooperation : BaseModel
    {
        public string PrimaryKey = "CorpID";
        public string IdentityKey = "CorpID";

        /// <summary>
        /// 协作单位ID
        /// </summary>
        public int CorpID { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 协作单位名称
        /// </summary>
        public string CorpName { get; set; } = string.Empty;

        /// <summary>
        /// 协作单位联系人
        /// </summary>
        public string ContactPerson { get; set; } = string.Empty;

        /// <summary>
        /// 协作单位联系人电话
        /// </summary>
        public string ContactPersonTel { get; set; } = string.Empty;

        /// <summary>
        /// 区域代码
        /// </summary>
        public string Location { get; set; } = string.Empty;

    }


    public enum CooperationEnum
    {
        /// <summary>
        /// 协作单位ID
        /// </summary>
        CorpID,
        /// <summary>
        /// 客户编号
        /// </summary>
        CustomerID,
        /// <summary>
        /// 协作单位名称
        /// </summary>
        CorpName,
        /// <summary>
        /// 协作单位联系人
        /// </summary>
        ContactPerson,
        /// <summary>
        /// 协作单位联系人电话
        /// </summary>
        ContactPersonTel,
        /// <summary>
        /// 区域代码
        /// </summary>
        Location,
    }
}
