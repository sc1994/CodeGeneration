using System;

namespace Model.DBModel
{
    public class ConfigTable : BaseModel
    {
        public static string PrimaryKey = "ID";
        public static string IdentityKey = "ID";

        /// <summary>
        /// 配置ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 配置类型
        /// </summary>
        public string ConfigType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// 配置值
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// 配置排序
        /// </summary>
        public int ConfigOrder { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; } = string.Empty;

    }


    public enum ConfigTableEnum
    {
        /// <summary>
        /// 配置ID
        /// </summary>
        ID,
        /// <summary>
        /// 配置类型
        /// </summary>
        ConfigType,
        /// <summary>
        /// 
        /// </summary>
        Text,
        /// <summary>
        /// 配置值
        /// </summary>
        Value,
        /// <summary>
        /// 配置排序
        /// </summary>
        ConfigOrder,
        /// <summary>
        /// 备注
        /// </summary>
        Remarks,
    }
}
