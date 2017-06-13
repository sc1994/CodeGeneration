using System;

namespace Model
{
    public class TaskArchives : BaseModel
    {
        public static string PrimaryKey = "ArchiveID";
        public static string IdentityKey = "ArchiveID";

        /// <summary>
        /// 任务材料ID
        /// </summary>
        public int ArchiveID { get; set; }

        /// <summary>
        /// 报审编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 建设单位
        /// </summary>
        public string ConstructCorp { get; set; } = string.Empty;

        /// <summary>
        /// 材料名称
        /// </summary>
        public string ArchiveName { get; set; } = string.Empty;

        /// <summary>
        /// 材料状态
        /// </summary>
        public int ArchiveStatus { get; set; }

        /// <summary>
        /// 材料附件
        /// </summary>
        public string ArchiveAttachment { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string PolicyArchiveType { get; set; } = string.Empty;

    }


    public enum TaskArchivesEnum
    {
        /// <summary>
        /// 任务材料ID
        /// </summary>
        ArchiveID,
        /// <summary>
        /// 报审编号
        /// </summary>
        TaskID,
        /// <summary>
        /// 建设单位
        /// </summary>
        ConstructCorp,
        /// <summary>
        /// 材料名称
        /// </summary>
        ArchiveName,
        /// <summary>
        /// 材料状态
        /// </summary>
        ArchiveStatus,
        /// <summary>
        /// 材料附件
        /// </summary>
        ArchiveAttachment,
        /// <summary>
        /// 
        /// </summary>
        PolicyArchiveType,
    }
}
