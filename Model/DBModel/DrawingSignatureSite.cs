using System;

namespace Model.DBModel
{
    public class DrawingSignatureSite : BaseModel
    {
        public static string PrimaryKey = "SiteID";
        public static string IdentityKey = "SiteID";

        /// <summary>
        /// ID
        /// </summary>
        public int SiteID { get; set; }

        /// <summary>
        /// 图幅
        /// </summary>
        public string DrawingSpace { get; set; } = string.Empty;

        /// <summary>
        /// 设计单位出图签章位置X
        /// </summary>
        public decimal DesignCorpSiteX { get; set; }

        /// <summary>
        /// 设计单位出图签章位置Y
        /// </summary>
        public decimal DesignCorpSiteY { get; set; }

        /// <summary>
        /// 审查单位签章位置X
        /// </summary>
        public decimal CensorCorpSiteX { get; set; }

        /// <summary>
        /// 审查单位签章位置Y
        /// </summary>
        public decimal CensorCorpSiteY { get; set; }

        /// <summary>
        /// 审查人员签章位置X
        /// </summary>
        public decimal ExpertSiteX { get; set; }

        /// <summary>
        /// 审查人员签章位置Y
        /// </summary>
        public decimal ExpertSiteY { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; } = string.Empty;

    }


    public enum DrawingSignatureSiteEnum
    {
        /// <summary>
        /// ID
        /// </summary>
        SiteID,
        /// <summary>
        /// 图幅
        /// </summary>
        DrawingSpace,
        /// <summary>
        /// 设计单位出图签章位置X
        /// </summary>
        DesignCorpSiteX,
        /// <summary>
        /// 设计单位出图签章位置Y
        /// </summary>
        DesignCorpSiteY,
        /// <summary>
        /// 审查单位签章位置X
        /// </summary>
        CensorCorpSiteX,
        /// <summary>
        /// 审查单位签章位置Y
        /// </summary>
        CensorCorpSiteY,
        /// <summary>
        /// 审查人员签章位置X
        /// </summary>
        ExpertSiteX,
        /// <summary>
        /// 审查人员签章位置Y
        /// </summary>
        ExpertSiteY,
        /// <summary>
        /// 备注
        /// </summary>
        Remarks,
    }
}
