using System;

namespace Model
{
    public class TaskCensorFlow : BaseModel
    {
        public string PrimaryKey = "RowGuid";
        public string IdentityKey = "TaskCensorFlowID";

        /// <summary>
        /// ID
        /// </summary>
        public int TaskCensorFlowID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RowGuid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 操作节点
        /// </summary>
        public int OperationNode { get; set; }

        /// <summary>
        /// 操作事项
        /// </summary>
        public string OperationItem { get; set; } = string.Empty;

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperationMan { get; set; } = string.Empty;

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationDate { get; set; } = ToDateTime("(((1900)-(1))-(1))");

        /// <summary>
        /// 操作时长
        /// </summary>
        public int OperationDuration { get; set; }

        /// <summary>
        /// 是否超时
        /// </summary>
        public int IsOverTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; } = string.Empty;

    }


    public enum TaskCensorFlowEnum
    {
        /// <summary>
        /// ID
        /// </summary>
        TaskCensorFlowID,
        /// <summary>
        /// 
        /// </summary>
        RowGuid,
        /// <summary>
        /// 
        /// </summary>
        TaskID,
        /// <summary>
        /// 操作节点
        /// </summary>
        OperationNode,
        /// <summary>
        /// 操作事项
        /// </summary>
        OperationItem,
        /// <summary>
        /// 操作人
        /// </summary>
        OperationMan,
        /// <summary>
        /// 操作时间
        /// </summary>
        OperationDate,
        /// <summary>
        /// 操作时长
        /// </summary>
        OperationDuration,
        /// <summary>
        /// 是否超时
        /// </summary>
        IsOverTime,
        /// <summary>
        /// 
        /// </summary>
        Description,
    }
}
