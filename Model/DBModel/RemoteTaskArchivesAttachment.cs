using System;

namespace Model
{
    public class RemoteTaskArchivesAttachment : BaseModel
    {
        public static string PrimaryKey = "AttachmentID";
        public static string IdentityKey = "AttachmentID";

        /// <summary>
        /// 
        /// </summary>
        public int AttachmentID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RowGuid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int ArchiveID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ArchiveName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string YCTaskID { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string AttachmentName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string AttachmentPath { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string OriginalName { get; set; } = string.Empty;

    }


    public enum RemoteTaskArchivesAttachmentEnum
    {
        /// <summary>
        /// 
        /// </summary>
        AttachmentID,
        /// <summary>
        /// 
        /// </summary>
        RowGuid,
        /// <summary>
        /// 
        /// </summary>
        ArchiveID,
        /// <summary>
        /// 
        /// </summary>
        ArchiveName,
        /// <summary>
        /// 
        /// </summary>
        YCTaskID,
        /// <summary>
        /// 
        /// </summary>
        AttachmentName,
        /// <summary>
        /// 
        /// </summary>
        AttachmentPath,
        /// <summary>
        /// 
        /// </summary>
        OriginalName,
    }
}
