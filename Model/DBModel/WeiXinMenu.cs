using System;

namespace Model
{
    public class WeiXinMenu : BaseModel
    {
        public string PrimaryKey = "MenuId";
        public string IdentityKey = "";

        /// <summary>
        /// 
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MenuName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string MenuType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string MenuKey { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string MenuUrl { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int FID { get; set; }

    }


    public enum WeiXinMenuEnum
    {
        /// <summary>
        /// 
        /// </summary>
        MenuId,
        /// <summary>
        /// 
        /// </summary>
        MenuName,
        /// <summary>
        /// 
        /// </summary>
        MenuType,
        /// <summary>
        /// 
        /// </summary>
        MenuKey,
        /// <summary>
        /// 
        /// </summary>
        MenuUrl,
        /// <summary>
        /// 
        /// </summary>
        FID,
    }
}
