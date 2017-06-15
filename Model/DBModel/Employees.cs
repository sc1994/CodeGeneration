using System;

namespace Model
{
    public class Employees : BaseModel
    {
        public static string PrimaryKey = "";
        public static string IdentityKey = "";

        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmployeeName { get; set; } = string.Empty;

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Telephone { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string EmployeeContent { get; set; } = string.Empty;

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// 职务
        /// </summary>
        public string Post { get; set; } = string.Empty;

        /// <summary>
        /// 照片
        /// </summary>
        public string Photo { get; set; } = string.Empty;

        /// <summary>
        /// 员工角色
        /// </summary>
        public int EmployeeRoles { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard { get; set; } = string.Empty;

        /// <summary>
        /// 员工签名
        /// </summary>
        public string Employeesign { get; set; } = string.Empty;

    }


    public enum EmployeesEnum
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        EmployeeID,
        /// <summary>
        /// 员工编号
        /// </summary>
        EmployeeCode,
        /// <summary>
        /// 员工姓名
        /// </summary>
        EmployeeName,
        /// <summary>
        /// 手机号码
        /// </summary>
        Mobile,
        /// <summary>
        /// 电话号码
        /// </summary>
        Telephone,
        /// <summary>
        /// Email
        /// </summary>
        Email,
        /// <summary>
        /// 备注
        /// </summary>
        EmployeeContent,
        /// <summary>
        /// 部门
        /// </summary>
        Department,
        /// <summary>
        /// 职务
        /// </summary>
        Post,
        /// <summary>
        /// 照片
        /// </summary>
        Photo,
        /// <summary>
        /// 员工角色
        /// </summary>
        EmployeeRoles,
        /// <summary>
        /// 身份证号
        /// </summary>
        IdCard,
        /// <summary>
        /// 员工签名
        /// </summary>
        Employeesign,
    }
}
