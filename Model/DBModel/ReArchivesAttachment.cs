using System;

namespace Model
{
    public class ReArchivesAttachment : BaseModel
    {
        public static string PrimaryKey = "ReAttachmentID";
        public static string IdentityKey = "ReAttachmentID";

        /// <summary>
        /// 附件ID
        /// </summary>
        public int ReAttachmentID { get; set; }

        /// <summary>
        /// 审查编号
        /// </summary>
        public int ReExamineID { get; set; }

        /// <summary>
        /// 审查专业
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 报审编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 附件名称
        /// </summary>
        public string ReAttachmentName { get; set; } = string.Empty;

        /// <summary>
        /// 签章附件路径
        /// </summary>
        public string ReAttachmentPath { get; set; } = string.Empty;

        /// <summary>
        /// 原始附件路径
        /// </summary>
        public string YuanAttachmentPath { get; set; } = string.Empty;

        /// <summary>
        /// 签章状态
        /// </summary>
        public int ReState { get; set; }

        /// <summary>
        /// 版次
        /// </summary>
        public int Edition { get; set; }

        /// <summary>
        /// 回复类型
        /// </summary>
        public string ReViewType { get; set; } = string.Empty;

    }


    public enum ReArchivesAttachmentEnum
    {
        /// <summary>
        /// 附件ID
        /// </summary>
        ReAttachmentID,
        /// <summary>
        /// 审查编号
        /// </summary>
        ReExamineID,
        /// <summary>
        /// 审查专业
        /// </summary>
        Profession,
        /// <summary>
        /// 报审编号
        /// </summary>
        TaskID,
        /// <summary>
        /// 附件名称
        /// </summary>
        ReAttachmentName,
        /// <summary>
        /// 签章附件路径
        /// </summary>
        ReAttachmentPath,
        /// <summary>
        /// 原始附件路径
        /// </summary>
        YuanAttachmentPath,
        /// <summary>
        /// 签章状态
        /// </summary>
        ReState,
        /// <summary>
        /// 版次
        /// </summary>
        Edition,
        /// <summary>
        /// 回复类型
        /// </summary>
        ReViewType,
    }
}
