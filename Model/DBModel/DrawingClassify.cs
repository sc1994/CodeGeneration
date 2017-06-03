using System;

namespace Model
{
    public class DrawingClassify : BaseModel
    {
        public string PrimaryKey = "DCID";
        public string IdentityKey = "DCID";

        /// <summary>
        /// 
        /// </summary>
        public int DCID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectSupType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DrawingClassifyName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string DrawingClassifyMark { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string DCRemarks { get; set; } = string.Empty;

    }


    public enum DrawingClassifyEnum
    {
        /// <summary>
        /// 
        /// </summary>
        DCID,
        /// <summary>
        /// 
        /// </summary>
        ProjectSupType,
        /// <summary>
        /// 
        /// </summary>
        DrawingClassifyName,
        /// <summary>
        /// 
        /// </summary>
        DrawingClassifyMark,
        /// <summary>
        /// 
        /// </summary>
        DCRemarks,
    }
}
