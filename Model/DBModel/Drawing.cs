using System;

namespace Model
{
    public class Drawing : BaseModel
    {
        public static string PrimaryKey = "RowGuid";
        public static string IdentityKey = "DrawingID";

        /// <summary>
        /// 图纸ID
        /// </summary>
        public int DrawingID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RowGuid { get; set; } = string.Empty;

        /// <summary>
        /// 图纸编号
        /// </summary>
        public string DrawingNumber { get; set; } = string.Empty;

        /// <summary>
        /// 图纸版次
        /// </summary>
        public string DrawingEdition { get; set; } = string.Empty;

        /// <summary>
        /// 图纸名称
        /// </summary>
        public string DrawingName { get; set; } = string.Empty;

        /// <summary>
        /// 图号
        /// </summary>
        public string DrawingSize { get; set; } = string.Empty;

        /// <summary>
        /// 图幅
        /// </summary>
        public string DrawingSpace { get; set; } = string.Empty;

        /// <summary>
        /// 设计人
        /// </summary>
        public string DrawingDesigner { get; set; } = string.Empty;

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime DrawingUploadTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 图纸提交时间
        /// </summary>
        public DateTime DrawingSubmitTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 出图签章时间
        /// </summary>
        public DateTime DrawingSignatureTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 出图签章状态
        /// </summary>
        public int DrawingSignatureStatus { get; set; }

        /// <summary>
        /// 初审时间
        /// </summary>
        public DateTime CheckTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 初审签章状态
        /// </summary>
        public int CheckSignatureStatus { get; set; }

        /// <summary>
        /// 分配时间
        /// </summary>
        public DateTime AllottedTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 审查时间
        /// </summary>
        public DateTime ReviewTime { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 审查签章状态
        /// </summary>
        public int ReviewSignatureStatus { get; set; }

        /// <summary>
        /// 审查合格标记
        /// </summary>
        public int ReviewStatus { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// 项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 工程类别
        /// </summary>
        public int ProjectSupType { get; set; }

        /// <summary>
        /// 材料专业(MaterialProfession)
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 专业value
        /// </summary>
        public int ProfessionValue { get; set; }

        /// <summary>
        /// 图纸分类号
        /// </summary>
        public int DCID { get; set; }

        /// <summary>
        /// 图纸分类名称
        /// </summary>
        public string DrawingClassifyName { get; set; } = string.Empty;

        /// <summary>
        /// 图纸状态(已上传（未提交）、已提交（未接审）、已初审（未分配）、已分配（未审查），已审查)
        /// </summary>
        public int DrawingStatus { get; set; }

        /// <summary>
        /// 图纸类型
        /// </summary>
        public string BlueprintType { get; set; } = string.Empty;

        /// <summary>
        /// 图纸大小
        /// </summary>
        public decimal BlueprintSize { get; set; }

        /// <summary>
        /// 图纸所在路径
        /// </summary>
        public string BlueprintPath { get; set; } = string.Empty;

        /// <summary>
        /// 签章后图纸所在路径
        /// </summary>
        public string SignatureBlueprintPath { get; set; } = string.Empty;

        /// <summary>
        /// 图纸描述
        /// </summary>
        public string BlueprintDescription { get; set; } = string.Empty;

        /// <summary>
        /// 是否盖章字段
        /// </summary>
        public int IsSignature { get; set; }

        /// <summary>
        /// 附件类型ID
        /// </summary>
        public int AttachmentTypeID { get; set; }

    }


    public enum DrawingEnum
    {
        /// <summary>
        /// 图纸ID
        /// </summary>
        DrawingID,
        /// <summary>
        /// 
        /// </summary>
        RowGuid,
        /// <summary>
        /// 图纸编号
        /// </summary>
        DrawingNumber,
        /// <summary>
        /// 图纸版次
        /// </summary>
        DrawingEdition,
        /// <summary>
        /// 图纸名称
        /// </summary>
        DrawingName,
        /// <summary>
        /// 图号
        /// </summary>
        DrawingSize,
        /// <summary>
        /// 图幅
        /// </summary>
        DrawingSpace,
        /// <summary>
        /// 设计人
        /// </summary>
        DrawingDesigner,
        /// <summary>
        /// 上传时间
        /// </summary>
        DrawingUploadTime,
        /// <summary>
        /// 图纸提交时间
        /// </summary>
        DrawingSubmitTime,
        /// <summary>
        /// 出图签章时间
        /// </summary>
        DrawingSignatureTime,
        /// <summary>
        /// 出图签章状态
        /// </summary>
        DrawingSignatureStatus,
        /// <summary>
        /// 初审时间
        /// </summary>
        CheckTime,
        /// <summary>
        /// 初审签章状态
        /// </summary>
        CheckSignatureStatus,
        /// <summary>
        /// 分配时间
        /// </summary>
        AllottedTime,
        /// <summary>
        /// 审查时间
        /// </summary>
        ReviewTime,
        /// <summary>
        /// 审查签章状态
        /// </summary>
        ReviewSignatureStatus,
        /// <summary>
        /// 审查合格标记
        /// </summary>
        ReviewStatus,
        /// <summary>
        /// 任务编号
        /// </summary>
        TaskID,
        /// <summary>
        /// 项目编号
        /// </summary>
        ProjectID,
        /// <summary>
        /// 工程类别
        /// </summary>
        ProjectSupType,
        /// <summary>
        /// 材料专业(MaterialProfession)
        /// </summary>
        Profession,
        /// <summary>
        /// 专业value
        /// </summary>
        ProfessionValue,
        /// <summary>
        /// 图纸分类号
        /// </summary>
        DCID,
        /// <summary>
        /// 图纸分类名称
        /// </summary>
        DrawingClassifyName,
        /// <summary>
        /// 图纸状态(已上传（未提交）、已提交（未接审）、已初审（未分配）、已分配（未审查），已审查)
        /// </summary>
        DrawingStatus,
        /// <summary>
        /// 图纸类型
        /// </summary>
        BlueprintType,
        /// <summary>
        /// 图纸大小
        /// </summary>
        BlueprintSize,
        /// <summary>
        /// 图纸所在路径
        /// </summary>
        BlueprintPath,
        /// <summary>
        /// 签章后图纸所在路径
        /// </summary>
        SignatureBlueprintPath,
        /// <summary>
        /// 图纸描述
        /// </summary>
        BlueprintDescription,
        /// <summary>
        /// 是否盖章字段
        /// </summary>
        IsSignature,
        /// <summary>
        /// 附件类型ID
        /// </summary>
        AttachmentTypeID,
    }
}
