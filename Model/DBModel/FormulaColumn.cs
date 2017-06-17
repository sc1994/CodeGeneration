using System;

namespace Model.DBModel
{
    public class FormulaColumn : BaseModel
    {
        public static string PrimaryKey = "FormulaColumnID";
        public static string IdentityKey = "FormulaColumnID";

        /// <summary>
        /// 栏目ID
        /// </summary>
        public int FormulaColumnID { get; set; }

        /// <summary>
        /// 公式编号
        /// </summary>
        public int FormulaID { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        public string FormulaColumnName { get; set; } = string.Empty;

        /// <summary>
        /// 栏目系数
        /// </summary>
        public decimal FormulaColumnmodulu { get; set; }

    }


    public enum FormulaColumnEnum
    {
        /// <summary>
        /// 栏目ID
        /// </summary>
        FormulaColumnID,
        /// <summary>
        /// 公式编号
        /// </summary>
        FormulaID,
        /// <summary>
        /// 栏目名称
        /// </summary>
        FormulaColumnName,
        /// <summary>
        /// 栏目系数
        /// </summary>
        FormulaColumnmodulu,
    }
}
