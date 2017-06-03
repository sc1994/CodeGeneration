using System;

namespace Model
{
    public class TaskCertificate : BaseModel
    {
        public string PrimaryKey = "CID";
        public string IdentityKey = "CID";

        /// <summary>
        /// 
        /// </summary>
        public int CID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ConstructCorp { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string SurveyCorp { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string DesignCorp { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ProjectIDs { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ProjectLocation { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ProjectType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ProjectLevel { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string FieldType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string AseismaGrouptic { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string AseismaticLevel { get; set; } = string.Empty;

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
        public string HighFloors { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Foundation { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Areas { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string CensorRange { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime CensorDateDate { get; set; } = ToDateTime("('1900-1-1')");

        /// <summary>
        /// 
        /// </summary>
        public string ConstructionNo { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string SeismicNo { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string CertificateNote { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime AwardDate { get; set; } = ToDateTime("('1900-1-1')");

        /// <summary>
        /// 
        /// </summary>
        public int Awarder { get; set; }

    }


    public enum TaskCertificateEnum
    {
        /// <summary>
        /// 
        /// </summary>
        CID,
        /// <summary>
        /// 
        /// </summary>
        TaskID,
        /// <summary>
        /// 
        /// </summary>
        ConstructCorp,
        /// <summary>
        /// 
        /// </summary>
        SurveyCorp,
        /// <summary>
        /// 
        /// </summary>
        DesignCorp,
        /// <summary>
        /// 
        /// </summary>
        ProjectIDs,
        /// <summary>
        /// 
        /// </summary>
        ProjectName,
        /// <summary>
        /// 
        /// </summary>
        ProjectLocation,
        /// <summary>
        /// 
        /// </summary>
        ProjectType,
        /// <summary>
        /// 
        /// </summary>
        ProjectLevel,
        /// <summary>
        /// 
        /// </summary>
        FieldType,
        /// <summary>
        /// 
        /// </summary>
        AseismaGrouptic,
        /// <summary>
        /// 
        /// </summary>
        AseismaticLevel,
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
        HighFloors,
        /// <summary>
        /// 
        /// </summary>
        Foundation,
        /// <summary>
        /// 
        /// </summary>
        Areas,
        /// <summary>
        /// 
        /// </summary>
        CensorRange,
        /// <summary>
        /// 
        /// </summary>
        CensorDateDate,
        /// <summary>
        /// 
        /// </summary>
        ConstructionNo,
        /// <summary>
        /// 
        /// </summary>
        SeismicNo,
        /// <summary>
        /// 
        /// </summary>
        CertificateNote,
        /// <summary>
        /// 
        /// </summary>
        AwardDate,
        /// <summary>
        /// 
        /// </summary>
        Awarder,
    }
}
