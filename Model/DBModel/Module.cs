using System;

namespace Model.DBModel
{
    public class Module : BaseModel
    {
        public static string PrimaryKey = "";
        public static string IdentityKey = "";

        /// <summary>
        /// 
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ModuleName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ModuleURL { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ModuleImage { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int ParementModuleID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Roles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int EmployeeRoles { get; set; }

    }


    public enum ModuleEnum
    {
        /// <summary>
        /// 
        /// </summary>
        ModuleId,
        /// <summary>
        /// 
        /// </summary>
        ModuleName,
        /// <summary>
        /// 
        /// </summary>
        ModuleURL,
        /// <summary>
        /// 
        /// </summary>
        ModuleImage,
        /// <summary>
        /// 
        /// </summary>
        ParementModuleID,
        /// <summary>
        /// 
        /// </summary>
        Sequence,
        /// <summary>
        /// 
        /// </summary>
        Roles,
        /// <summary>
        /// 
        /// </summary>
        EmployeeRoles,
    }
}
