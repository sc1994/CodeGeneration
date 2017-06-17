using System;

namespace Model.DBModel
{
    public class ChargeFormula : BaseModel
    {
        public static string PrimaryKey = "FormulaID";
        public static string IdentityKey = "FormulaID";

        /// <summary>
        /// 公式编号
        /// </summary>
        public int FormulaID { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 公式名称
        /// </summary>
        public string FormulaName { get; set; } = string.Empty;

        /// <summary>
        /// 类型名称
        /// </summary>
        public string FormulaType { get; set; } = string.Empty;

        /// <summary>
        /// 公式类容
        /// </summary>
        public string DisplayFormulaContent { get; set; } = string.Empty;

        /// <summary>
        /// 最低收费额
        /// </summary>
        public decimal MinChargeAmount { get; set; }

        /// <summary>
        /// 优惠限额
        /// </summary>
        public decimal PreferentialQuota { get; set; }

        /// <summary>
        /// 优惠限额折扣
        /// </summary>
        public decimal PreferentialDiscount { get; set; }

        /// <summary>
        /// 最高收费额
        /// </summary>
        public decimal MaxChargeAmount { get; set; }

        /// <summary>
        /// 是否享受其他优惠
        /// </summary>
        public int ISPreferentia { get; set; }

    }


    public enum ChargeFormulaEnum
    {
        /// <summary>
        /// 公式编号
        /// </summary>
        FormulaID,
        /// <summary>
        /// 客户编号
        /// </summary>
        CustomerID,
        /// <summary>
        /// 公式名称
        /// </summary>
        FormulaName,
        /// <summary>
        /// 类型名称
        /// </summary>
        FormulaType,
        /// <summary>
        /// 公式类容
        /// </summary>
        DisplayFormulaContent,
        /// <summary>
        /// 最低收费额
        /// </summary>
        MinChargeAmount,
        /// <summary>
        /// 优惠限额
        /// </summary>
        PreferentialQuota,
        /// <summary>
        /// 优惠限额折扣
        /// </summary>
        PreferentialDiscount,
        /// <summary>
        /// 最高收费额
        /// </summary>
        MaxChargeAmount,
        /// <summary>
        /// 是否享受其他优惠
        /// </summary>
        ISPreferentia,
    }
}
