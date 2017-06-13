using System;

namespace Model
{
    public class WeiXinMsgArticle : BaseModel
    {
        public static string PrimaryKey = "MAID";
        public static string IdentityKey = "MAID";

        /// <summary>
        /// 
        /// </summary>
        public int MAID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AID { get; set; }

    }


    public enum WeiXinMsgArticleEnum
    {
        /// <summary>
        /// 
        /// </summary>
        MAID,
        /// <summary>
        /// 
        /// </summary>
        MID,
        /// <summary>
        /// 
        /// </summary>
        AID,
    }
}
