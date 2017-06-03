using System;

namespace Model
{
    public class WeiXinMsgArticle : BaseModel
    {
        public string PrimaryKey = "MAID";
        public string IdentityKey = "MAID";

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
