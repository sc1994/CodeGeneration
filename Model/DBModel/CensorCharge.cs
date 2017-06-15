using System;

namespace Model
{
    public class CensorCharge : BaseModel
    {
        public static string PrimaryKey = "ID";
        public static string IdentityKey = "ID";

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 报审编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal AccountReceivable { get; set; }

        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal RealSum { get; set; }

        /// <summary>
        /// 减免原因
        /// </summary>
        public string ReduceReason { get; set; } = string.Empty;

        /// <summary>
        /// 收费状态
        /// </summary>
        public int ChargeState { get; set; }

        /// <summary>
        /// 收费日期
        /// </summary>
        public DateTime ChargeDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 计算人
        /// </summary>
        public int Calculationer { get; set; }

        /// <summary>
        /// 复核人
        /// </summary>
        public int Reviewer { get; set; }

        /// <summary>
        /// 收费人
        /// </summary>
        public int Charger { get; set; }

    }


    public enum CensorChargeEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ID,
        /// <summary>
        /// 报审编号
        /// </summary>
        TaskID,
        /// <summary>
        /// 客户编号
        /// </summary>
        CustomerID,
        /// <summary>
        /// 应收金额
        /// </summary>
        AccountReceivable,
        /// <summary>
        /// 实收金额
        /// </summary>
        RealSum,
        /// <summary>
        /// 减免原因
        /// </summary>
        ReduceReason,
        /// <summary>
        /// 收费状态
        /// </summary>
        ChargeState,
        /// <summary>
        /// 收费日期
        /// </summary>
        ChargeDate,
        /// <summary>
        /// 计算人
        /// </summary>
        Calculationer,
        /// <summary>
        /// 复核人
        /// </summary>
        Reviewer,
        /// <summary>
        /// 收费人
        /// </summary>
        Charger,
    }
}
