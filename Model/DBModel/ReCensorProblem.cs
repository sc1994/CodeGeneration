using System;

namespace Model
{
    public class ReCensorProblem : BaseModel
    {
        public string PrimaryKey = "ReProblemID";
        public string IdentityKey = "ReProblemID";

        /// <summary>
        /// 问题编号
        /// </summary>
        public int ReProblemID { get; set; }

        /// <summary>
        /// 审查编号
        /// </summary>
        public int ReExamineID { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 审查专业(对应CensorProfession)
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 问题描述
        /// </summary>
        public string ReProblemDescription { get; set; } = string.Empty;

        /// <summary>
        /// 问题类别
        /// </summary>
        public string ReProblemType { get; set; } = string.Empty;

        /// <summary>
        /// 问题子专业
        /// </summary>
        public string ReProblemSubMajor { get; set; } = string.Empty;

        /// <summary>
        /// 强标号
        /// </summary>
        public int ReProblemSetNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int InputUser { get; set; }

    }


    public enum ReCensorProblemEnum
    {
        /// <summary>
        /// 问题编号
        /// </summary>
        ReProblemID,
        /// <summary>
        /// 审查编号
        /// </summary>
        ReExamineID,
        /// <summary>
        /// 任务编号
        /// </summary>
        TaskID,
        /// <summary>
        /// 项目编号
        /// </summary>
        ProjectID,
        /// <summary>
        /// 审查专业(对应CensorProfession)
        /// </summary>
        Profession,
        /// <summary>
        /// 问题描述
        /// </summary>
        ReProblemDescription,
        /// <summary>
        /// 问题类别
        /// </summary>
        ReProblemType,
        /// <summary>
        /// 问题子专业
        /// </summary>
        ReProblemSubMajor,
        /// <summary>
        /// 强标号
        /// </summary>
        ReProblemSetNo,
        /// <summary>
        /// 
        /// </summary>
        InputUser,
    }
}
