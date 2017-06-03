using System;

namespace Model
{
    public class WaitHandle : BaseModel
    {
        public string PrimaryKey = "RowGuid";
        public string IdentityKey = "ID";

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
        public string ShowTitle { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ShowContent { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string TargetUser { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string LinkUrl { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; } = ToDateTime("");

        /// <summary>
        /// 是否显示
        /// </summary>
        public int IsShow { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime PlanFinishTime { get; set; } = ToDateTime("");

    }


    public enum WaitHandleEnum
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
        ShowTitle,
        /// <summary>
        /// 
        /// </summary>
        ShowContent,
        /// <summary>
        /// 
        /// </summary>
        TargetUser,
        /// <summary>
        /// 
        /// </summary>
        TaskID,
        /// <summary>
        /// 
        /// </summary>
        LinkUrl,
        /// <summary>
        /// 
        /// </summary>
        CreateTime,
        /// <summary>
        /// 是否显示
        /// </summary>
        IsShow,
        /// <summary>
        /// 
        /// </summary>
        PlanFinishTime,
    }
}
