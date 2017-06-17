using System;

namespace Model.DBModel
{
    public class ChangeCensor : BaseModel
    {
        public static string PrimaryKey = "ChangeCensorID";
        public static string IdentityKey = "ChangeCensorID";

        /// <summary>
        /// 
        /// </summary>
        public int ChangeCensorID { get; set; }

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
        public string ChangeProject { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ChangeAttachment { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int MasterCensor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CensorOpinions { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int ChangeNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ChangeTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 
        /// </summary>
        public DateTime CensorTime { get; set; } = ToDateTime("1900-1-1");

    }


    public enum ChangeCensorEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ChangeCensorID,
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
        ChangeProject,
        /// <summary>
        /// 
        /// </summary>
        Profession,
        /// <summary>
        /// 
        /// </summary>
        ChangeAttachment,
        /// <summary>
        /// 
        /// </summary>
        MasterCensor,
        /// <summary>
        /// 
        /// </summary>
        CensorOpinions,
        /// <summary>
        /// 
        /// </summary>
        ChangeNum,
        /// <summary>
        /// 
        /// </summary>
        ChangeTime,
        /// <summary>
        /// 
        /// </summary>
        CensorTime,
    }
}
