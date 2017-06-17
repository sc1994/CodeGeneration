using System;

namespace Model.DBModel
{
    public class DesignCorpEmployees : BaseModel
    {
        public static string PrimaryKey = "DCEID";
        public static string IdentityKey = "DCEID";

        /// <summary>
        /// 设计人员编号
        /// </summary>
        public int DCEID { get; set; }

        /// <summary>
        /// 设计单位编号
        /// </summary>
        public int DCECorpID { get; set; }

        /// <summary>
        /// 设计人员姓名
        /// </summary>
        public string DCEName { get; set; } = string.Empty;

        /// <summary>
        /// 设计人员所属专业
        /// </summary>
        public string DCEProfession { get; set; } = string.Empty;

        /// <summary>
        /// 注册号
        /// </summary>
        public string DCERegisterSN { get; set; } = string.Empty;

        /// <summary>
        /// 设计人员类型
        /// </summary>
        public int DCEType { get; set; }

    }


    public enum DesignCorpEmployeesEnum
    {
        /// <summary>
        /// 设计人员编号
        /// </summary>
        DCEID,
        /// <summary>
        /// 设计单位编号
        /// </summary>
        DCECorpID,
        /// <summary>
        /// 设计人员姓名
        /// </summary>
        DCEName,
        /// <summary>
        /// 设计人员所属专业
        /// </summary>
        DCEProfession,
        /// <summary>
        /// 注册号
        /// </summary>
        DCERegisterSN,
        /// <summary>
        /// 设计人员类型
        /// </summary>
        DCEType,
    }
}
