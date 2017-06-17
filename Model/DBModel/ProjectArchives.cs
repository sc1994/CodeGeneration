using System;

namespace Model.DBModel
{
    public class ProjectArchives : BaseModel
    {
        public static string PrimaryKey = "ProjectArchiveID";
        public static string IdentityKey = "ProjectArchiveID";

        /// <summary>
        /// 项目材料ID
        /// </summary>
        public int ProjectArchiveID { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 材料名称
        /// </summary>
        public string ProjectArchiveName { get; set; } = string.Empty;

        /// <summary>
        /// 材料专业(对应MaterialProfession表)
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int ProfessionValue { get; set; }

        /// <summary>
        /// 材料状态
        /// </summary>
        public int ProjectArchiveStatus { get; set; }

        /// <summary>
        /// 材料附件
        /// </summary>
        public string ProjectArchiveAttachment { get; set; } = string.Empty;

        /// <summary>
        /// 关联ProjectsType的ID
        /// </summary>
        public int AttachmentTypeID { get; set; }

    }


    public enum ProjectArchivesEnum
    {
        /// <summary>
        /// 项目材料ID
        /// </summary>
        ProjectArchiveID,
        /// <summary>
        /// 项目编号
        /// </summary>
        ProjectID,
        /// <summary>
        /// 材料名称
        /// </summary>
        ProjectArchiveName,
        /// <summary>
        /// 材料专业(对应MaterialProfession表)
        /// </summary>
        Profession,
        /// <summary>
        /// 
        /// </summary>
        ProfessionValue,
        /// <summary>
        /// 材料状态
        /// </summary>
        ProjectArchiveStatus,
        /// <summary>
        /// 材料附件
        /// </summary>
        ProjectArchiveAttachment,
        /// <summary>
        /// 关联ProjectsType的ID
        /// </summary>
        AttachmentTypeID,
    }
}
