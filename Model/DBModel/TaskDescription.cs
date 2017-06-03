using System;

namespace Model
{
    public class TaskDescription : BaseModel
    {
        public string PrimaryKey = "RowGuid";
        public string IdentityKey = "RowID";

        /// <summary>
        /// 
        /// </summary>
        public long RowID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RowGuid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Creator { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate { get; set; } = ToDateTime("");

        /// <summary>
        /// 
        /// </summary>
        public int OperateType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int IsShow { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime { get; set; } = ToDateTime("");

    }


    public enum TaskDescriptionEnum
    {
        /// <summary>
        /// 
        /// </summary>
        RowID,
        /// <summary>
        /// 
        /// </summary>
        RowGuid,
        /// <summary>
        /// 
        /// </summary>
        Creator,
        /// <summary>
        /// 
        /// </summary>
        CreateDate,
        /// <summary>
        /// 
        /// </summary>
        OperateType,
        /// <summary>
        /// 
        /// </summary>
        Description,
        /// <summary>
        /// 
        /// </summary>
        TaskID,
        /// <summary>
        /// 
        /// </summary>
        IsShow,
        /// <summary>
        /// 
        /// </summary>
        UpdateTime,
    }
}
