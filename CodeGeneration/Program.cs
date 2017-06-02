using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
            Console.WriteLine("配置文件加载成功");
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

            var layersPaths = new Dictionary<string, string>();
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
                        var sw = File.CreateText(path + "\\BaseModel.cs");
                        sw.Write(GetBaseModelCode().ToString());
                        sw.Close();
                        var pathSplit = path.Split('\\');
                        IntoCsproj(path + $"\\{pathSplit[pathSplit.Length - 1]}.csproj", "BaseModel.cs");
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
            pathDb = InfoModel.Bll.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                layersPaths.Add("Bll", ExamineFolder(InfoModel.Bll, path));
            }
            else
                ShowError($"验证: {pathDb} Error");
            pathDb = InfoModel.Dal.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                layersPaths.Add("Dal", ExamineFolder(InfoModel.Dal, path));
            }
            else
                ShowError($"验证: {pathDb} Error");

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
            Console.WriteLine("输入需要表名以\",\"隔开(整库生成请输入ALL)");
            var tables = Console.ReadLine();
            var tableInfoList = GetTableInfos(tables);

            var group = from table in tableInfoList
                        group table by table.TableName
                        into g
                        select g;

            foreach (var g in group)
            {
                foreach (var layersPath in layersPaths)
                {
                    Console.WriteLine($"表: {g.Key}正在生成数据到: {layersPath.Value}");
                    switch (layersPath.Key)
                    {
                        case "Model":

                            break;
                        case "Bll":

                            break;
                        case "Dal":

                            break;
                        default: continue;
                    }
                }
            }

            Console.ReadLine();
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

        static void GetModelCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine("using System;\r\n");
            code.AppendLine($"namespace {InfoModel.Model.Split('/')[0]}");
            code.AppendLine("{");
            code.AppendLine($"    public class {tableInfo.Key} : BaseModel");
            code.AppendLine("    {");
            code.AppendLine($"        public string PrimaryKey = \"{tableInfo.FirstOrDefault(x => x.PrimaryKey == "1")?.FieldName ?? ""}\";");
            code.AppendLine($"        public string IdentityKey = \"{tableInfo.FirstOrDefault(x => x.IdentityKey == "1")?.FieldName ?? ""}\";\r\n");
            foreach (var field in tableInfo)
            {
                code.AppendLine("        /// <summary>");
                code.AppendLine($"        /// {field.Describe}");
                code.AppendLine("        /// </summary>");
                var type = "";
                var def = "";
                field.Type = field.Type.ToLower();
                if (field.Type == "int"
                    || field.Type == "tinyint")
                {

                }
                code.AppendLine("        public {todo} {todo} { get; set; }=\"\"\r\n");
            }
            code.AppendLine("    }");
            code.AppendLine("}");
        }

        static void GetDalCode()
        {

        }

        static void GetBllCode()
        {

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
            xelType.Value = fileName;
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
                tables == "all"
                    ? "1=1"
                    : $@"( CASE WHEN a.colorder = 1 THEN d.name
	                               ELSE d.name
	                          END ) IN ('{tables.Replace(",", "','")}')";

            var sql = $@"SELECT  ( CASE WHEN a.colorder = 1 THEN d.name
                               ELSE d.name
                          END ) AS TableName ,
                        a.name AS FieldName ,
                        ( CASE WHEN COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1
                               THEN '1'
                               ELSE ''
                          END ) AS IdentityKey ,
                        ( CASE WHEN ( SELECT    COUNT(*)
                                      FROM      sysobjects
                                      WHERE     ( name IN (
                                                  SELECT    name
                                                  FROM      sysindexes
                                                  WHERE     ( id = a.id )
                                                            AND ( indid IN (
                                                                  SELECT  indid
                                                                  FROM    sysindexkeys
                                                                  WHERE   ( id = a.id )
                                                                          AND ( colid IN (
                                                                          SELECT
                                                                          colid
                                                                          FROM
                                                                          syscolumns
                                                                          WHERE
                                                                          ( id = a.id )
                                                                          AND ( name = a.name ) ) ) ) ) ) )
                                                AND ( xtype = 'PK' )
                                    ) > 0 THEN '1'
                               ELSE ''
                          END ) AS PrimaryKey ,
                        b.name AS Type ,
                        COLUMNPROPERTY(a.id, a.name, 'PRECISION') AS Size ,
                        ISNULL(e.text, '') AS [Default] ,
                        ISNULL(g.[value], '') AS Describe
                FROM    syscolumns a
                        LEFT JOIN systypes b ON a.xtype = b.xusertype
                        INNER JOIN sysobjects d ON a.id = d.id
                                                   AND d.xtype = 'U'
                                                   AND d.name <> 'dtproperties'
                        LEFT JOIN syscomments e ON a.cdefault = e.id
                        LEFT JOIN sys.extended_properties g ON a.id = g.major_id
                                                               AND a.colid = g.minor_id
	            WHERE {where}
                ORDER BY a.id ,
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
            return path;
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
            Console.ReadLine();
        }

        static void ShowGood(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(msg);
            Console.ResetColor();
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
        }

        public class DbClient
        {
            public static IEnumerable<T> Query<T>(string sql, object param = null)
            {
                if (string.IsNullOrEmpty(sql))
                {
                    throw new ArgumentNullException(nameof(sql));
                }
                using (IDbConnection con = DataSource.GetConnection())
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
                using (IDbConnection con = DataSource.GetConnection())
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
                using (IDbConnection con = DataSource.GetConnection())
                {
                    return con.ExecuteScalar<T>(sql, param);
                }
            }

            public static T ExecuteScalarProc<T>(string strProcName, object param = null)
            {
                using (IDbConnection con = DataSource.GetConnection())
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
                using (IDbConnection con = DataSource.GetConnection())
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
                    using (IDbConnection con = DataSource.GetConnection())
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
        public string TableName;
        public string FieldName;
        public string IdentityKey;
        public string PrimaryKey;
        public string Type;
        public int Size;
        public string Default;
        public string Describe;
    }
}
