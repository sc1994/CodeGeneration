using System;

namespace Model
{
    public class TaskArchivesAttachment : BaseModel
    {
        public string PrimaryKey = "RowGuid";
        public string IdentityKey = "AttachmentID";
        
        /// <summary>
        /// 附件ID
        /// </summary>
        public int AttachmentID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CensorDate { get; set; } = ToDateTime("1900-1-1");
    }

    public enum TaskArchivesAttachmentEnum
    {
        /// <summary>
        /// 附件ID
        /// </summary>
        AttachmentID
    }
}
