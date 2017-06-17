using System;

namespace Model
{
    public class XFOpinions : BaseModel
    {
        public static string PrimaryKey = "OpinionsID";
        public static string IdentityKey = "OpinionsID";

        /// <summary>
        /// 
        /// </summary>
        public long OpinionsID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string WordPath { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string PDFPath { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string SignatureBlueprintPath { get; set; } = string.Empty;

    }


    public enum XFOpinionsEnum
    {
        /// <summary>
        /// 
        /// </summary>
        OpinionsID,
        /// <summary>
        /// 
        /// </summary>
        CustomerID,
        /// <summary>
        /// 
        /// </summary>
        TaskID,
        /// <summary>
        /// 
        /// </summary>
        WordPath,
        /// <summary>
        /// 
        /// </summary>
        PDFPath,
        /// <summary>
        /// 
        /// </summary>
        SignatureBlueprintPath,
    }
}
