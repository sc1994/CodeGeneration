using System;

namespace Model
{
    public class M_Message : BaseModel
    {
        public string PrimaryKey = "iMessageID";
        public string IdentityKey = "iMessageID";

        /// <summary>
        /// 
        /// </summary>
        public int iMessageID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string vMessageContent { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string vMessageName { get; set; } = string.Empty;

    }


    public enum M_MessageEnum
    {
        /// <summary>
        /// 
        /// </summary>
        iMessageID,
        /// <summary>
        /// 
        /// </summary>
        vMessageContent,
        /// <summary>
        /// 
        /// </summary>
        vMessageName,
    }
}
