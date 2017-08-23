using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Xml;
using Dapper;
using Newtonsoft.Json;

namespace CodeGeneration
{
    class Program
    {
        public static Info InfoModel = "../../Info.json".GetFileText().ToObjectByJson<Info>();
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            #region 初始化
            START: Logo();
            Console.ReadLine();
            Console.WriteLine("配置文件加载成功");
            ShowInfo();
            if (Console.ReadLine()?.ToLower() != "y")
            {
                goto START;
            }
            Console.Write("初始化");
            Load();
            DirectoryInfo[] directoryInfos;
            try
            {
                directoryInfos = InfoModel.SolutionPath.GetNextFile();
            }
            catch (Exception)
            {
                Console.WriteLine("错误的 SolutionPath 请检查配置文件");
                throw;
            }
            Console.WriteLine("加载解决方案 Success");
            #endregion

            #region 检验必要的文件和路径
            var layersPaths = new Dictionary<string, string>();
            #region Model
            var pathDb = InfoModel.Model.Split('/')[0];
            string path;
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                Console.WriteLine("验证是否存在BaseModel.cs");
                if (File.Exists(path + "\\BaseModel.cs"))
                {
                    ShowGood("已存在BaseModel.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 BaseModel.cs...");
                    try
                    {
                        WriteToFile(GetBaseModelCode(), path + "\\BaseModel.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        ShowError("出现异常-->" + ex.Message);
                    }
                    ShowGood("生成BaseModel.cs Success");
                }
                layersPaths.Add("Model", ExamineFolder(InfoModel.Model, path));

            }
            else
                ShowError($"验证: {InfoModel.Model} Error");
            #endregion

            #region IDAL
            pathDb = InfoModel.IDal.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                Console.WriteLine("验证是否存在BaseModel.cs");
                if (File.Exists(path + "\\BaseModel.cs"))
                {
                    ShowGood("已存在IBaseDal.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 IBaseDal.cs...");
                    try
                    {
                        WriteToFile(GetIBaseDalCode(), path + "\\IBaseDal.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        ShowError("出现异常-->" + ex.Message);
                    }
                    ShowGood("生成IBaseDal.cs Success");
                }
                layersPaths.Add("IDal", ExamineFolder(InfoModel.IDal, path));
            }
            #endregion

            #region DAL
            pathDb = InfoModel.Dal.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                Console.WriteLine("验证是否存在DBClient.cs");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                if (File.Exists(path + "\\DBClient.cs"))
                {
                    ShowGood("已存在DBClient.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 DBClient.cs...");
                    try
                    {
                        WriteToFile(GetDbClientCode(), path + "\\DBClient.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        ShowError("出现异常-->" + ex.Message);
                    }
                    ShowGood("生成BaseModel.cs Success");
                }
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                layersPaths.Add("Dal", ExamineFolder(InfoModel.Dal, path));
            }
            else
                ShowError($"验证: {pathDb} Error");
            #endregion

            #region BLL
            pathDb = InfoModel.Bll.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                Console.WriteLine("验证是否存在BaseBll.cs");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                if (File.Exists(path + "\\BaseBll.cs"))
                {
                    ShowGood("已存在BaseBll.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 BaseBll.cs...");
                    try
                    {
                        WriteToFile(GetBaseBllCode(), path + "\\BaseBll.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        ShowError("出现异常-->" + ex.Message);
                    }
                    ShowGood("生成BaseBll.cs Success");
                }
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                layersPaths.Add("Bll", ExamineFolder(InfoModel.Bll, path));
            }
            else
                ShowError($"验证: {pathDb} Error");
            #endregion
            #endregion

            #region 和数据库握手
            Console.Write("尝试连接: " + InfoModel.DBName);
            Load();
            try
            {
                DataSource.GetConnection();
            }
            catch (Exception)
            {
                ShowError($"连接: {InfoModel.DBName} Error");
                return;
            }
            Console.WriteLine($"连接: {InfoModel.DBName} Success");
            READERROR: Console.WriteLine("输入需要表名以\",\"隔开(整库生成请输入ALL)");
            var tables = Console.ReadLine();

            if (string.IsNullOrEmpty(tables))
            {
                goto READERROR;
            }
            var tableInfoList = GetTableInfos(tables);

            var group = from table in tableInfoList
                        group table by table.TableName
                        into g
                        select g;
            #endregion

            foreach (var g in group)
            {
                foreach (var layersPath in layersPaths)
                {
                    Console.WriteLine($"表: {g.Key}正在生成数据到: {layersPath.Value} ....");
                    switch (layersPath.Key)
                    {
                        #region 生成Model
                        case "Model":

                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Model.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    WriteToFile(GetModelCode(g), layersPath.Value + "\\" + g.Key + ".cs", path + "\\" + InfoModel.Model.Split('/')[0] + ".csproj");
                                }
                                else
                                {
                                    ShowError("路径错误-->跳过 Model ");
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowError("出现异常-->" + ex.Message);
                            }
                            break;
                        #endregion

                        #region 生成BLL
                        case "Bll":
                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Bll.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    if (File.Exists(layersPath.Value + "\\" + g.Key + "Bll.cs"))
                                    {
                                        ShowGood("已存在" + g.Key + "Bll.cs       跳过...");
                                    }
                                    else
                                    {
                                        WriteToFile(GetBllCode(g), layersPath.Value + "\\" + g.Key + "Bll.cs", path + "\\" + InfoModel.Bll.Split('/')[0] + ".csproj");
                                    }
                                }
                                else
                                {
                                    ShowError("路径错误-->跳过 Bll ");
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowError("出现异常-->" + ex.Message);
                            }
                            break;
                        #endregion

                        #region 生成DAL
                        case "Dal":
                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Dal.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    WriteToFile(GetDalCode(g), layersPath.Value + "\\" + g.Key + "Dal.cs", path + "\\" + InfoModel.Dal.Split('/')[0] + ".csproj");
                                    if (File.Exists(layersPath.Value + "\\" + g.Key + "Dal.Extend.cs"))
                                    {
                                        ShowGood("已存在" + g.Key + "Dal.Extend.cs       跳过...");
                                    }
                                    else
                                    {
                                        WriteToFile(GetDalExtendCode(g), layersPath.Value + "\\" + g.Key + "Dal.Extend.cs", path + "\\" + InfoModel.Dal.Split('/')[0] + ".csproj");
                                    }
                                }
                                else
                                {
                                    ShowError("路径错误-->跳过 Dal ");
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowError("出现异常-->" + ex.Message);
                            }
                            break;
                        #endregion

                        #region 生成IDal
                        case "IDal":
                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.IDal.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    WriteToFile(GetIDalCode(g), layersPath.Value + "\\" + "I" + g.Key + "Dal.cs", path + "\\" + InfoModel.IDal.Split('/')[0] + ".csproj");
                                }
                                else
                                {
                                    ShowError("路径错误-->跳过 IDal ");
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowError("出现异常-->" + ex.Message);
                            }
                            break;
                        #endregion
                        default: continue;
                    }
                }
            }
            Console.WriteLine("正在检查程序集之间的引用关系...."); // todo
            Console.ReadLine();
            Console.Clear();
            goto START;
        }


        static StringBuilder GetBaseModelCode()
        {
            var code = new StringBuilder();
            code.AppendLine("using System;\r\n");
            code.AppendLine($"namespace {InfoModel.Model.Split('/')[0]}");
            code.AppendLine("{");
            code.AppendLine("    public class BaseModel");
            code.AppendLine("    {");
            code.AppendLine("        protected static DateTime ToDateTime(string str)");
            code.AppendLine("        {");
            code.AppendLine("            DateTime data;");
            code.AppendLine("            try");
            code.AppendLine("            {");
            code.AppendLine("                data = Convert.ToDateTime(str);");
            code.AppendLine("            }");
            code.AppendLine("            catch (Exception)");
            code.AppendLine("            {");
            code.AppendLine("                data = Convert.ToDateTime(\"1900-01-01\");");
            code.AppendLine("            }");
            code.AppendLine("            return data;");
            code.AppendLine("        }\r\n");
            code.AppendLine("        protected static long Tolong(string str)");
            code.AppendLine("        {");
            code.AppendLine("            long data;");
            code.AppendLine("            try");
            code.AppendLine("            {");
            code.AppendLine("                data = Convert.ToInt64(str);");
            code.AppendLine("            }");
            code.AppendLine("            catch (Exception)");
            code.AppendLine("            {");
            code.AppendLine("                data = 0;");
            code.AppendLine("            }");
            code.AppendLine("            return data;");
            code.AppendLine("        }\r\n");
            code.AppendLine("        protected static int ToInt(string str)");
            code.AppendLine("        {");
            code.AppendLine("            int data;");
            code.AppendLine("            try");
            code.AppendLine("            {");
            code.AppendLine("                data = Convert.ToInt32(str);");
            code.AppendLine("            }");
            code.AppendLine("            catch (Exception)");
            code.AppendLine("            {");
            code.AppendLine("                data = 0;");
            code.AppendLine("            }");
            code.AppendLine("            return data;");
            code.AppendLine("        }\r\n");
            code.AppendLine("        protected static decimal ToDecimal(string str)");
            code.AppendLine("        {");
            code.AppendLine("            decimal data;");
            code.AppendLine("            try");
            code.AppendLine("            {");
            code.AppendLine("                data = Convert.ToDecimal(str);");
            code.AppendLine("            }");
            code.AppendLine("            catch (Exception)");
            code.AppendLine("            {");
            code.AppendLine("                data = 0;");
            code.AppendLine("            }");
            code.AppendLine("            return data;");
            code.AppendLine("        }\r\n");
            code.AppendLine("        protected static double ToDouble(string str)");
            code.AppendLine("        {");
            code.AppendLine("            double data;");
            code.AppendLine("            try");
            code.AppendLine("            {");
            code.AppendLine("                data = Convert.ToDouble(str);");
            code.AppendLine("            }");
            code.AppendLine("            catch (Exception)");
            code.AppendLine("            {");
            code.AppendLine("                data = 0;");
            code.AppendLine("            }");
            code.AppendLine("            return data;");
            code.AppendLine("        }\r\n");
            code.AppendLine("        protected static bool ToBool(string str)");
            code.AppendLine("        {");
            code.AppendLine("            return str == \"1\";");
            code.AppendLine("        }\r\n");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        static StringBuilder GetIBaseDalCode()
        {
            var code = new StringBuilder();
            code.AppendLine($"using {InfoModel.Model.Split('/')[0]};");
            code.AppendLine("using System.Collections.Generic;\r\n");
            code.AppendLine($"namespace {InfoModel.IDal.Split('/')[0]}");
            code.AppendLine("{");
            code.AppendLine("    public interface IBaseDal<TModel, TEnum, TKeyType> where TModel : BaseModel");
            code.AppendLine("    {");
            code.AppendLine("        bool Exists(TKeyType primaryKey);\r\n");
            code.AppendLine("        bool ExistsByWhere(string where);\r\n");
            code.AppendLine("        TKeyType Add(TModel model);\r\n");
            code.AppendLine("        bool Update(TModel model);\r\n");
            code.AppendLine("        bool Update(Dictionary<TEnum, object> updates, string where);\r\n");
            code.AppendLine("        bool Delete(TKeyType primaryKey);\r\n");
            code.AppendLine("        int DeleteByWhere(string where);\r\n");
            code.AppendLine("        TModel GetModel(TKeyType primaryKey);\r\n");
            code.AppendLine("        List<TModel> GetModelList(string where);\r\n");
            code.AppendLine("        List<TModel> GetModelPage(TEnum order, string where, int pageIndex, int pageSize, out int total);\r\n");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        static StringBuilder GetDbClientCode()
        {
            var code = new StringBuilder();
            code.AppendLine("using Dapper;");
            code.AppendLine("using System;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Configuration;");
            code.AppendLine("using System.Data.SqlClient;");
            code.AppendLine("using System.Data;\r\n");
            code.AppendLine($"namespace {InfoModel.Dal.Split('/')[0]}");
            code.AppendLine("{");
            code.AppendLine("    public class DbClient");
            code.AppendLine("    {");
            code.AppendLine("        public static IEnumerable<T> Query<T>(string sql, object param = null)");
            code.AppendLine("        {");
            code.AppendLine("            if (string.IsNullOrEmpty(sql))");
            code.AppendLine("            {");
            code.AppendLine("                throw new ArgumentNullException(nameof(sql));");
            code.AppendLine("            }");
            code.AppendLine("            using (IDbConnection con = DataSource.GetConnection())");
            code.AppendLine("            {");
            code.AppendLine("                IEnumerable<T> tList = con.Query<T>(sql, param);");
            code.AppendLine("                con.Close();");
            code.AppendLine("                return tList;");
            code.AppendLine("            }");
            code.AppendLine("        }\r\n");
            code.AppendLine("        public static int Excute(string sql, object param = null, IDbTransaction transaction = null)");
            code.AppendLine("        {");
            code.AppendLine("            if (string.IsNullOrEmpty(sql))");
            code.AppendLine("            {");
            code.AppendLine("                throw new ArgumentNullException(nameof(sql));");
            code.AppendLine("            }");
            code.AppendLine("            using (IDbConnection con = DataSource.GetConnection())");
            code.AppendLine("            {");
            code.AppendLine("                return con.Execute(sql, param, transaction);");
            code.AppendLine("            }");
            code.AppendLine("        }\r\n");
            code.AppendLine("        public static T ExecuteScalar<T>(string sql, object param = null)");
            code.AppendLine("        {");
            code.AppendLine("            if (string.IsNullOrEmpty(sql))");
            code.AppendLine("            {");
            code.AppendLine("                throw new ArgumentNullException(nameof(sql));");
            code.AppendLine("            }");
            code.AppendLine("            using (IDbConnection con = DataSource.GetConnection())");
            code.AppendLine("            {");
            code.AppendLine("                return con.ExecuteScalar<T>(sql, param);");
            code.AppendLine("            }");
            code.AppendLine("        }\r\n");
            code.AppendLine("        public static T ExecuteScalarProc<T>(string strProcName, object param = null)");
            code.AppendLine("        {");
            code.AppendLine("            using (IDbConnection con = DataSource.GetConnection())");
            code.AppendLine("            {");
            code.AppendLine("                return (T)con.ExecuteScalar(strProcName, param, commandType: CommandType.StoredProcedure);");
            code.AppendLine("            }");
            code.AppendLine("        }\r\n");
            code.AppendLine("        public static IEnumerable<T> ExecuteQueryProc<T>(string strProcName, object param = null)");
            code.AppendLine("        {");
            code.AppendLine("            using (IDbConnection con = DataSource.GetConnection())");
            code.AppendLine("            {");
            code.AppendLine("                IEnumerable<T> tList = con.Query<T>(strProcName, param, commandType: CommandType.StoredProcedure);");
            code.AppendLine("                con.Close();");
            code.AppendLine("                return tList;");
            code.AppendLine("            }");
            code.AppendLine("        }\r\n");
            code.AppendLine("        public static int ExecuteProc(string strProcName, object param = null)");
            code.AppendLine("        {");
            code.AppendLine("            try");
            code.AppendLine("            {");
            code.AppendLine("                using (IDbConnection con = DataSource.GetConnection())");
            code.AppendLine("                {");
            code.AppendLine("                    return con.Execute(strProcName, param, commandType: CommandType.StoredProcedure);");
            code.AppendLine("                }");
            code.AppendLine("            }");
            code.AppendLine("            catch (Exception)");
            code.AppendLine("            {");
            code.AppendLine("                return 0;");
            code.AppendLine("            }");
            code.AppendLine("        }");
            code.AppendLine("    }\r\n\r\n");
            code.AppendLine("    public class DataSource");
            code.AppendLine("    {");
            code.AppendLine("        public static string ConnString = ConfigurationManager.ConnectionStrings[\"DBString\"].ConnectionString;");
            code.AppendLine("        public static IDbConnection GetConnection()");
            code.AppendLine("        {");
            code.AppendLine("            if (string.IsNullOrEmpty(ConnString))");
            code.AppendLine("                throw new NoNullAllowedException(nameof(ConnString));");
            code.AppendLine("            return new SqlConnection(ConnString);");
            code.AppendLine("        }");
            code.AppendLine("    }");
            code.AppendLine("}");

            return code;
        }

        static StringBuilder GetBaseBllCode()
        {
            var code = new StringBuilder();
            code.AppendLine($"using {InfoModel.IDal.Split('/')[0]};");
            code.AppendLine($"using {InfoModel.Model.Split('/')[0]};");
            code.AppendLine("using System.Collections.Generic;\r\n");
            code.AppendLine($"namespace {InfoModel.Bll.Split('/')[0]}");
            code.AppendLine("{");
            code.AppendLine("    public class BaseBll<TModel, TEmun, TKeyType> where TModel : BaseModel");
            code.AppendLine("    {");
            code.AppendLine("        protected IBaseDal<TModel, TEmun, TKeyType> Dal { get; set; }\r\n");
            code.AppendLine("        public BaseBll(IBaseDal<TModel, TEmun, TKeyType> dal)");
            code.AppendLine("        {");
            code.AppendLine("            Dal = dal;");
            code.AppendLine("        }\r\n");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 数据是否存在 (表中没有主键时此方法不适用)");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"primaryKey\">主键</param>");
            code.AppendLine("        /// <returns></returns>");
            code.AppendLine("        public bool Exists(TKeyType primaryKey)");
            code.AppendLine("        {");
            code.AppendLine("            return Dal.Exists(primaryKey);");
            code.AppendLine("        }\r\n");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 数据是否存在");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">条件语句</param>");
            code.AppendLine("        /// <returns></returns>");
            code.AppendLine("        public bool ExistsByWhere(string where)");
            code.AppendLine("        {");
            code.AppendLine("            return Dal.ExistsByWhere(where);");
            code.AppendLine("        }\r\n");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 向表中添加一条数据");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"model\"></param>");
            code.AppendLine("        /// <returns></returns>");
            code.AppendLine("        public TKeyType Add(TModel model)");
            code.AppendLine("        {");
            code.AppendLine("            return Dal.Add(model);");
            code.AppendLine("        }\r\n");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 更新一条数据");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"model\"></param>");
            code.AppendLine("        /// <returns></returns>");
            code.AppendLine("        public bool Update(TModel model)");
            code.AppendLine("        {");
            code.AppendLine("            return Dal.Update(model);");
            code.AppendLine("        }\r\n");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 批量更新");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"updates\">需要更新字段的键值对</param>");
            code.AppendLine("        /// <param name=\"where\">条件语句</param>");
            code.AppendLine("        /// <returns></returns>");
            code.AppendLine("        public bool Update(Dictionary<TEmun, object> updates, string where)");
            code.AppendLine("        {");
            code.AppendLine("            return Dal.Update(updates, where);");
            code.AppendLine("        }\r\n");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 删除一条数据 (表中没有主键时此方法不适用)");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"primaryKey\">主键</param>");
            code.AppendLine("        /// <returns></returns>");
            code.AppendLine("        public bool Delete(TKeyType primaryKey)");
            code.AppendLine("        {");
            code.AppendLine("            return Dal.Delete(primaryKey);");
            code.AppendLine("        }\r\n");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 批量删除");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">条件语句</param>");
            code.AppendLine("        /// <returns></returns>");
            code.AppendLine("        public int DeleteByWhere(string where)");
            code.AppendLine("        {");
            code.AppendLine("            return Dal.DeleteByWhere(where);");
            code.AppendLine("        }\r\n");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 获取对象 (表中没有主键时此方法不适用)");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"primaryKey\">主键</param>");
            code.AppendLine("        /// <returns></returns>");
            code.AppendLine("        public TModel GetModel(TKeyType primaryKey)");
            code.AppendLine("        {");
            code.AppendLine("            return Dal.GetModel(primaryKey);");
            code.AppendLine("        }\r\n");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 获取对象列表");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">条件语句</param>");
            code.AppendLine("        /// <returns></returns>");
            code.AppendLine("        public List<TModel> GetModelList(string where)");
            code.AppendLine("        {");
            code.AppendLine("            return Dal.GetModelList(where);");
            code.AppendLine("        }\r\n");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 获取分页对象列表");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"order\">分页排序的依据</param>");
            code.AppendLine("        /// <param name=\"where\">条件语句</param>");
            code.AppendLine("        /// <param name=\"pageIndex\">开始页数</param>");
            code.AppendLine("        /// <param name=\"pageSize\">每页大小</param>");
            code.AppendLine("        /// <param name=\"total\">out 总数</param>");
            code.AppendLine("        /// <returns></returns>");
            code.AppendLine("        public List<TModel> GetModelPage(TEmun order, string where, int pageIndex, int pageSize, out int total)");
            code.AppendLine("        {");
            code.AppendLine("            return Dal.GetModelPage(order, where, pageIndex, pageSize, out total);");
            code.AppendLine("        }");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        static StringBuilder GetModelCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine("using System;\r\n");
            code.AppendLine($"namespace {InfoModel.Model.Replace("/", ".")}");
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + tableInfo.FirstOrDefault(x => !string.IsNullOrEmpty(x.TableDescribe))?.TableDescribe);
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public class {tableInfo.Key} : BaseModel");
            code.AppendLine("    {");
            code.AppendLine($"        public static string PrimaryKey {{ get; set; }} = \"{tableInfo.FirstOrDefault(x => x.PrimaryKey == "1")?.FieldName ?? ""}\";");
            code.AppendLine($"        public static string IdentityKey {{ get; set; }} = \"{tableInfo.FirstOrDefault(x => x.IdentityKey == "1")?.FieldName ?? ""}\";\r\n");
            foreach (var field in tableInfo)
            {
                code.AppendLine("        /// <summary>");
                code.AppendLine($"        /// {field.Describe}");
                code.AppendLine("        /// </summary>");
                var typeAndDefault = GetTypeAndDefault(field, tableInfo.Key);
                code.AppendLine($"        public {typeAndDefault[0]} {field.FieldName} {{ get; set; }}{typeAndDefault[1]}\r\n");
            }
            code.AppendLine("    }\r\n\r\n");
            code.AppendLine($"    public enum {tableInfo.Key}Enum");
            code.AppendLine("    {");
            foreach (var field in tableInfo)
            {
                code.AppendLine("        /// <summary>");
                code.AppendLine($"        /// {field.Describe}");
                code.AppendLine("        /// </summary>");
                code.AppendLine("        " + field.FieldName + ",");
            }
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        static StringBuilder GetIDalCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine($"using {InfoModel.Model.Replace("/", ".")};\r\n");
            code.AppendLine($"namespace {InfoModel.IDal.Replace("/", ".")}");
            code.AppendLine("{");
            var primaryKey = tableInfo.FirstOrDefault(x => x.PrimaryKey == "1");
            var typeAndDefault = primaryKey != null ? GetTypeAndDefault(primaryKey, "") : new[] { "object", "" };
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + tableInfo.FirstOrDefault(x => !string.IsNullOrEmpty(x.TableDescribe))?.TableDescribe + "  数据接口层");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public interface I{tableInfo.Key}Dal : IBaseDal<{tableInfo.Key}, {tableInfo.Key}Enum, {typeAndDefault[0]}>");
            code.AppendLine("    {\r\n");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        static StringBuilder GetDalCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine("using Dapper;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Linq;");
            code.AppendLine($"using {InfoModel.IDal.Replace("/", ".")};");
            code.AppendLine($"using {InfoModel.Model.Replace("/", ".")};");
            code.AppendLine("using System.Text;\r\n");
            code.AppendLine($"namespace {InfoModel.Dal.Replace("/", ".")}");
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + tableInfo.FirstOrDefault(x => !string.IsNullOrEmpty(x.TableDescribe))?.TableDescribe + "  数据访问层");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public partial class {tableInfo.Key}Dal : I{tableInfo.Key}Dal");
            code.AppendLine("    {");
            var primaryKey = tableInfo.FirstOrDefault(x => x.PrimaryKey == "1");
            var identityKey = tableInfo.FirstOrDefault(x => x.IdentityKey == "1");
            var typeAndDefault = new string[2];
            var tableName = $"{InfoModel.DBName}.dbo.[{tableInfo.Key}]";

            #region 是否存在

            if (primaryKey != null)
            {
                typeAndDefault = GetTypeAndDefault(primaryKey, tableInfo.Key);
                code.AppendLine($"        public bool Exists({typeAndDefault[0]} primaryKey)");
                code.AppendLine("        {");
                code.AppendLine($"            var strSql = \"SELECT COUNT(1) FROM {tableName} WHERE {primaryKey.PrimaryKey} = @primaryKey\";");
                code.AppendLine("            var parameters = new { primaryKey };");
                code.AppendLine("            return DbClient.Excute(strSql, parameters) > 0;");
                code.AppendLine("        }\r\n");
            }
            else
            {
                code.AppendLine($"        public bool Exists(object primaryKey)");
                code.AppendLine("        {");
                code.AppendLine("            return false;");
                code.AppendLine("        }\r\n");
            }

            code.AppendLine("        public bool ExistsByWhere(string where)");
            code.AppendLine($"            => DbClient.ExecuteScalar<int>($\"SELECT COUNT(1) FROM {tableName} WHERE 1 = 1 {{where}};\") > 0;\r\n");
            #endregion

            #region Add
            if (primaryKey != null)
            {
                typeAndDefault = GetTypeAndDefault(primaryKey, tableInfo.Key);
                code.AppendLine($"        public {typeAndDefault[0]} Add({tableInfo.Key} model)");
            }
            else
            {
                code.AppendLine($"        public object Add({tableInfo.Key} model)");
            }
            code.AppendLine("        {");
            code.AppendLine("            var strSql = new StringBuilder();");
            code.AppendLine($"            strSql.Append(\"INSERT INTO {InfoModel.DBName}.dbo.[{tableInfo.Key}] (\");");
            code.AppendLine($"            strSql.Append(\"{tableInfo.Where(x => x.IdentityKey != "1").Aggregate("", (current, x) => current + x.FieldName + ",").TrimEnd(',')}\");");
            code.AppendLine("            strSql.Append(\") VALUES (\");");
            code.AppendLine($"            strSql.Append(\"{tableInfo.Where(x => x.IdentityKey != "1").Aggregate("", (current, x) => current + "@" + x.FieldName + ",").TrimEnd(',')});\");");
            if (primaryKey != null)
            {
                code.AppendLine("            strSql.Append(\"SELECT @@IDENTITY\");");
                code.AppendLine($"            return DbClient.ExecuteScalar<{typeAndDefault[0]}>(strSql.ToString(), model);");
            }
            else
            {
                code.AppendLine("            return DbClient.Excute(strSql.ToString(), model);");
            }
            code.AppendLine("        }\r\n");
            #endregion

            #region Update

            if (primaryKey != null ||
                identityKey != null)
            {
                code.AppendLine($"        public bool Update({tableInfo.Key} model)");
                code.AppendLine("        {");
                code.AppendLine("            var strSql = new StringBuilder();");
                code.AppendLine($"            strSql.Append(\"UPDATE {InfoModel.DBName}.dbo.[{tableInfo.Key}] SET \");");
                code.AppendLine(
                    $"            strSql.Append(\"{tableInfo.Where(x => x.IdentityKey != "1" && x.PrimaryKey != "1").Aggregate("", (current, x) => current + x.FieldName + " = @" + x.FieldName + ",").TrimEnd(',')}\");");
                code.AppendLine(primaryKey != null
                                    ? $"            strSql.Append(\" WHERE {primaryKey.FieldName} = @{primaryKey.FieldName}\");"
                                    : $"            strSql.Append(\" WHERE {identityKey.FieldName} = @{identityKey.FieldName}\");");
                code.AppendLine("            return DbClient.Excute(strSql.ToString(), model) > 0;");
                code.AppendLine("        }\r\n");

            }
            else
            {
                code.AppendLine($"        public bool Update({tableInfo.Key} model)");
                code.AppendLine("        {");
                code.AppendLine("            return false;");
                code.AppendLine("        }\r\n");
            }
            code.AppendLine($"        public bool Update(Dictionary<{tableInfo.Key}Enum, object> updates, string where)");
            code.AppendLine("        {");
            code.AppendLine("            var strSql = new StringBuilder();");
            code.AppendLine($"            strSql.Append(\"UPDATE {InfoModel.DBName}.dbo.[{tableInfo.Key}] SET \");");
            code.AppendLine("            var para = new DynamicParameters();");
            code.AppendLine("            foreach (var update in updates)");
            code.AppendLine("            {");
            code.AppendLine("                strSql.Append($\" {update.Key} = @{update.Key},\");");
            code.AppendLine("                para.Add(update.Key.ToString(), update.Value);");
            code.AppendLine("            }");
            code.AppendLine("            strSql.Remove(strSql.Length - 1, 1);");
            code.AppendLine("            strSql.Append($\" WHERE 1=1 {where}\");");
            code.AppendLine("            return DbClient.Excute(strSql.ToString(), para) > 0;");
            code.AppendLine("        }\r\n");
            #endregion

            #region Delete

            if (primaryKey != null)
            {
                typeAndDefault = GetTypeAndDefault(primaryKey, tableInfo.Key);
                var fileName = primaryKey.FieldName;
                code.AppendLine($"        public bool Delete({typeAndDefault[0]} primaryKey)");
                code.AppendLine("        {");
                code.AppendLine($"            var strSql = \"DELETE FROM {tableName} WHERE {fileName} = @primaryKey\";");
                code.AppendLine("            return DbClient.Excute(strSql, new { primaryKey }) > 0;");
                code.AppendLine("        }\r\n");
            }
            else
            {
                code.AppendLine($"        public bool Delete(object primaryKey)");
                code.AppendLine("        {");
                code.AppendLine("            return false;");
                code.AppendLine("        }\r\n");
            }

            code.AppendLine("        public int DeleteByWhere(string where)");
            code.AppendLine($"            => DbClient.Excute($\"DELETE FROM {tableName} WHERE 1 = 1 {{where}}\");\r\n");
            #endregion

            #region Select

            if (primaryKey != null)
            {
                typeAndDefault = GetTypeAndDefault(primaryKey, tableInfo.Key);
                var fileName = primaryKey.FieldName;
                // 主键查询
                code.AppendLine($"        public {tableInfo.Key} GetModel({typeAndDefault[0]} primaryKey)");
                code.AppendLine("        {");
                code.AppendLine($"            var strSql = \"SELECT * FROM {tableName} WHERE {fileName} = @primaryKey\";");
                code.AppendLine($"            return DbClient.Query<{tableInfo.Key}>(strSql, new {{ primaryKey }}).FirstOrDefault();");
                code.AppendLine("        }\r\n");
            }
            else
            {
                code.AppendLine($"        public {tableInfo.Key} GetModel(object primaryKey)");
                code.AppendLine("        {");
                code.AppendLine("            return null;");
                code.AppendLine("        }\r\n");
            }
            // 普通查询
            code.AppendLine($"        public List<{tableInfo.Key}> GetModelList(string where)");
            code.AppendLine("        {");
            code.AppendLine($"            var strSql = $\"SELECT * FROM {tableName} WHERE 1 = 1 {{where}}\";");
            code.AppendLine($"            return DbClient.Query<{tableInfo.Key}>(strSql).ToList();");
            code.AppendLine("        }\r\n");
            // 分页查询
            code.AppendLine($"        public List<{tableInfo.Key}> GetModelPage({tableInfo.Key}Enum order, string where, int pageIndex, int pageSize, out int total)");
            code.AppendLine("        {");
            code.AppendLine("            var strSql = new StringBuilder();");
            code.AppendLine("            strSql.Append($\"SELECT * FROM ( SELECT TOP ({pageSize})\");");
            code.AppendLine("            strSql.Append($\"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* \");");
            code.AppendLine($"            strSql.Append(\" FROM  {tableName} \");");
            code.AppendLine("            strSql.Append($\" WHERE 1 = 1 {where} \");");
            code.AppendLine("            strSql.Append(\" ) A\");");
            code.AppendLine("            strSql.Append($\" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; \");");
            code.AppendLine($"            total = DbClient.ExecuteScalar<int>($\"SELECT COUNT(1) FROM {tableName} WHERE 1 = 1 {{where}};\");");
            code.AppendLine($"            return DbClient.Query<{tableInfo.Key}>(strSql.ToString()).ToList();");
            code.AppendLine("        }\r\n");
            #endregion

            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        static StringBuilder GetDalExtendCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine($"namespace {InfoModel.Dal.Replace("/", ".")}");
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + tableInfo.FirstOrDefault(x => !string.IsNullOrEmpty(x.TableDescribe))?.TableDescribe + "  数据访问扩展层(此类中的代码不会被覆盖)");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public partial class {tableInfo.Key}Dal");
            code.AppendLine("    {\r\n");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        static StringBuilder GetBllCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine($"using {InfoModel.Dal.Replace("/", ".")};");
            code.AppendLine($"using {InfoModel.IDal.Replace("/", ".")};");
            code.AppendLine($"using {InfoModel.Model.Replace("/", ".")};");
            code.AppendLine($"namespace {InfoModel.Bll.Replace("/", ".")}");
            code.AppendLine("{");
            var primaryKey = tableInfo.FirstOrDefault(x => x.PrimaryKey == "1");
            var typeAndDefault = primaryKey != null ? GetTypeAndDefault(primaryKey, "") : new[] { "object", "" };
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + tableInfo.FirstOrDefault(x => !string.IsNullOrEmpty(x.TableDescribe))?.TableDescribe + "  逻辑层");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public class {tableInfo.Key}Bll : BaseBll<{tableInfo.Key}, {tableInfo.Key}Enum, {typeAndDefault[0]}>");
            code.AppendLine("    {");
            code.AppendLine($"        public {tableInfo.Key}Bll() : base(new {tableInfo.Key}Dal()) {{ }}\r\n");
            code.AppendLine($"        public {tableInfo.Key}Bll(IBaseDal<{tableInfo.Key}, {tableInfo.Key}Enum, {typeAndDefault[0]}> dal) : base(dal) {{ }}");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        static void WriteToFile(StringBuilder sb, string path, string csprojPath)
        {
            if (!File.Exists(path))
            {
                IntoCsproj(csprojPath, string.Join("\\", path.Split('\\').Except(csprojPath.Split('\\'))));
            }
            var sw = File.CreateText(path);
            sw.Write(sb.ToString());
            sw.Close();
        }

        /// <summary>
        /// 在csproj文件中注册,使其包含在项目中
        /// </summary>
        static void IntoCsproj(string path, string fileName)
        {
            var ns = "http://schemas.microsoft.com/developer/msbuild/2003";
            var doc = new XmlDocument();
            doc.Load(path);
            var mgr = new XmlNamespaceManager(doc.NameTable);
            mgr.AddNamespace("x", ns);
            var compile = doc.SelectSingleNode("//x:Compile", mgr);
            var xelKey = doc.CreateElement("Compile", null);
            var xelType = doc.CreateAttribute("Include");
            xelType.Value = fileName.Replace("//", "\\");
            xelKey.SetAttributeNode(xelType);
            var parent = compile?.ParentNode;
            parent?.AppendChild(xelKey);
            if (doc.DocumentElement != null)
            {
                doc.InnerXml = doc.InnerXml.Replace("xmlns=\"\"", "");
            }
            doc.Save(path);
        }

        static IEnumerable<TableInfo> GetTableInfos(string tables)
        {
            var where =
                tables.ToLower() == "all"
                    ? "1=1"
                    : $@"( CASE WHEN a.colorder = 1 THEN d.name
	                               ELSE d.name
	                          END ) IN ('{tables.Replace(",", "','")}')";

            var sql = $@"USE {InfoModel.DBName};
                        SELECT TableName = CASE
                               WHEN a.colorder = 1 THEN
                                   d.name
                               ELSE
                                   ''
                           END,
                           TableDescribe = CASE
                                               WHEN a.colorder = 1 THEN
                                                   ISNULL(f.value, '')
                                               ELSE
                                                   ''
                                           END,
                           (CASE
                                WHEN a.colorder = 1 THEN
                                    d.name
                                ELSE
                                    d.name
                            END
                           ) AS TableName,
                           a.name AS FieldName,
                           (CASE
                                WHEN COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 THEN
                                    '1'
                                ELSE
                                    ''
                            END
                           ) AS IdentityKey,
                           (CASE
                                WHEN
                                (
                                    SELECT COUNT(*)
                                    FROM sysobjects
                                    WHERE (name IN (
                                                       SELECT name
                                                       FROM sysindexes
                                                       WHERE (id = a.id)
                                                             AND (indid IN (
                                                                               SELECT indid
                                                                               FROM sysindexkeys
                                                                               WHERE (id = a.id)
                                                                                     AND (colid IN (
                                                                                                       SELECT colid FROM syscolumns WHERE (id = a.id) AND (name = a.name)
                                                                                                   )
                                                                                         )
                                                                           )
                                                                 )
                                                   )
                                          )
                                          AND (xtype = 'PK')
                                ) > 0 THEN
                                    '1'
                                ELSE
                                    ''
                            END
                           ) AS PrimaryKey,
                           b.name AS Type,
                           COLUMNPROPERTY(a.id, a.name, 'PRECISION') AS Size,
                           ISNULL(e.text, '') AS [Default],
                           ISNULL(g.[value], '') AS Describe
                    FROM syscolumns a
                        LEFT JOIN systypes b
                            ON a.xusertype = b.xusertype
                        INNER JOIN sysobjects d
                            ON a.id = d.id
                               AND d.xtype = 'U'
                               AND d.name <> 'dtproperties'
                        LEFT JOIN syscomments e
                            ON a.cdefault = e.id
                        LEFT JOIN sys.extended_properties g
                            ON a.id = g.major_id
                               AND a.colid = g.minor_id
                        LEFT JOIN sys.extended_properties f
                            ON d.id = f.major_id
                               AND f.minor_id = 0
                    WHERE {where}
                    ORDER BY a.id,
                             a.colorder;";
            return DbClient.Query<TableInfo>(sql);
        }

        /// <summary>
        /// 检查文件夹 且生成
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        static string ExamineFolder(string layer, string path)
        {
            if (layer.Split('/').Length > 1 &&
                    !string.IsNullOrEmpty(layer.Split('/')[1]))
            {
                var pathFolder = layer.Split('/')[1];
                path += "\\" + pathFolder;
                Console.WriteLine($"验证是否存在目录{pathFolder}");
                if (Directory.Exists(path))
                {
                    ShowGood($"已存在{pathFolder}");
                }
                else
                {
                    Console.WriteLine($"正在帮您生成 {pathFolder}...");
                    Directory.CreateDirectory(path);
                    ShowGood($"生成 {pathFolder} Success");
                }
            }
            //获取文件信息
            var fileInfo = new FileInfo(path);
            //获得该文件的访问权限
            var fileSecurity = fileInfo.GetAccessControl();
            //添加ereryone用户组的访问权限规则 完全控制权限
            fileSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            //设置访问权限
            fileInfo.SetAccessControl(fileSecurity);
            return path;
        }

        static string[] GetTypeAndDefault(TableInfo field, string tableName)
        {
            string type;
            var def = "";
            field.Type = field.Type.ToLower();
            if (field.Type == "int"
                || field.Type == "tinyint"
                || field.Type == "smallint")
            {
                type = "int";
            }
            else if (field.Type == "bigint")
            {
                type = "long";
            }
            else if (field.Type == "decimal"
                || field.Type == "smallmoney"
                || field.Type == "money"
                || field.Type == "float")
            {
                type = "decimal";
            }
            else if (field.Type.Contains("char")
                || field.Type.Contains("text")
                || field.Type.Contains("image"))
            {
                type = "string";
                def = " = string.Empty;";
            }
            else if (field.Type == "datetime"
                     ||
                     field.Type == "date")
            {
                type = "DateTime";
                def = $" = ToDateTime(\"{field.Default.Replace("(", "").Replace(")", "").Replace("'", "")}\");";
            }
            else
            {
                type = "object";
                def = " = new object();";
                ShowError($"出现未能识别的数据类型{field.Type}");
            }
            if (field.FieldName == tableName)
            {
                field.FieldName += "_Field";
            }
            return new[] { type, def };
        }

        static void Load()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Console.WriteLine();
        }

        static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(msg);
            Console.ResetColor();
            Console.Write(" ===> 回车继续.....");
            Console.ReadLine();
        }

        static void ShowGood(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("**********************************************************************************");
            Console.WriteLine($"*  解决方案路径 : {InfoModel.SolutionPath} ");
            Console.WriteLine($"*  数据库连接信息 : {InfoModel.DBService} ");
            Console.WriteLine($"*  数据层代码将生成在 : {InfoModel.Dal} 文件夹中 ");
            Console.WriteLine($"*  逻辑层代码将生成在 : {InfoModel.Bll} 文件夹中 ");
            Console.WriteLine($"*  实体层代码将生成在 : {InfoModel.Model} 文件夹中 ");
            Console.WriteLine("*  将使用工厂模式  ");
            //Console.WriteLine($"*  *");
            //Console.WriteLine($"*  *");
            Console.WriteLine("**********************************************************************************");
            Console.WriteLine("请确认配置信息Y/N ?");
            Console.ResetColor();
        }

        static void Logo()
        {
            var log = @"
                                                     _-~~~~-                           
                                                    -   @  @                           
                                                   '         \                         
                                                   |\      .. |         |\    /|       
                                             \     ' `. '\___/` .`.     | \,,/_/       
                                             |\_  /    `-____--//    __/ \/    \       
                                              \ \/    .\\     \/  _--/     (D)  \      
                                               \    .'  \\     |   -/    (_      \     
                                                `.   \  /'     |   /       \_ / ==\    
                                          __------\   |       .'_/         / \_ O o)   
                                         /        _|  /`-__-'/             /   \==/    
                                        /        |   \                    /            
                                       ||         \__/                 \_/\            
                                       ||         /              _      /  |           
                                       | |      /--______      ___\    /\  :           
                                       | /   __-  - _/   ------    |  |   \ \          
                                        |   -  -   /                | |     \ )        
                                        |  |   -  |                 | )     | |        
                                         | |    | |                 | |    | |         
                                         | |    < |                 | |   |_/          
                                         < |    /__\                <  \               
                                         /__\                       /___\          --by : suncheng
                        ";
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var s in log)
            {
                Console.Write(s);
            }
            Console.ResetColor();
        }


        public class DbClient
        {
            public static IEnumerable<T> Query<T>(string sql, object param = null)
            {
                if (string.IsNullOrEmpty(sql))
                {
                    throw new ArgumentNullException(nameof(sql));
                }
                using (var con = DataSource.GetConnection())
                {
                    IEnumerable<T> tList = con.Query<T>(sql, param);
                    con.Close();
                    return tList;
                }
            }

            public static int Excute(string sql, object param = null, IDbTransaction transaction = null)
            {
                if (string.IsNullOrEmpty(sql))
                {
                    throw new ArgumentNullException(nameof(sql));
                }
                using (var con = DataSource.GetConnection())
                {
                    return con.Execute(sql, param, transaction);
                }
            }
            public static T ExecuteScalar<T>(string sql, object param = null)
            {
                if (string.IsNullOrEmpty(sql))
                {
                    throw new ArgumentNullException(nameof(sql));
                }
                using (var con = DataSource.GetConnection())
                {
                    return con.ExecuteScalar<T>(sql, param);
                }
            }

            public static T ExecuteScalarProc<T>(string strProcName, object param = null)
            {
                using (var con = DataSource.GetConnection())
                {
                    return (T)con.ExecuteScalar(strProcName, param, commandType: CommandType.StoredProcedure);
                }
            }

            /// <summary>
            /// 执行带参数的存储过程(查询)
            /// </summary>
            /// <param name="strProcName"></param>
            /// <param name="param"></param>
            /// <returns></returns>
            public static IEnumerable<T> ExecuteQueryProc<T>(string strProcName, object param = null)
            {
                using (var con = DataSource.GetConnection())
                {
                    IEnumerable<T> tList = con.Query<T>(strProcName, param, commandType: CommandType.StoredProcedure);
                    con.Close();
                    return tList;
                }
            }

            /// <summary>
            /// 执行带参数的存储过程
            /// </summary>
            /// <param name="strProcName"></param>
            /// <param name="param"></param>
            /// <returns></returns>
            public static int ExecuteProc(string strProcName, object param = null)
            {
                try
                {
                    using (var con = DataSource.GetConnection())
                    {
                        return con.Execute(strProcName, param, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception)
                {
                    return 0;
                }
            }

        }

        public static class DataSource
        {
            public static string ConnString = InfoModel.DBService;
            public static IDbConnection GetConnection()
            {
                if (string.IsNullOrEmpty(ConnString))
                    throw new NoNullAllowedException(nameof(ConnString));
                return new SqlConnection(ConnString);
            }
        }
    }
    static class Common
    {
        /// <summary>
        /// json 转 object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObjectByJson<T>(this string json)
            => JsonConvert.DeserializeObject<T>(json);

        /// <summary>
        /// object 转 json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
            => JsonConvert.SerializeObject(obj);

        /// <summary>
        /// 获取文件全部文本内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileText(this string path)
            => File.ReadAllText(path);

        /// <summary>
        /// 获取目录下的全部子文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DirectoryInfo[] GetNextFile(this string path)
            => new DirectoryInfo(path).GetDirectories();
    }

    class TableInfo
    {
        public string TableDescribe { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string IdentityKey { get; set; }
        public string PrimaryKey { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Default { get; set; }
        public string Describe { get; set; }
    }

    public class Info
    {
        public string SolutionPath { get; set; }
        public string Dal { get; set; }
        public string Bll { get; set; }
        public string Model { get; set; }
        // ReSharper disable once InconsistentNaming
        public string DBName { get; set; }
        public string DBService { get; set; }
        public bool Factory { get; set; }
        // ReSharper disable once InconsistentNaming
        public string IDal { get; set; }
    }
}
