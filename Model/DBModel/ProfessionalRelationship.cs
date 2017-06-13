using System;

namespace Model
{
    public class ProfessionalRelationship : BaseModel
    {
        public static string PrimaryKey = "PRID";
        public static string IdentityKey = "PRID";

        /// <summary>
        /// 关系ID
        /// </summary>
        public int PRID { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 审查专业
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 材料专业
        /// </summary>
        public string MaterialProfession { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int MaterialProfessionValue { get; set; }

    }


    public enum ProfessionalRelationshipEnum
    {
        /// <summary>
        /// 关系ID
        /// </summary>
        PRID,
        /// <summary>
        /// 客户编号
        /// </summary>
        CustomerID,
        /// <summary>
        /// 审查专业
        /// </summary>
        Profession,
        /// <summary>
        /// 材料专业
        /// </summary>
        MaterialProfession,
        /// <summary>
        /// 
        /// </summary>
        MaterialProfessionValue,
    }
}
