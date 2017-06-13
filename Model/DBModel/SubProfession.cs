using System;

namespace Model
{
    public class SubProfession : BaseModel
    {
        public static string PrimaryKey = "SubProfessionID";
        public static string IdentityKey = "SubProfessionID";

        /// <summary>
        /// ID
        /// </summary>
        public int SubProfessionID { get; set; }

        /// <summary>
        /// 子专业
        /// </summary>
        public string SubProfession_Field { get; set; } = string.Empty;

        /// <summary>
        /// 审查专业
        /// </summary>
        public string Profession { get; set; } = string.Empty;

    }


    public enum SubProfessionEnum
    {
        /// <summary>
        /// ID
        /// </summary>
        SubProfessionID,
        /// <summary>
        /// 子专业
        /// </summary>
        SubProfession_Field,
        /// <summary>
        /// 审查专业
        /// </summary>
        Profession,
    }
}
