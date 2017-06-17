using System;

namespace Model.DBModel
{
    public class CensorProblemRelation : BaseModel
    {
        public static string PrimaryKey = "RowGuid";
        public static string IdentityKey = "ID";

        /// <summary>
        /// 
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RowGuid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int ProblemID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DrawingRowGuid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public decimal DrawingX1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DrawingY1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DrawingX2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DrawingY2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PageNumber { get; set; }

    }


    public enum CensorProblemRelationEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ID,
        /// <summary>
        /// 
        /// </summary>
        RowGuid,
        /// <summary>
        /// 
        /// </summary>
        ProblemID,
        /// <summary>
        /// 
        /// </summary>
        ProjectID,
        /// <summary>
        /// 
        /// </summary>
        DrawingRowGuid,
        /// <summary>
        /// 
        /// </summary>
        DrawingX1,
        /// <summary>
        /// 
        /// </summary>
        DrawingY1,
        /// <summary>
        /// 
        /// </summary>
        DrawingX2,
        /// <summary>
        /// 
        /// </summary>
        DrawingY2,
        /// <summary>
        /// 
        /// </summary>
        PageNumber,
    }
}
