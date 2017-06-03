using System;

namespace Model
{
    public class WeiXinSelect : BaseModel
    {
        public string PrimaryKey = "";
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
        public string OptionA { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string OptionB { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string OptionC { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string OptionD { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Answer { get; set; } = string.Empty;

    }


    public enum WeiXinSelectEnum
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
        OptionA,
        /// <summary>
        /// 
        /// </summary>
        OptionB,
        /// <summary>
        /// 
        /// </summary>
        OptionC,
        /// <summary>
        /// 
        /// </summary>
        OptionD,
        /// <summary>
        /// 
        /// </summary>
        Answer,
    }
}
