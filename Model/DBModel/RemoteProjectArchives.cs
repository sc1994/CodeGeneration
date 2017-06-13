using System;

namespace Model
{
    public class RemoteProjectArchives : BaseModel
    {
        public static string PrimaryKey = "";
        public static string IdentityKey = "ProjectArchiveID";

        /// <summary>
        /// 
        /// </summary>
        public int ProjectArchiveID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProjectArchiveName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int ProfessionValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectArchiveStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProjectArchiveAttachment { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int AttachmentTypeID { get; set; }

    }


    public enum RemoteProjectArchivesEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ProjectArchiveID,
        /// <summary>
        /// 
        /// </summary>
        ProjectID,
        /// <summary>
        /// 
        /// </summary>
        ProjectArchiveName,
        /// <summary>
        /// 
        /// </summary>
        Profession,
        /// <summary>
        /// 
        /// </summary>
        ProfessionValue,
        /// <summary>
        /// 
        /// </summary>
        ProjectArchiveStatus,
        /// <summary>
        /// 
        /// </summary>
        ProjectArchiveAttachment,
        /// <summary>
        /// 
        /// </summary>
        AttachmentTypeID,
    }
}
