using System;

namespace Model
{
    public class CensorProblem : BaseModel
    {
        public string PrimaryKey = "ProblemID";
        public string IdentityKey = "ProblemID";

        /// <summary>
        /// 问题编号
        /// </summary>
        public int ProblemID { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string TaskID { get; set; } = string.Empty;

        /// <summary>
        /// TextID(IWebPDF控件中批注ID)
        /// </summary>
        public string TextID { get; set; } = string.Empty;

        /// <summary>
        /// 图纸X坐标
        /// </summary>
        public decimal DrawingX { get; set; }

        /// <summary>
        /// 图纸Y坐标
        /// </summary>
        public decimal DrawingY { get; set; }

        /// <summary>
        /// 专业(对应CensorProfession )
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// 问题描述
        /// </summary>
        public string ProblemDescription { get; set; } = string.Empty;

        /// <summary>
        /// 问题类别
        /// </summary>
        public string ProblemType { get; set; } = string.Empty;

        /// <summary>
        /// 问题子专业
        /// </summary>
        public string ProblemSubMajor { get; set; } = string.Empty;

        /// <summary>
        /// 问题类别号(强标号(分类号))
        /// </summary>
        public int ProblemSetNo { get; set; }

        /// <summary>
        /// 是否严重安全隐患
        /// </summary>
        public int IsHiddenDanger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int InputUser { get; set; }

    }


    public enum CensorProblemEnum
    {
        /// <summary>
        /// 问题编号
        /// </summary>
        ProblemID,
        /// <summary>
        /// 任务编号
        /// </summary>
        TaskID,
        /// <summary>
        /// TextID(IWebPDF控件中批注ID)
        /// </summary>
        TextID,
        /// <summary>
        /// 图纸X坐标
        /// </summary>
        DrawingX,
        /// <summary>
        /// 图纸Y坐标
        /// </summary>
        DrawingY,
        /// <summary>
        /// 专业(对应CensorProfession )
        /// </summary>
        Profession,
        /// <summary>
        /// 问题描述
        /// </summary>
        ProblemDescription,
        /// <summary>
        /// 问题类别
        /// </summary>
        ProblemType,
        /// <summary>
        /// 问题子专业
        /// </summary>
        ProblemSubMajor,
        /// <summary>
        /// 问题类别号(强标号(分类号))
        /// </summary>
        ProblemSetNo,
        /// <summary>
        /// 是否严重安全隐患
        /// </summary>
        IsHiddenDanger,
        /// <summary>
        /// 
        /// </summary>
        InputUser,
    }
}
