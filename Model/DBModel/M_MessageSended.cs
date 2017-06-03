using System;

namespace Model
{
    public class M_MessageSended : BaseModel
    {
        public string PrimaryKey = "MID";
        public string IdentityKey = "MID";

        /// <summary>
        /// 
        /// </summary>
        public int MID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReceiveTelNumber { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime SendTime { get; set; } = ToDateTime("('1900-1-1')");

        /// <summary>
        /// 
        /// </summary>
        public string MessageContent { get; set; } = string.Empty;

    }


    public enum M_MessageSendedEnum
    {
        /// <summary>
        /// 
        /// </summary>
        MID,
        /// <summary>
        /// 
        /// </summary>
        ReceiveTelNumber,
        /// <summary>
        /// 
        /// </summary>
        SendTime,
        /// <summary>
        /// 
        /// </summary>
        MessageContent,
    }
}
