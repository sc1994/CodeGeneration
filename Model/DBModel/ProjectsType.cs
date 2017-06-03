using System;

namespace Model
{
    public class ProjectsType : BaseModel
    {
        public string PrimaryKey = "ProjectTypeID";
        public string IdentityKey = "ProjectTypeID";

        /// <summary>
        /// ID
        /// </summary>
        public int ProjectTypeID { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 工程类别
        /// </summary>
        public int ProjectSupType { get; set; }

        /// <summary>
        /// 工程子类别
        /// </summary>
        public string ProjectSubType { get; set; } = string.Empty;

        /// <summary>
        /// 专业材料名称
        /// </summary>
        public string ProfessionArchiveName { get; set; } = string.Empty;

        /// <summary>
        /// 材料专业(对应MaterialProfession)
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 专业value
        /// </summary>
        public int ProfessionValue { get; set; }

    }


    public enum ProjectsTypeEnum
    {
        /// <summary>
        /// ID
        /// </summary>
        ProjectTypeID,
        /// <summary>
        /// 客户编号
        /// </summary>
        CustomerID,
        /// <summary>
        /// 工程类别
        /// </summary>
        ProjectSupType,
        /// <summary>
        /// 工程子类别
        /// </summary>
        ProjectSubType,
        /// <summary>
        /// 专业材料名称
        /// </summary>
        ProfessionArchiveName,
        /// <summary>
        /// 材料专业(对应MaterialProfession)
        /// </summary>
        Profession,
        /// <summary>
        /// 专业value
        /// </summary>
        ProfessionValue,
    }
}
