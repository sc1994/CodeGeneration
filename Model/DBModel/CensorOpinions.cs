using System;

namespace Model.DBModel
{
    public class CensorOpinions : BaseModel
    {
        public static string PrimaryKey = "ExamineID";
        public static string IdentityKey = "ExamineID";

        /// <summary>
        /// 审查编号
        /// </summary>
        public int ExamineID { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 审查专业(对应CensorProfession)
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 分配时间
        /// </summary>
        public DateTime AssignTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 计划完成时间
        /// </summary>
        public DateTime PlanFinishTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 设计人
        /// </summary>
        public string Designer { get; set; } = string.Empty;

        /// <summary>
        /// 专业负责人
        /// </summary>
        public string MajorRespose { get; set; } = string.Empty;

        /// <summary>
        /// 审核人
        /// </summary>
        public string Assessor { get; set; } = string.Empty;

        /// <summary>
        /// 注册师
        /// </summary>
        public string Regester { get; set; } = string.Empty;

        /// <summary>
        /// 执业印章号
        /// </summary>
        public string SealNo { get; set; } = string.Empty;

        /// <summary>
        /// 审查意见
        /// </summary>
        public string CensorOpinions_Field { get; set; } = string.Empty;

        /// <summary>
        /// 违反条文数
        /// </summary>
        public int DisobeyItems { get; set; }

        /// <summary>
        /// 违反标准数
        /// </summary>
        public int DisobeyStandards { get; set; }

        /// <summary>
        /// 第一审查人
        /// </summary>
        public int MasterCensor { get; set; }

        /// <summary>
        /// 第一审查人认定证书号
        /// </summary>
        public string MCertifieateID { get; set; } = string.Empty;

        /// <summary>
        /// 第二审查人
        /// </summary>
        public int SecondCensor { get; set; }

        /// <summary>
        /// 第二审查人认定证书号
        /// </summary>
        public string SCertifieateID { get; set; } = string.Empty;

        /// <summary>
        /// 审查日期
        /// </summary>
        public DateTime CensorDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 审定人
        /// </summary>
        public int Opinioner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime OpinionerDate { get; set; } = ToDateTime("");

        /// <summary>
        /// 任务分配人
        /// </summary>
        public int TaskAssigner { get; set; }

        /// <summary>
        /// 图纸数量
        /// </summary>
        public int DrawingNum { get; set; }

        /// <summary>
        /// 是否盖章
        /// </summary>
        public int IsSignature { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime MasterCensorDate { get; set; } = ToDateTime("");

        /// <summary>
        /// 
        /// </summary>
        public DateTime SecondCensorDate { get; set; } = ToDateTime("");

        /// <summary>
        /// 0: 默认状态 1:第一审查人完成 2: 第二完成 3:第一第二都完成 7:审定完成
        /// </summary>
        public int CensorOpinionsType { get; set; }

    }


    public enum CensorOpinionsEnum
    {
        /// <summary>
        /// 审查编号
        /// </summary>
        ExamineID,
        /// <summary>
        /// 任务编号
        /// </summary>
        TaskID,
        /// <summary>
        /// 客户编号
        /// </summary>
        CustomerID,
        /// <summary>
        /// 审查专业(对应CensorProfession)
        /// </summary>
        Profession,
        /// <summary>
        /// 分配时间
        /// </summary>
        AssignTime,
        /// <summary>
        /// 计划完成时间
        /// </summary>
        PlanFinishTime,
        /// <summary>
        /// 设计人
        /// </summary>
        Designer,
        /// <summary>
        /// 专业负责人
        /// </summary>
        MajorRespose,
        /// <summary>
        /// 审核人
        /// </summary>
        Assessor,
        /// <summary>
        /// 注册师
        /// </summary>
        Regester,
        /// <summary>
        /// 执业印章号
        /// </summary>
        SealNo,
        /// <summary>
        /// 审查意见
        /// </summary>
        CensorOpinions_Field,
        /// <summary>
        /// 违反条文数
        /// </summary>
        DisobeyItems,
        /// <summary>
        /// 违反标准数
        /// </summary>
        DisobeyStandards,
        /// <summary>
        /// 第一审查人
        /// </summary>
        MasterCensor,
        /// <summary>
        /// 第一审查人认定证书号
        /// </summary>
        MCertifieateID,
        /// <summary>
        /// 第二审查人
        /// </summary>
        SecondCensor,
        /// <summary>
        /// 第二审查人认定证书号
        /// </summary>
        SCertifieateID,
        /// <summary>
        /// 审查日期
        /// </summary>
        CensorDate,
        /// <summary>
        /// 审定人
        /// </summary>
        Opinioner,
        /// <summary>
        /// 
        /// </summary>
        OpinionerDate,
        /// <summary>
        /// 任务分配人
        /// </summary>
        TaskAssigner,
        /// <summary>
        /// 图纸数量
        /// </summary>
        DrawingNum,
        /// <summary>
        /// 是否盖章
        /// </summary>
        IsSignature,
        /// <summary>
        /// 
        /// </summary>
        MasterCensorDate,
        /// <summary>
        /// 
        /// </summary>
        SecondCensorDate,
        /// <summary>
        /// 0: 默认状态 1:第一审查人完成 2: 第二完成 3:第一第二都完成 7:审定完成
        /// </summary>
        CensorOpinionsType,
    }
}
