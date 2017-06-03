using System;

namespace Model
{
    public class PolicyReviewArchive : BaseModel
    {
        public string PrimaryKey = "PolicyReviewArchiveID";
        public string IdentityKey = "PolicyReviewArchiveID";

        /// <summary>
        /// 材料ID
        /// </summary>
        public int PolicyReviewArchiveID { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 工程类别
        /// </summary>
        public int ProjectSupType { get; set; }

        /// <summary>
        /// 政策性审查材料名称
        /// </summary>
        public string PolicyReviewArchiveName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string PolicyArchiveType { get; set; } = string.Empty;

    }


    public enum PolicyReviewArchiveEnum
    {
        /// <summary>
        /// 材料ID
        /// </summary>
        PolicyReviewArchiveID,
        /// <summary>
        /// 客户ID
        /// </summary>
        CustomerID,
        /// <summary>
        /// 工程类别
        /// </summary>
        ProjectSupType,
        /// <summary>
        /// 政策性审查材料名称
        /// </summary>
        PolicyReviewArchiveName,
        /// <summary>
        /// 
        /// </summary>
        PolicyArchiveType,
    }
}
