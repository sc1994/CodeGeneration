using System;

namespace Model
{
    public class RemoteCensorTasks : BaseModel
    {
        public static string PrimaryKey = "YCTaskID";
        public static string IdentityKey = "";

        /// <summary>
        /// 报审编号【客户编号+YTSQ20140001/SJSQ20140001】
        /// </summary>
        public string YCTaskID { get; set; } = string.Empty;

        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string DisplayProjectName { get; set; } = string.Empty;

        /// <summary>
        /// 一卡通号
        /// </summary>
        public string CardNo { get; set; } = string.Empty;

        /// <summary>
        /// 勘前报审编号
        /// </summary>
        public string YTTaskID { get; set; } = string.Empty;

        /// <summary>
        /// 变更任务报审编号
        /// </summary>
        public string SJTaskID { get; set; } = string.Empty;

        /// <summary>
        /// 项目地址
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// 工程类别
        /// </summary>
        public int ProjectSupType { get; set; }

        /// <summary>
        /// 工程类别简拼
        /// </summary>
        public string ProjectSupTypeRemark { get; set; } = string.Empty;

        /// <summary>
        /// 建设单位
        /// </summary>
        public string ConstructCorp { get; set; } = string.Empty;

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactPerson { get; set; } = string.Empty;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPersonTel { get; set; } = string.Empty;

        /// <summary>
        /// 勘察单位
        /// </summary>
        public string SurveyCorp { get; set; } = string.Empty;

        /// <summary>
        /// 资质等级
        /// </summary>
        public string SurveyCorpGrade { get; set; } = string.Empty;

        /// <summary>
        /// 勘察单位地区
        /// </summary>
        public string SurveyCorpRegion { get; set; } = string.Empty;

        /// <summary>
        /// 主题设计单位
        /// </summary>
        public string DesignCorp { get; set; } = string.Empty;

        /// <summary>
        /// 主体资质等级
        /// </summary>
        public string DesignCorpGrade { get; set; } = string.Empty;

        /// <summary>
        /// 主体设计单位地区
        /// </summary>
        public string DesignCorpRegion { get; set; } = string.Empty;

        /// <summary>
        /// 人防设计单位
        /// </summary>
        public string AirDefenseDesignCorp { get; set; } = string.Empty;

        /// <summary>
        /// 人防资质等级
        /// </summary>
        public string AirDefenseDesignCorpGrade { get; set; } = string.Empty;

        /// <summary>
        /// 人防设计单位地区
        /// </summary>
        public string AirDefenseDesignCorpRegion { get; set; } = string.Empty;

        /// <summary>
        /// 送审日期
        /// </summary>
        public DateTime DeliverDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 颁书日期（审查结束日期）
        /// </summary>
        public DateTime IssueDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 任务状态(0等待补齐材料|1等待分配|2正在审查|3审查结束|4回复通过|5收费完成|6审批通过)
        /// </summary>
        public int CensorCircs { get; set; }

        /// <summary>
        /// 报审状态(0材料齐全|1先行审查|2补齐后审查)
        /// </summary>
        public int ApplyState { get; set; }

        /// <summary>
        /// 报审说明
        /// </summary>
        public string ApplyExplain { get; set; } = string.Empty;

        /// <summary>
        /// 审查意见1
        /// </summary>
        public string CensorOpinion1 { get; set; } = string.Empty;

        /// <summary>
        /// 审查意见2
        /// </summary>
        public string CensorOpinion2 { get; set; } = string.Empty;

        /// <summary>
        /// 验证码
        /// </summary>
        public int ValidateCode { get; set; }

        /// <summary>
        /// 建设证书编号
        /// </summary>
        public string ConstructionNo { get; set; } = string.Empty;

        /// <summary>
        /// 抗震证书编号
        /// </summary>
        public string SeismicNo { get; set; } = string.Empty;

        /// <summary>
        /// 任务负责人
        /// </summary>
        public int TaskResponsibleMan { get; set; }

        /// <summary>
        /// 技术负责人
        /// </summary>
        public int TechResponsibleMan { get; set; }

        /// <summary>
        /// 回复备注
        /// </summary>
        public string RevertNote { get; set; } = string.Empty;

        /// <summary>
        /// 上报状态
        /// </summary>
        public int ReportedState { get; set; }

        /// <summary>
        /// 上报项目ID
        /// </summary>
        public string sbxmid { get; set; } = string.Empty;

        /// <summary>
        /// 上报人编号
        /// </summary>
        public int ReportedID { get; set; }

        /// <summary>
        /// 上报时间
        /// </summary>
        public DateTime ReportedTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 任务接审人
        /// </summary>
        public int TaskApplyer { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public int TaskApprover { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime ApproveDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 颁证人
        /// </summary>
        public int Awarder { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        public string WinXinNo { get; set; } = string.Empty;

        /// <summary>
        /// 未分配专业数
        /// </summary>
        public int UnAllotProfessionNum { get; set; }

        /// <summary>
        /// 已分配专业数
        /// </summary>
        public int AllotProfessionNum { get; set; }

        /// <summary>
        /// 未审查专业数
        /// </summary>
        public int UnCensorProfessionNum { get; set; }

        /// <summary>
        /// 已审查专业数
        /// </summary>
        public int CensorProfessionNum { get; set; }

        /// <summary>
        /// 图纸总数量
        /// </summary>
        public int DrawingTotalNum { get; set; }

        /// <summary>
        /// 图纸提交日期
        /// </summary>
        public DateTime DrawingSubmitDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 任务接收时间
        /// </summary>
        public DateTime TaskAcceptDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 任务分配时间
        /// </summary>
        public DateTime TaskAllotDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 回复提交日期
        /// </summary>
        public DateTime ReplySubmitDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 回复完成日期
        /// </summary>
        public DateTime ReplyCompleteDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 颁证日期
        /// </summary>
        public DateTime AwardDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 是否联合接审 1是0否
        /// </summary>
        public int IsUnion { get; set; }

        /// <summary>
        /// 联合接审接收单位;隔开
        /// </summary>
        public string AcceptCustomers { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string SerialNo { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int OperateStaus { get; set; }

        /// <summary>
        /// 审查日期
        /// </summary>
        public DateTime CensorOpinionDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 图纸下载日期
        /// </summary>
        public DateTime DownLoadDate { get; set; } = ToDateTime("1900-1-1");

    }


    public enum RemoteCensorTasksEnum
    {
        /// <summary>
        /// 报审编号【客户编号+YTSQ20140001/SJSQ20140001】
        /// </summary>
        YCTaskID,
        /// <summary>
        /// 客户编号
        /// </summary>
        CustomerID,
        /// <summary>
        /// 项目名称
        /// </summary>
        DisplayProjectName,
        /// <summary>
        /// 一卡通号
        /// </summary>
        CardNo,
        /// <summary>
        /// 勘前报审编号
        /// </summary>
        YTTaskID,
        /// <summary>
        /// 变更任务报审编号
        /// </summary>
        SJTaskID,
        /// <summary>
        /// 项目地址
        /// </summary>
        Location,
        /// <summary>
        /// 工程类别
        /// </summary>
        ProjectSupType,
        /// <summary>
        /// 工程类别简拼
        /// </summary>
        ProjectSupTypeRemark,
        /// <summary>
        /// 建设单位
        /// </summary>
        ConstructCorp,
        /// <summary>
        /// 联系人
        /// </summary>
        ContactPerson,
        /// <summary>
        /// 联系电话
        /// </summary>
        ContactPersonTel,
        /// <summary>
        /// 勘察单位
        /// </summary>
        SurveyCorp,
        /// <summary>
        /// 资质等级
        /// </summary>
        SurveyCorpGrade,
        /// <summary>
        /// 勘察单位地区
        /// </summary>
        SurveyCorpRegion,
        /// <summary>
        /// 主题设计单位
        /// </summary>
        DesignCorp,
        /// <summary>
        /// 主体资质等级
        /// </summary>
        DesignCorpGrade,
        /// <summary>
        /// 主体设计单位地区
        /// </summary>
        DesignCorpRegion,
        /// <summary>
        /// 人防设计单位
        /// </summary>
        AirDefenseDesignCorp,
        /// <summary>
        /// 人防资质等级
        /// </summary>
        AirDefenseDesignCorpGrade,
        /// <summary>
        /// 人防设计单位地区
        /// </summary>
        AirDefenseDesignCorpRegion,
        /// <summary>
        /// 送审日期
        /// </summary>
        DeliverDate,
        /// <summary>
        /// 颁书日期（审查结束日期）
        /// </summary>
        IssueDate,
        /// <summary>
        /// 任务状态(0等待补齐材料|1等待分配|2正在审查|3审查结束|4回复通过|5收费完成|6审批通过)
        /// </summary>
        CensorCircs,
        /// <summary>
        /// 报审状态(0材料齐全|1先行审查|2补齐后审查)
        /// </summary>
        ApplyState,
        /// <summary>
        /// 报审说明
        /// </summary>
        ApplyExplain,
        /// <summary>
        /// 审查意见1
        /// </summary>
        CensorOpinion1,
        /// <summary>
        /// 审查意见2
        /// </summary>
        CensorOpinion2,
        /// <summary>
        /// 验证码
        /// </summary>
        ValidateCode,
        /// <summary>
        /// 建设证书编号
        /// </summary>
        ConstructionNo,
        /// <summary>
        /// 抗震证书编号
        /// </summary>
        SeismicNo,
        /// <summary>
        /// 任务负责人
        /// </summary>
        TaskResponsibleMan,
        /// <summary>
        /// 技术负责人
        /// </summary>
        TechResponsibleMan,
        /// <summary>
        /// 回复备注
        /// </summary>
        RevertNote,
        /// <summary>
        /// 上报状态
        /// </summary>
        ReportedState,
        /// <summary>
        /// 上报项目ID
        /// </summary>
        sbxmid,
        /// <summary>
        /// 上报人编号
        /// </summary>
        ReportedID,
        /// <summary>
        /// 上报时间
        /// </summary>
        ReportedTime,
        /// <summary>
        /// 任务接审人
        /// </summary>
        TaskApplyer,
        /// <summary>
        /// 审批人
        /// </summary>
        TaskApprover,
        /// <summary>
        /// 审批时间
        /// </summary>
        ApproveDate,
        /// <summary>
        /// 颁证人
        /// </summary>
        Awarder,
        /// <summary>
        /// 微信号
        /// </summary>
        WinXinNo,
        /// <summary>
        /// 未分配专业数
        /// </summary>
        UnAllotProfessionNum,
        /// <summary>
        /// 已分配专业数
        /// </summary>
        AllotProfessionNum,
        /// <summary>
        /// 未审查专业数
        /// </summary>
        UnCensorProfessionNum,
        /// <summary>
        /// 已审查专业数
        /// </summary>
        CensorProfessionNum,
        /// <summary>
        /// 图纸总数量
        /// </summary>
        DrawingTotalNum,
        /// <summary>
        /// 图纸提交日期
        /// </summary>
        DrawingSubmitDate,
        /// <summary>
        /// 任务接收时间
        /// </summary>
        TaskAcceptDate,
        /// <summary>
        /// 任务分配时间
        /// </summary>
        TaskAllotDate,
        /// <summary>
        /// 回复提交日期
        /// </summary>
        ReplySubmitDate,
        /// <summary>
        /// 回复完成日期
        /// </summary>
        ReplyCompleteDate,
        /// <summary>
        /// 颁证日期
        /// </summary>
        AwardDate,
        /// <summary>
        /// 是否联合接审 1是0否
        /// </summary>
        IsUnion,
        /// <summary>
        /// 联合接审接收单位;隔开
        /// </summary>
        AcceptCustomers,
        /// <summary>
        /// 
        /// </summary>
        SerialNo,
        /// <summary>
        /// 
        /// </summary>
        OperateStaus,
        /// <summary>
        /// 审查日期
        /// </summary>
        CensorOpinionDate,
        /// <summary>
        /// 图纸下载日期
        /// </summary>
        DownLoadDate,
    }
}
