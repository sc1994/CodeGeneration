using System;

namespace Model
{
    public class TaskArchivesAttachment : BaseModel
    {
        public static string PrimaryKey = "RowGuid";
        public static string IdentityKey = "AttachmentID";

        /// <summary>
        /// 附件ID
        /// </summary>
        public int AttachmentID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RowGuid { get; set; } = string.Empty;

        /// <summary>
        /// 任务材料ID
        /// </summary>
        public int ArchiveID { get; set; }

        /// <summary>
        /// 材料名称
        /// </summary>
        public string ArchiveName { get; set; } = string.Empty;

        /// <summary>
        /// 报审编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 附件名称（描述）
        /// </summary>
        public string AttachmentName { get; set; } = string.Empty;

        /// <summary>
        /// 附件路径
        /// </summary>
        public string AttachmentPath { get; set; } = string.Empty;

        /// <summary>
        /// 源文件名称
        /// </summary>
        public string OriginalName { get; set; } = string.Empty;

    }


    public enum TaskArchivesAttachmentEnum
    {
        /// <summary>
        /// 附件ID
        /// </summary>
        AttachmentID,
        /// <summary>
        /// 
        /// </summary>
        RowGuid,
        /// <summary>
        /// 任务材料ID
        /// </summary>
        ArchiveID,
        /// <summary>
        /// 材料名称
        /// </summary>
        ArchiveName,
        /// <summary>
        /// 报审编号
        /// </summary>
        TaskID,
        /// <summary>
        /// 附件名称（描述）
        /// </summary>
        AttachmentName,
        /// <summary>
        /// 附件路径
        /// </summary>
        AttachmentPath,
        /// <summary>
        /// 源文件名称
        /// </summary>
        OriginalName,
    }
}
