using System;

namespace Model
{
    public class RegionInfo : BaseModel
    {
        public string PrimaryKey = "RegionID";
        public string IdentityKey = "RegionID";

        /// <summary>
        /// 区域编号
        /// </summary>
        public int RegionID { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string RegionName { get; set; } = string.Empty;

        /// <summary>
        /// 区域缩写
        /// </summary>
        public string RegionNo { get; set; } = string.Empty;

        /// <summary>
        /// 设防烈度
        /// </summary>
        public string Sfld { get; set; } = string.Empty;

        /// <summary>
        /// 设防分组
        /// </summary>
        public string Sffz { get; set; } = string.Empty;

        /// <summary>
        /// 地震加速度
        /// </summary>
        public string dzjsd { get; set; } = string.Empty;

    }


    public enum RegionInfoEnum
    {
        /// <summary>
        /// 区域编号
        /// </summary>
        RegionID,
        /// <summary>
        /// 区域名称
        /// </summary>
        RegionName,
        /// <summary>
        /// 区域缩写
        /// </summary>
        RegionNo,
        /// <summary>
        /// 设防烈度
        /// </summary>
        Sfld,
        /// <summary>
        /// 设防分组
        /// </summary>
        Sffz,
        /// <summary>
        /// 地震加速度
        /// </summary>
        dzjsd,
    }
}
