using System;

namespace Model.DBModel
{
    public class ReCensorOpinions : BaseModel
    {
        public static string PrimaryKey = "ReExamineID";
        public static string IdentityKey = "ReExamineID";

        /// <summary>
        /// 审查编号
        /// </summary>
        public int ReExamineID { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 审查专业
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 回复日期
        /// </summary>
        public DateTime ReviewDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 分配时间
        /// </summary>
        public DateTime ReAssignTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 计划完成时间
        /// </summary>
        public DateTime RePlanFinishTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 复审专家
        /// </summary>
        public int MasterCensor { get; set; }

        /// <summary>
        /// 复审日期
        /// </summary>
        public DateTime ReCensorDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 复审材料
        /// </summary>
        public string ReAttachment { get; set; } = string.Empty;

        /// <summary>
        /// 复审状态
        /// </summary>
        public int ReState { get; set; }

        /// <summary>
        /// 复审次数
        /// </summary>
        public int ReCensorNum { get; set; }

        /// <summary>
        /// 复审变更张数
        /// </summary>
        public int ReCensorChangeNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TaskResponsibleMan { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime TaskResponsibleCensorDate { get; set; } = ToDateTime("1900-1-1");

    }


    public enum ReCensorOpinionsEnum
    {
        /// <summary>
        /// 审查编号
        /// </summary>
        ReExamineID,
        /// <summary>
        /// 任务编号
        /// </summary>
        TaskID,
        /// <summary>
        /// 审查专业
        /// </summary>
        Profession,
        /// <summary>
        /// 回复日期
        /// </summary>
        ReviewDate,
        /// <summary>
        /// 分配时间
        /// </summary>
        ReAssignTime,
        /// <summary>
        /// 计划完成时间
        /// </summary>
        RePlanFinishTime,
        /// <summary>
        /// 复审专家
        /// </summary>
        MasterCensor,
        /// <summary>
        /// 复审日期
        /// </summary>
        ReCensorDate,
        /// <summary>
        /// 复审材料
        /// </summary>
        ReAttachment,
        /// <summary>
        /// 复审状态
        /// </summary>
        ReState,
        /// <summary>
        /// 复审次数
        /// </summary>
        ReCensorNum,
        /// <summary>
        /// 复审变更张数
        /// </summary>
        ReCensorChangeNum,
        /// <summary>
        /// 
        /// </summary>
        TaskResponsibleMan,
        /// <summary>
        /// 
        /// </summary>
        TaskResponsibleCensorDate,
    }
}
