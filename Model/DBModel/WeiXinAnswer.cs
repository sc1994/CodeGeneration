using System;

namespace Model
{
    public class WeiXinAnswer : BaseModel
    {
        public static string PrimaryKey = "ID";
        public static string IdentityKey = "ID";

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WeiXinNo { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string IDNumber { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string SelectAnswer { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string JudgmentAnswer { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public decimal Score { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime AnswerTime { get; set; } = ToDateTime("1900-1-1");

    }


    public enum WeiXinAnswerEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ID,
        /// <summary>
        /// 
        /// </summary>
        WeiXinNo,
        /// <summary>
        /// 
        /// </summary>
        IDNumber,
        /// <summary>
        /// 
        /// </summary>
        Name,
        /// <summary>
        /// 
        /// </summary>
        Phone,
        /// <summary>
        /// 
        /// </summary>
        SelectAnswer,
        /// <summary>
        /// 
        /// </summary>
        JudgmentAnswer,
        /// <summary>
        /// 
        /// </summary>
        Score,
        /// <summary>
        /// 
        /// </summary>
        AnswerTime,
    }
}
