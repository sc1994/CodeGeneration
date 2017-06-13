using System;

namespace Model
{
    public class RemoteProjectArchivesAttachment : BaseModel
    {
        public static string PrimaryKey = "ProjectAttachmentID";
        public static string IdentityKey = "ProjectAttachmentID";

        /// <summary>
        /// 
        /// </summary>
        public int ProjectAttachmentID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectArchiveID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProjectArchiveName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string YCTaskID { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ProjectAttachmentName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ProjectAttachmentPath { get; set; } = string.Empty;

    }


    public enum RemoteProjectArchivesAttachmentEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ProjectAttachmentID,
        /// <summary>
        /// 
        /// </summary>
        ProjectArchiveID,
        /// <summary>
        /// 
        /// </summary>
        ProjectArchiveName,
        /// <summary>
        /// 
        /// </summary>
        YCTaskID,
        /// <summary>
        /// 
        /// </summary>
        ProjectAttachmentName,
        /// <summary>
        /// 
        /// </summary>
        ProjectAttachmentPath,
    }
}
