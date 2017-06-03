using System;

namespace Model
{
    public class ProjectArchivesAttachment : BaseModel
    {
        public string PrimaryKey = "ProjectAttachmentID";
        public string IdentityKey = "ProjectAttachmentID";

        /// <summary>
        /// 附件ID
        /// </summary>
        public int ProjectAttachmentID { get; set; }

        /// <summary>
        /// 项目材料ID
        /// </summary>
        public int ProjectArchiveID { get; set; }

        /// <summary>
        /// 材料名称
        /// </summary>
        public string ProjectArchiveName { get; set; } = string.Empty;

        /// <summary>
        /// 报审编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 附件名称(TaskID+材料名称)
        /// </summary>
        public string ProjectAttachmentName { get; set; } = string.Empty;

        /// <summary>
        /// 附件路径
        /// </summary>
        public string ProjectAttachmentPath { get; set; } = string.Empty;

    }


    public enum ProjectArchivesAttachmentEnum
    {
        /// <summary>
        /// 附件ID
        /// </summary>
        ProjectAttachmentID,
        /// <summary>
        /// 项目材料ID
        /// </summary>
        ProjectArchiveID,
        /// <summary>
        /// 材料名称
        /// </summary>
        ProjectArchiveName,
        /// <summary>
        /// 报审编号
        /// </summary>
        TaskID,
        /// <summary>
        /// 附件名称(TaskID+材料名称)
        /// </summary>
        ProjectAttachmentName,
        /// <summary>
        /// 附件路径
        /// </summary>
        ProjectAttachmentPath,
    }
}
