using System;

namespace Model
{
    public class WeiXinMsg : BaseModel
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
        public string MsgType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Keyword { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string WXMContent { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime SendTime { get; set; } = ToDateTime("1900-1-1");

    }


    public enum WeiXinMsgEnum
    {
        /// <summary>
        /// 
        /// </summary>
        MID,
        /// <summary>
        /// 
        /// </summary>
        MsgType,
        /// <summary>
        /// 
        /// </summary>
        Keyword,
        /// <summary>
        /// 
        /// </summary>
        WXMContent,
        /// <summary>
        /// 
        /// </summary>
        SendTime,
    }
}
