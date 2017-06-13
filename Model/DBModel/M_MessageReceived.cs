using System;

namespace Model
{
    public class M_MessageReceived : BaseModel
    {
        public static string PrimaryKey = "MID";
        public static string IdentityKey = "MID";

        /// <summary>
        /// 
        /// </summary>
        public int MID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SendTelNumber { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime ReceiveTime { get; set; } = ToDateTime("('1900-1-1')");

        /// <summary>
        /// 
        /// </summary>
        public string MessageContent { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string IsReaded { get; set; } = string.Empty;

    }


    public enum M_MessageReceivedEnum
    {
        /// <summary>
        /// 
        /// </summary>
        MID,
        /// <summary>
        /// 
        /// </summary>
        SendTelNumber,
        /// <summary>
        /// 
        /// </summary>
        ReceiveTime,
        /// <summary>
        /// 
        /// </summary>
        MessageContent,
        /// <summary>
        /// 
        /// </summary>
        IsReaded,
    }
}
