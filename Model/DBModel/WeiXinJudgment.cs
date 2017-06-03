using System;

namespace Model
{
    public class WeiXinJudgment : BaseModel
    {
        public string PrimaryKey = "ID";
        public string IdentityKey = "ID";

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Answer { get; set; } = string.Empty;

    }


    public enum WeiXinJudgmentEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ID,
        /// <summary>
        /// 
        /// </summary>
        Subject,
        /// <summary>
        /// 
        /// </summary>
        Answer,
    }
}
