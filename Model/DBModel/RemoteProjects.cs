using System;

namespace Model
{
    public class RemoteProjects : BaseModel
    {
        public static string PrimaryKey = "ProjectID";
        public static string IdentityKey = "ProjectID";

        /// <summary>
        /// 
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string YCTaskID { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ProjectSubType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string SurveyReportID { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string SurveyReportName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public decimal Areas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Floors { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Investment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Sffz { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int PartFloors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UndergroundFloors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AtticFloors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal PartHigh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal CraneTonnage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProjectLevel { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string AseismaticType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Structure { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string AseismaticLevel { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string WallMaterials { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string FieldType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Foundation { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string FireproofLevel { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string UnderFireproofLevel { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string RoofWaterproofLevel { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string UnderWaterproofLevel { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string DefendLevel { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public decimal PlantSpan { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal AccountReceivable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Demo { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string FormulaContent { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public decimal ChargeAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ISPreferentia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FormulaName { get; set; } = string.Empty;

        /// <summary>
        /// 
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


    public enum RemoteProjectsEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ProjectID,
        /// <summary>
        /// 
        /// </summary>
        YCTaskID,
        /// <summary>
        /// 
        /// </summary>
        ProjectSubType,
        /// <summary>
        /// 
        /// </summary>
        ProjectName,
        /// <summary>
        /// 
        /// </summary>
        SurveyReportID,
        /// <summary>
        /// 
        /// </summary>
        SurveyReportName,
        /// <summary>
        /// 
        /// </summary>
        Areas,
        /// <summary>
        /// 
        /// </summary>
        Floors,
        /// <summary>
        /// 
        /// </summary>
        High,
        /// <summary>
        /// 
        /// </summary>
        Investment,
        /// <summary>
        /// 
        /// </summary>
        Sffz,
        /// <summary>
        /// 
        /// </summary>
        PartFloors,
        /// <summary>
        /// 
        /// </summary>
        UndergroundFloors,
        /// <summary>
        /// 
        /// </summary>
        AtticFloors,
        /// <summary>
        /// 
        /// </summary>
        PartHigh,
        /// <summary>
        /// 
        /// </summary>
        CraneTonnage,
        /// <summary>
        /// 
        /// </summary>
        ProjectLevel,
        /// <summary>
        /// 
        /// </summary>
        AseismaticType,
        /// <summary>
        /// 
        /// </summary>
        Structure,
        /// <summary>
        /// 
        /// </summary>
        AseismaticLevel,
        /// <summary>
        /// 
        /// </summary>
        WallMaterials,
        /// <summary>
        /// 
        /// </summary>
        FieldType,
        /// <summary>
        /// 
        /// </summary>
        Foundation,
        /// <summary>
        /// 
        /// </summary>
        FireproofLevel,
        /// <summary>
        /// 
        /// </summary>
        UnderFireproofLevel,
        /// <summary>
        /// 
        /// </summary>
        RoofWaterproofLevel,
        /// <summary>
        /// 
        /// </summary>
        UnderWaterproofLevel,
        /// <summary>
        /// 
        /// </summary>
        DefendLevel,
        /// <summary>
        /// 
        /// </summary>
        PlantSpan,
        /// <summary>
        /// 
        /// </summary>
        AccountReceivable,
        /// <summary>
        /// 
        /// </summary>
        Demo,
        /// <summary>
        /// 
        /// </summary>
        FormulaContent,
        /// <summary>
        /// 
        /// </summary>
        ChargeAmount,
        /// <summary>
        /// 
        /// </summary>
        ISPreferentia,
        /// <summary>
        /// 
        /// </summary>
        FormulaName,
        /// <summary>
        /// 
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
