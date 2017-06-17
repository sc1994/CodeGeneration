using System;

namespace Model.DBModel
{
    public class DongleToken : BaseModel
    {
        public static string PrimaryKey = "Id";
        public static string IdentityKey = "Id";

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Seed { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IssuingName { get; set; } = string.Empty;

    }


    public enum DongleTokenEnum
    {
        /// <summary>
        /// 
        /// </summary>
        Id,
        /// <summary>
        /// 
        /// </summary>
        Token,
        /// <summary>
        /// 
        /// </summary>
        Seed,
        /// <summary>
        /// 
        /// </summary>
        Status,
        /// <summary>
        /// 
        /// </summary>
        IssuingName,
    }
}
