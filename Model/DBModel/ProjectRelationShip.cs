using System;

namespace Model
{
    public class ProjectRelationShip : BaseModel
    {
        public string PrimaryKey = "ProjectRelationShipID";
        public string IdentityKey = "ProjectRelationShipID";

        /// <summary>
        /// 
        /// </summary>
        public int ProjectRelationShipID { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 节能标准
        /// </summary>
        public string jnbz { get; set; } = string.Empty;

        /// <summary>
        /// 体型系数
        /// </summary>
        public string txxs { get; set; } = string.Empty;

        /// <summary>
        /// 平屋面保温材料
        /// </summary>
        public string wmbwcl { get; set; } = string.Empty;

        /// <summary>
        /// 平屋面保温厚度
        /// </summary>
        public string wmbwhd { get; set; } = string.Empty;

        /// <summary>
        /// 坡屋面保温材料
        /// </summary>
        public string pwmbwcl { get; set; } = string.Empty;

        /// <summary>
        /// 坡屋面保温厚度
        /// </summary>
        public string pwmbwhd { get; set; } = string.Empty;

        /// <summary>
        /// 外墙体保温材料
        /// </summary>
        public string wqtqtcl { get; set; } = string.Empty;

        /// <summary>
        /// 外墙体保温方式
        /// </summary>
        public string wqtbwfs { get; set; } = string.Empty;

        /// <summary>
        /// 外墙体东西南保温材料
        /// </summary>
        public string wqtdxnbwcl { get; set; } = string.Empty;

        /// <summary>
        /// 外墙体北保温
        /// </summary>
        public string wqtbbwcl { get; set; } = string.Empty;

        /// <summary>
        /// 外墙体东西南保温厚度
        /// </summary>
        public string wqtdxnbwhd { get; set; } = string.Empty;

        /// <summary>
        /// 外墙体北保温厚度
        /// </summary>
        public string wqtbbwhd { get; set; } = string.Empty;

        /// <summary>
        /// 冷桥部位保温材料
        /// </summary>
        public string lqbwbwcl { get; set; } = string.Empty;

        /// <summary>
        /// 冷桥部位保温厚度
        /// </summary>
        public string lqbwbwhd { get; set; } = string.Empty;

        /// <summary>
        /// 外窗窗框材料
        /// </summary>
        public string wcckcl { get; set; } = string.Empty;

        /// <summary>
        /// 外窗玻璃材料
        /// </summary>
        public string wcblcl { get; set; } = string.Empty;

        /// <summary>
        /// 外窗中空层厚度
        /// </summary>
        public string wczkchd { get; set; } = string.Empty;

        /// <summary>
        /// 外窗遮阳措施
        /// </summary>
        public string wczycs { get; set; } = string.Empty;

        /// <summary>
        /// 凸窗窗框材料
        /// </summary>
        public string tcckcl { get; set; } = string.Empty;

        /// <summary>
        /// 凸窗玻璃材料
        /// </summary>
        public string tcblcl { get; set; } = string.Empty;

        /// <summary>
        /// 凸窗中空层厚度
        /// </summary>
        public string tczkchd { get; set; } = string.Empty;

        /// <summary>
        /// 凸窗遮阳措施
        /// </summary>
        public string tczycs { get; set; } = string.Empty;

        /// <summary>
        /// 户门
        /// </summary>
        public string hm { get; set; } = string.Empty;

        /// <summary>
        /// 非封闭阳台门芯板
        /// </summary>
        public string ffbytmxb { get; set; } = string.Empty;

        /// <summary>
        /// 架空保温材料
        /// </summary>
        public string jkbwcl { get; set; } = string.Empty;

        /// <summary>
        /// 架空保温厚度
        /// </summary>
        public string jkbwhd { get; set; } = string.Empty;

        /// <summary>
        /// 凸窗顶板保温材料
        /// </summary>
        public string tcdbbwcl { get; set; } = string.Empty;

        /// <summary>
        /// 凸窗顶板保温厚度
        /// </summary>
        public string tcdbbwhd { get; set; } = string.Empty;

        /// <summary>
        /// 暖房保温材料
        /// </summary>
        public string nfbwcl { get; set; } = string.Empty;

        /// <summary>
        /// 暖房保温厚度
        /// </summary>
        public string nfbwhd { get; set; } = string.Empty;

        /// <summary>
        /// 地面保温材料
        /// </summary>
        public string dmbwcl { get; set; } = string.Empty;

        /// <summary>
        /// 地面保温厚度
        /// </summary>
        public string dmbwhd { get; set; } = string.Empty;

        /// <summary>
        /// 地下室外墙保温材料
        /// </summary>
        public string dxswqbwcl { get; set; } = string.Empty;

        /// <summary>
        /// 地下室外墙保温厚度
        /// </summary>
        public string dxswqbwhd { get; set; } = string.Empty;

        /// <summary>
        /// 中庭夏季通风
        /// </summary>
        public string ztxjtf { get; set; } = string.Empty;

        /// <summary>
        /// 幕墙通风
        /// </summary>
        public string mqtf { get; set; } = string.Empty;

        /// <summary>
        /// 分户墙、分户楼板
        /// </summary>
        public string fhq { get; set; } = string.Empty;

        /// <summary>
        /// 节能是否达标
        /// </summary>
        public string jnsfdb { get; set; } = string.Empty;

        /// <summary>
        /// 可再生资源利用
        /// </summary>
        public string kzszyly { get; set; } = string.Empty;

        /// <summary>
        /// 是否安装分项计量装置
        /// </summary>
        public string sfazfxjlzz { get; set; } = string.Empty;

    }


    public enum ProjectRelationShipEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ProjectRelationShipID,
        /// <summary>
        /// 项目编号
        /// </summary>
        ProjectID,
        /// <summary>
        /// 节能标准
        /// </summary>
        jnbz,
        /// <summary>
        /// 体型系数
        /// </summary>
        txxs,
        /// <summary>
        /// 平屋面保温材料
        /// </summary>
        wmbwcl,
        /// <summary>
        /// 平屋面保温厚度
        /// </summary>
        wmbwhd,
        /// <summary>
        /// 坡屋面保温材料
        /// </summary>
        pwmbwcl,
        /// <summary>
        /// 坡屋面保温厚度
        /// </summary>
        pwmbwhd,
        /// <summary>
        /// 外墙体保温材料
        /// </summary>
        wqtqtcl,
        /// <summary>
        /// 外墙体保温方式
        /// </summary>
        wqtbwfs,
        /// <summary>
        /// 外墙体东西南保温材料
        /// </summary>
        wqtdxnbwcl,
        /// <summary>
        /// 外墙体北保温
        /// </summary>
        wqtbbwcl,
        /// <summary>
        /// 外墙体东西南保温厚度
        /// </summary>
        wqtdxnbwhd,
        /// <summary>
        /// 外墙体北保温厚度
        /// </summary>
        wqtbbwhd,
        /// <summary>
        /// 冷桥部位保温材料
        /// </summary>
        lqbwbwcl,
        /// <summary>
        /// 冷桥部位保温厚度
        /// </summary>
        lqbwbwhd,
        /// <summary>
        /// 外窗窗框材料
        /// </summary>
        wcckcl,
        /// <summary>
        /// 外窗玻璃材料
        /// </summary>
        wcblcl,
        /// <summary>
        /// 外窗中空层厚度
        /// </summary>
        wczkchd,
        /// <summary>
        /// 外窗遮阳措施
        /// </summary>
        wczycs,
        /// <summary>
        /// 凸窗窗框材料
        /// </summary>
        tcckcl,
        /// <summary>
        /// 凸窗玻璃材料
        /// </summary>
        tcblcl,
        /// <summary>
        /// 凸窗中空层厚度
        /// </summary>
        tczkchd,
        /// <summary>
        /// 凸窗遮阳措施
        /// </summary>
        tczycs,
        /// <summary>
        /// 户门
        /// </summary>
        hm,
        /// <summary>
        /// 非封闭阳台门芯板
        /// </summary>
        ffbytmxb,
        /// <summary>
        /// 架空保温材料
        /// </summary>
        jkbwcl,
        /// <summary>
        /// 架空保温厚度
        /// </summary>
        jkbwhd,
        /// <summary>
        /// 凸窗顶板保温材料
        /// </summary>
        tcdbbwcl,
        /// <summary>
        /// 凸窗顶板保温厚度
        /// </summary>
        tcdbbwhd,
        /// <summary>
        /// 暖房保温材料
        /// </summary>
        nfbwcl,
        /// <summary>
        /// 暖房保温厚度
        /// </summary>
        nfbwhd,
        /// <summary>
        /// 地面保温材料
        /// </summary>
        dmbwcl,
        /// <summary>
        /// 地面保温厚度
        /// </summary>
        dmbwhd,
        /// <summary>
        /// 地下室外墙保温材料
        /// </summary>
        dxswqbwcl,
        /// <summary>
        /// 地下室外墙保温厚度
        /// </summary>
        dxswqbwhd,
        /// <summary>
        /// 中庭夏季通风
        /// </summary>
        ztxjtf,
        /// <summary>
        /// 幕墙通风
        /// </summary>
        mqtf,
        /// <summary>
        /// 分户墙、分户楼板
        /// </summary>
        fhq,
        /// <summary>
        /// 节能是否达标
        /// </summary>
        jnsfdb,
        /// <summary>
        /// 可再生资源利用
        /// </summary>
        kzszyly,
        /// <summary>
        /// 是否安装分项计量装置
        /// </summary>
        sfazfxjlzz,
    }
}
