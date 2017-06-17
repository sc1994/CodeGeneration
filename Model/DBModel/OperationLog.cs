using System;

namespace Model.DBModel
{
    public class OperationLog : BaseModel
    {
        public static string PrimaryKey = "LogId";
        public static string IdentityKey = "LogId";

        /// <summary>
        /// 
        /// </summary>
        public long LogId { get; set; }

        /// <summary>
        /// (0: 短信日志 1:)
        /// </summary>
        public int LogType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LogTitle { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string LogMessage { get; set; } = string.Empty;

        /// <summary>
        /// 日志记录人
        /// </summary>
        public string LogRecorder { get; set; } = string.Empty;

        /// <summary>
        /// 日志受益人
        /// </summary>
        public string LogFavoree { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int LogStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LogStatusDescribe { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime LogCreationTime { get; set; } = ToDateTime("");

    }


    public enum OperationLogEnum
    {
        /// <summary>
        /// 
        /// </summary>
        LogId,
        /// <summary>
        /// (0: 短信日志 1:)
        /// </summary>
        LogType,
        /// <summary>
        /// 
        /// </summary>
        LogTitle,
        /// <summary>
        /// 
        /// </summary>
        LogMessage,
        /// <summary>
        /// 日志记录人
        /// </summary>
        LogRecorder,
        /// <summary>
        /// 日志受益人
        /// </summary>
        LogFavoree,
        /// <summary>
        /// 
        /// </summary>
        LogStatus,
        /// <summary>
        /// 
        /// </summary>
        LogStatusDescribe,
        /// <summary>
        /// 
        /// </summary>
        LogCreationTime,
    }
}
