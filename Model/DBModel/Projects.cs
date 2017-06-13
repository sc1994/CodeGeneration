using System;

namespace Model
{
    public class Projects : BaseModel
    {
        public static string PrimaryKey = "ProjectID";
        public static string IdentityKey = "ProjectID";

        /// <summary>
        /// 项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 报审编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 工程子类别
        /// </summary>
        public string ProjectSubType { get; set; } = string.Empty;

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;

        /// <summary>
        /// 勘察报告编号
        /// </summary>
        public string SurveyReportID { get; set; } = string.Empty;

        /// <summary>
        /// 勘察报告名称
        /// </summary>
        public string SurveyReportName { get; set; } = string.Empty;

        /// <summary>
        /// 建筑面积
        /// </summary>
        public decimal Areas { get; set; }

        /// <summary>
        /// 地上建筑层数
        /// </summary>
        public string Floors { get; set; } = string.Empty;

        /// <summary>
        /// 建筑高度
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// 投资额
        /// </summary>
        public decimal Investment { get; set; }

        /// <summary>
        /// 项目收费类型(原设防分组)
        /// </summary>
        public string Sffz { get; set; } = string.Empty;

        /// <summary>
        /// 局部层数
        /// </summary>
        public int PartFloors { get; set; }

        /// <summary>
        /// 地下层数
        /// </summary>
        public int UndergroundFloors { get; set; }

        /// <summary>
        /// 阁楼层数
        /// </summary>
        public int AtticFloors { get; set; }

        /// <summary>
        /// 局部高度
        /// </summary>
        public decimal PartHigh { get; set; }

        /// <summary>
        /// 吊车吨位
        /// </summary>
        public decimal CraneTonnage { get; set; }

        /// <summary>
        /// 工程等级
        /// </summary>
        public string ProjectLevel { get; set; } = string.Empty;

        /// <summary>
        /// 抗震分类
        /// </summary>
        public string AseismaticType { get; set; } = string.Empty;

        /// <summary>
        /// 结构类型
        /// </summary>
        public string Structure { get; set; } = string.Empty;

        /// <summary>
        /// 抗震等级
        /// </summary>
        public string AseismaticLevel { get; set; } = string.Empty;

        /// <summary>
        /// 墙体材料
        /// </summary>
        public string WallMaterials { get; set; } = string.Empty;

        /// <summary>
        /// 场地类别
        /// </summary>
        public string FieldType { get; set; } = string.Empty;

        /// <summary>
        /// 基础形式
        /// </summary>
        public string Foundation { get; set; } = string.Empty;

        /// <summary>
        /// 地上耐火等级
        /// </summary>
        public string FireproofLevel { get; set; } = string.Empty;

        /// <summary>
        /// 地下耐火等级
        /// </summary>
        public string UnderFireproofLevel { get; set; } = string.Empty;

        /// <summary>
        /// 屋面防水等级
        /// </summary>
        public string RoofWaterproofLevel { get; set; } = string.Empty;

        /// <summary>
        /// 地下室防水等级
        /// </summary>
        public string UnderWaterproofLevel { get; set; } = string.Empty;

        /// <summary>
        /// 人防等级
        /// </summary>
        public string DefendLevel { get; set; } = string.Empty;

        /// <summary>
        /// 厂房跨度
        /// </summary>
        public decimal PlantSpan { get; set; }

        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal AccountReceivable { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Demo { get; set; } = string.Empty;

        /// <summary>
        /// 公式内容
        /// </summary>
        public string FormulaContent { get; set; } = string.Empty;

        /// <summary>
        /// 金额
        /// </summary>
        public decimal ChargeAmount { get; set; }

        /// <summary>
        /// 是否享受其他优惠
        /// </summary>
        public int ISPreferentia { get; set; }

        /// <summary>
        /// 公式名称
        /// </summary>
        public string FormulaName { get; set; } = string.Empty;

        /// <summary>
        /// 最低收费标准
        /// </summary>
        public string MinChargeAmount { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int DrawingNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Lng { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Lat { get; set; }

    }


    public enum ProjectsEnum
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        ProjectID,
        /// <summary>
        /// 报审编号
        /// </summary>
        TaskID,
        /// <summary>
        /// 工程子类别
        /// </summary>
        ProjectSubType,
        /// <summary>
        /// 项目名称
        /// </summary>
        ProjectName,
        /// <summary>
        /// 勘察报告编号
        /// </summary>
        SurveyReportID,
        /// <summary>
        /// 勘察报告名称
        /// </summary>
        SurveyReportName,
        /// <summary>
        /// 建筑面积
        /// </summary>
        Areas,
        /// <summary>
        /// 地上建筑层数
        /// </summary>
        Floors,
        /// <summary>
        /// 建筑高度
        /// </summary>
        High,
        /// <summary>
        /// 投资额
        /// </summary>
        Investment,
        /// <summary>
        /// 项目收费类型(原设防分组)
        /// </summary>
        Sffz,
        /// <summary>
        /// 局部层数
        /// </summary>
        PartFloors,
        /// <summary>
        /// 地下层数
        /// </summary>
        UndergroundFloors,
        /// <summary>
        /// 阁楼层数
        /// </summary>
        AtticFloors,
        /// <summary>
        /// 局部高度
        /// </summary>
        PartHigh,
        /// <summary>
        /// 吊车吨位
        /// </summary>
        CraneTonnage,
        /// <summary>
        /// 工程等级
        /// </summary>
        ProjectLevel,
        /// <summary>
        /// 抗震分类
        /// </summary>
        AseismaticType,
        /// <summary>
        /// 结构类型
        /// </summary>
        Structure,
        /// <summary>
        /// 抗震等级
        /// </summary>
        AseismaticLevel,
        /// <summary>
        /// 墙体材料
        /// </summary>
        WallMaterials,
        /// <summary>
        /// 场地类别
        /// </summary>
        FieldType,
        /// <summary>
        /// 基础形式
        /// </summary>
        Foundation,
        /// <summary>
        /// 地上耐火等级
        /// </summary>
        FireproofLevel,
        /// <summary>
        /// 地下耐火等级
        /// </summary>
        UnderFireproofLevel,
        /// <summary>
        /// 屋面防水等级
        /// </summary>
        RoofWaterproofLevel,
        /// <summary>
        /// 地下室防水等级
        /// </summary>
        UnderWaterproofLevel,
        /// <summary>
        /// 人防等级
        /// </summary>
        DefendLevel,
        /// <summary>
        /// 厂房跨度
        /// </summary>
        PlantSpan,
        /// <summary>
        /// 应收金额
        /// </summary>
        AccountReceivable,
        /// <summary>
        /// 备注
        /// </summary>
        Demo,
        /// <summary>
        /// 公式内容
        /// </summary>
        FormulaContent,
        /// <summary>
        /// 金额
        /// </summary>
        ChargeAmount,
        /// <summary>
        /// 是否享受其他优惠
        /// </summary>
        ISPreferentia,
        /// <summary>
        /// 公式名称
        /// </summary>
        FormulaName,
        /// <summary>
        /// 最低收费标准
        /// </summary>
        MinChargeAmount,
        /// <summary>
        /// 
        /// </summary>
        DrawingNum,
        /// <summary>
        /// 
        /// </summary>
        Lng,
        /// <summary>
        /// 
        /// </summary>
        Lat,
    }
}
