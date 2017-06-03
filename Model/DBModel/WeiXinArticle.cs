using System;

namespace Model
{
    public class WeiXinArticle : BaseModel
    {
        public string PrimaryKey = "AID";
        public string IdentityKey = "AID";

        /// <summary>
        /// 
        /// </summary>
        public int AID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string WXContent { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; } = ToDateTime("(((1900)-(1))-(1))");

    }


    public enum WeiXinArticleEnum
    {
        /// <summary>
        /// 
        /// </summary>
        AID,
        /// <summary>
        /// 
        /// </summary>
        Title,
        /// <summary>
        /// 
        /// </summary>
        Description,
        /// <summary>
        /// 
        /// </summary>
        Image,
        /// <summary>
        /// 
        /// </summary>
        Url,
        /// <summary>
        /// 
        /// </summary>
        WXContent,
        /// <summary>
        /// 
        /// </summary>
        AddTime,
    }
}
