using System;

namespace Model
{
    public class RemoteTaskArchives : BaseModel
    {
        public static string PrimaryKey = "ArchiveID";
        public static string IdentityKey = "ArchiveID";

        /// <summary>
        /// 
        /// </summary>
        public int ArchiveID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string YCTaskID { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ConstructCorp { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ArchiveName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int ArchiveStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ArchiveAttachment { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string PolicyArchiveType { get; set; } = string.Empty;

    }


    public enum RemoteTaskArchivesEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ArchiveID,
        /// <summary>
        /// 
        /// </summary>
        YCTaskID,
        /// <summary>
        /// 
        /// </summary>
        ConstructCorp,
        /// <summary>
        /// 
        /// </summary>
        ArchiveName,
        /// <summary>
        /// 
        /// </summary>
        ArchiveStatus,
        /// <summary>
        /// 
        /// </summary>
        ArchiveAttachment,
        /// <summary>
        /// 
        /// </summary>
        PolicyArchiveType,
    }
}
