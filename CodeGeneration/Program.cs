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
            START: Console.WriteLine("配置文件加载成功");
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

            foreach (var g in group)
            {
                foreach (var layersPath in layersPaths)
                {
                    Console.WriteLine($"表: {g.Key}正在生成数据到: {layersPath.Value}");
                    switch (layersPath.Key)
                    {
                        case "Model":
                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Model.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    WriteToFile(GetModelCode(g), layersPath.Value + "//" + g.Key + ".cs", path + "\\" + InfoModel.Model.Split('/')[0] + ".csproj");
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
                        case "Bll":

                            break;
                        case "Dal":

                            break;
                        default: continue;
                    }
                }
            }

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
            code.AppendLine($"        public static string ConnString = ConfigurationManager.ConnectionStrings[\"{InfoModel.DBName}\"].ConnectionString;");
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

        static StringBuilder GetModelCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine("using System;\r\n");
            code.AppendLine($"namespace {InfoModel.Model.Split('/')[0]}");
            code.AppendLine("{");
            code.AppendLine($"    public class {tableInfo.Key} : BaseModel");
            code.AppendLine("    {");
            code.AppendLine($"        public static string PrimaryKey = \"{tableInfo.FirstOrDefault(x => x.PrimaryKey == "1")?.FieldName ?? ""}\";");
            code.AppendLine($"        public static string IdentityKey = \"{tableInfo.FirstOrDefault(x => x.IdentityKey == "1")?.FieldName ?? ""}\";\r\n");
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

        static StringBuilder GetDalCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine("using System;\r\n");
            code.AppendLine($"namespace {InfoModel.Dal.Split('/')[0]}");
            code.AppendLine("{");
            code.AppendLine($"    public partial class {tableInfo.Key}Dal");
            code.AppendLine("    {");
            var primaryKey = tableInfo.FirstOrDefault(x => x.PrimaryKey == "1");
            var identityKey = tableInfo.FirstOrDefault(x => x.IdentityKey == "1");
            var typeAndDefault = new string[2];
            var tableName = $"{InfoModel.DBName}.dbo.{tableInfo.Key}";

            #region 是否存在的Id
            if (primaryKey != null)
            {
                typeAndDefault = GetTypeAndDefault(primaryKey, tableInfo.Key);
                code.AppendLine($"        public bool Exists({typeAndDefault[0]} primaryKey);");
                code.AppendLine("        {");
                code.AppendLine($"            var strSql = \"SELECT COUNT(1) FROM {tableName} WHERE {primaryKey.PrimaryKey} = @primaryKey\";");
                code.AppendLine("            var parameters = new { primaryKey };");
                code.AppendLine("            return DbClient.Excute(strSql, parameters) > 0;");
                code.AppendLine("        }\r\n");
            }
            #endregion

            #region Add
            if (identityKey != null)
            {
                typeAndDefault = GetTypeAndDefault(primaryKey, tableInfo.Key);
                code.AppendLine($"        public {typeAndDefault[0]} Add({tableInfo.Key} model)");
            }
            else
            {
                code.AppendLine($"        public void Add({tableInfo.Key} model)");
            }
            code.AppendLine("        {");
            code.AppendLine("             var strSql = new StringBuilder();");
            code.AppendLine($"             strSql.Append(\"INSERT INTO {InfoModel.DBName}.dbo{tableInfo.Key}(\");");
            code.AppendLine($"             strSql.Append(\"{tableInfo.Aggregate("", (current, x) => current + x.FieldName + ",").TrimEnd(',')}\");");
            code.AppendLine("             strSql.Append(\") VALUES (\");");
            code.AppendLine($"             strSql.Append(\"{tableInfo.Aggregate("", (current, x) => current + "@" + x.FieldName + ",").TrimEnd(',')});\");");
            code.AppendLine("             strSql.Append(\"SELECT @@IDENTITY\");");
            if (identityKey != null)
            {
                code.AppendLine("             strSql.Append(\"SELECT @@IDENTITY\");");
                code.AppendLine($"             return DbClient.ExecuteScalar<{typeAndDefault[0]}>(strSql.ToString(), model);");
            }
            else
            {
                code.AppendLine("             DbClient.Excute(strSql.ToString(), model);");
            }
            code.AppendLine("        }\r\n");
            #endregion

            #region Update
            if (primaryKey != null ||
                identityKey != null)
            {
                code.AppendLine($"        public bool Update({tableInfo.Key} model);");
                code.AppendLine("        {");
                code.AppendLine("            var strSql = new StringBuilder();");
                code.AppendLine($"            strSql.Append(\"UPDATE {InfoModel.DBName}.dbo{tableInfo.Key} SET \");");
                code.AppendLine(
                    $"            strSql.Append(\"{tableInfo.Where(x => x.IdentityKey != "1" && x.PrimaryKey != "1").Aggregate("", (current, x) => current + x.FieldName + " = @" + x.FieldName + ",").TrimEnd(',')}\");");
                code.AppendLine(primaryKey != null
                                    ? $"            strSql.Append(\" WHERE {primaryKey.FieldName} = @{primaryKey.FieldName}\");"
                                    : $"            strSql.Append(\" WHERE {identityKey.FieldName} = @{identityKey.FieldName}\");");
                code.AppendLine("            return DbClient.Excute(strSql.ToString(), model) > 0;");
                code.AppendLine("        }\r\n");

            }
            code.AppendLine("        public bool Update(string where);");
            code.AppendLine("        {");
            code.AppendLine($"        strSql.Append(\"UPDATE {InfoModel.DBName}.dbo{tableInfo.Key} SET \");");
            code.AppendLine(
                $"            strSql.Append(\"{tableInfo.Where(x => x.IdentityKey != "1" && x.PrimaryKey != "1").Aggregate("", (current, x) => current + x.FieldName + " = @" + x.FieldName + ",").TrimEnd(',')}\");");
            code.AppendLine("        strSql.Append(\" WHERE 1=1 {where}\")");
            code.AppendLine("            return DbClient.Excute(strSql.ToString(), model) > 0;");
            code.AppendLine("        }\r\n");
            #endregion

            #region Delete
            if (primaryKey != null ||
                identityKey != null)
            {
                typeAndDefault = GetTypeAndDefault(primaryKey, tableInfo.Key);
                var fileName = primaryKey?.FieldName;
                if (string.IsNullOrEmpty(typeAndDefault[0]))
                {
                    typeAndDefault = GetTypeAndDefault(identityKey, tableInfo.Key);
                    fileName = identityKey?.FieldName;
                }
                code.AppendLine($"        public bool Delete({typeAndDefault[0]} key);");
                code.AppendLine("        {");
                code.AppendLine($"            var strSql = \"DELETE FROM {tableName} WHERE {fileName} = @key\";");
                code.AppendLine("            var parameters = new {{ key }};");
                code.AppendLine("            return DbClient.Excute(strSql, parameters) > 0;");
                code.AppendLine("        }\r\n");
            }

            code.AppendLine("        public int Delete(string where);");
            code.AppendLine("        {");
            code.AppendLine($"            var strSql = \"DELETE FROM {tableName} WHERE 1=1 {{where}}\";");
            code.AppendLine("            return DbClient.Excute(strSql) > 0;");
            code.AppendLine("        }\r\n");
            #endregion

            #region Select
            if (primaryKey != null ||
                identityKey != null)
            {
                typeAndDefault = GetTypeAndDefault(primaryKey, tableInfo.Key);
                var fileName = primaryKey?.FieldName;
                if (string.IsNullOrEmpty(typeAndDefault[0]))
                {
                    typeAndDefault = GetTypeAndDefault(identityKey, tableInfo.Key);
                    fileName = identityKey?.FieldName;
                }
                code.AppendLine($"        public {tableInfo.Key} GetModel({typeAndDefault[0]} key);");
                code.AppendLine("        {");
                code.AppendLine($"            var strSql = \"SELECT * FROM {tableName} WHERE {fileName} = @key\";");
                code.AppendLine("            var parameters = new {{ key }};");
                code.AppendLine("            return DbClient.Query<{tableInfo.Key}>(strSql, parameters).FirstOrDefault();");
                code.AppendLine("        }\r\n");
            }

            code.AppendLine($"        public List<{tableInfo.Key}> GetModelList(string where);");
            code.AppendLine("        {");
            code.AppendLine($"            var strSql = \"SELECT * FROM {tableName} WHERE {{where}}\";");
            code.AppendLine("            return DbClient.Query<{tableInfo.Key}>(strSql).ToList();");
            code.AppendLine("        }\r\n");

            code.AppendLine($"        public List<{tableInfo.Key}> GetModelPage(string where, int pageIndex, int pageSize);");
            code.AppendLine("        {");
            code.AppendLine($"            var strSql = \"SELECT * FROM {tableName} WHERE {{where}}\";");
            code.AppendLine("            return DbClient.Query<{tableInfo.Key}>(strSql).ToList();");
            code.AppendLine("        }\r\n");

            #endregion

            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        static void GetBllCode()
        {

        }

        static void WriteToFile(StringBuilder sb, string path, string csprojPath)
        {
            var pathSplit = path.Split('\\');
            if (!File.Exists(path))
            {
                IntoCsproj(csprojPath, pathSplit[pathSplit.Length - 1]);
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
                || field.Type == "tinyint")
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
                || field.Type.Contains("text"))
            {
                type = "string";
                def = " = string.Empty;";
            }
            else if (field.Type == "datetime"
                     ||
                     field.Type == "date")
            {
                type = "DateTime";
                def = $" = ToDateTime(\"{field.Default}\");";
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
