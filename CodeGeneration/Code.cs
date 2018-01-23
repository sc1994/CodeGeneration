using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CodeGeneration
{
    public class Code
    {
        public static StringBuilder GetBaseModelCode()
        {
            var url = "https://raw.githubusercontent.com/sc1994/CodeGeneration/master/CodeGeneration/Template/BaseModel.cs";
            Console.WriteLine("正在获取代码 From " + url);
            Console.WriteLine("这可能需要点时间.....");
            var code = HttpGet(url).Replace(" Template", " " + InfoModel.Info.Model.Split('/')[0]);
            return new StringBuilder(code);
        }

        public static StringBuilder GetIBaseDalCode()
        {
            var url = "https://raw.githubusercontent.com/sc1994/CodeGeneration/master/CodeGeneration/Template/IBaseDal.cs";
            Console.WriteLine("正在获取代码 From " + url);
            Console.WriteLine("这可能需要点时间.....");
            var code = HttpGet(url).Replace(" Template", " " + InfoModel.Info.IDal.Split('/')[0]).Replace("using Model", $"using {InfoModel.Info.Model.Split('/')[0]}");
            return new StringBuilder(code);
        }

        public static StringBuilder GetDbClientCode()
        {
            var url = "https://raw.githubusercontent.com/sc1994/CodeGeneration/master/CodeGeneration/Template/DbCilent.cs";
            Console.WriteLine("正在获取代码 From " + url);
            Console.WriteLine("这可能需要点时间.....");
            var code = HttpGet(url).Replace(" Template", " " + InfoModel.Info.Common.Split('/')[0]);
            return new StringBuilder(code);
        }

        public static StringBuilder GetConvertCode()
        {
            var url = "https://raw.githubusercontent.com/sc1994/ConverHelper/master/ConverHelper.cs";
            Console.WriteLine("正在获取代码 From " + url);
            Console.WriteLine("这可能需要点时间.....");
            var code = HttpGet(url).Replace(" Common", " " + InfoModel.Info.Common.Split('/')[0]);
            return new StringBuilder(code);
        }

        public static StringBuilder GetSqlHelperCode()
        {
            var url = "https://raw.githubusercontent.com/sc1994/SqlHelper/master/SqlHelper/SqlHelper/SqlHelper.cs";
            Console.WriteLine("正在获取代码 From " + url);
            Console.WriteLine("这可能需要点时间.....");
            var code = HttpGet(url).Replace("namespace SqlHelper", "namespace " + InfoModel.Info.Common.Split('/')[0]);
            return new StringBuilder(code);
        }

        public static StringBuilder GetBaseBllCode()
        {
            var url = "https://raw.githubusercontent.com/sc1994/CodeGeneration/master/CodeGeneration/Template/BaseBll.cs";
            Console.WriteLine("正在获取代码 From " + url);
            Console.WriteLine("这可能需要点时间.....");
            var code = HttpGet(url)
                .Replace(" Template", " " + InfoModel.Info.Bll.Split('/')[0])
                .Replace("using IDAL", $"using {InfoModel.Info.IDal.Split('/')[0]}")
                .Replace("using Model", $"using {InfoModel.Info.Model.Split('/')[0]}");
            return new StringBuilder(code);
        }

        public static StringBuilder GetIBaseBllCode()
        {
            var url = "https://raw.githubusercontent.com/sc1994/CodeGeneration/master/CodeGeneration/Template/IBaseBll.cs";
            Console.WriteLine("正在获取代码 From " + url);
            Console.WriteLine("这可能需要点时间.....");
            var code = HttpGet(url)
                .Replace(" Template", " " + InfoModel.Info.IBll.Split('/')[0])
                .Replace("using Model", $"using {InfoModel.Info.Model.Split('/')[0]}");
            return new StringBuilder(code);
        }

        public static StringBuilder GetModelCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine("using System;\r\n");
            code.AppendLine($"namespace {InfoModel.Info.Model.Replace("/", ".")}");
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
                var typeAndDefault = Helper.GetTypeAndDefault(field, tableInfo.Key);
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

        public static StringBuilder GetIDalCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine($"using {InfoModel.Info.Model.Replace("/", ".")};\r\n");
            code.AppendLine($"namespace {InfoModel.Info.IDal.Replace("/", ".")}");
            code.AppendLine("{");
            var primaryKey = tableInfo.FirstOrDefault(x => x.PrimaryKey == "1");
            var typeAndDefault = primaryKey != null ? Helper.GetTypeAndDefault(primaryKey, "") : new[] { "object", "" };
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + tableInfo.FirstOrDefault(x => !string.IsNullOrEmpty(x.TableDescribe))?.TableDescribe + "  数据接口层");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public interface I{tableInfo.Key}Dal : IBaseDal<{tableInfo.Key}, {tableInfo.Key}Enum, {typeAndDefault[0]}>");
            code.AppendLine("    {\r\n");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        public static StringBuilder GetDalCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine("using Dapper;");
            code.AppendLine("using System.Linq;");
            code.AppendLine("using System.Data;");
            code.AppendLine($"using {InfoModel.Info.IDal.Replace("/", ".")};");
            code.AppendLine($"using {InfoModel.Info.Model.Replace("/", ".")};");
            code.AppendLine($"using {InfoModel.Info.Common.Split('/')[0]};");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Text;\r\n");
            code.AppendLine($"namespace {InfoModel.Info.Dal.Replace("/", ".")}");
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + tableInfo.FirstOrDefault(x => !string.IsNullOrEmpty(x.TableDescribe))?.TableDescribe + "  数据访问层");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public partial class {tableInfo.Key}Dal : I{tableInfo.Key}Dal");
            code.AppendLine("    {");
            var primaryKey = tableInfo.FirstOrDefault(x => x.PrimaryKey == "1");
            var identityKey = tableInfo.FirstOrDefault(x => x.IdentityKey == "1");
            var typeAndDefault = new string[2];
            var tableName = $"{InfoModel.Info.DBName}.dbo.[{tableInfo.Key}]";

            #region 是否存在

            if (primaryKey != null)
            {
                typeAndDefault = Helper.GetTypeAndDefault(primaryKey, tableInfo.Key);
                code.AppendLine($"        public bool Exists({typeAndDefault[0]} primaryKey)");
                code.AppendLine("        {");
                code.AppendLine($"            var strSql = \"SELECT COUNT(1) FROM {tableName} WHERE {primaryKey.PrimaryKey} = @primaryKey\";");
                code.AppendLine("            var parameters = new { primaryKey };");
                code.AppendLine("            return DbClient.Excute(strSql, parameters) > 0;");
                code.AppendLine("        }\r\n");
            }
            else
            {
                code.AppendLine("        public bool Exists(object primaryKey)");
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
                typeAndDefault = Helper.GetTypeAndDefault(primaryKey, tableInfo.Key);
                code.AppendLine($"        public {typeAndDefault[0]} Add({tableInfo.Key} model, IDbConnection conn = null, IDbTransaction transaction = null)");
            }
            else
            {
                code.AppendLine($"        public object Add({tableInfo.Key} model, IDbConnection conn = null, IDbTransaction transaction = null)");
            }
            code.AppendLine("        {");
            code.AppendLine("            var strSql = new StringBuilder();");
            code.AppendLine($"            strSql.Append(\"INSERT INTO {InfoModel.Info.DBName}.dbo.[{tableInfo.Key}] (\");");
            code.AppendLine($"            strSql.Append(\"{tableInfo.Where(x => x.IdentityKey != "1").Aggregate("", (current, x) => current + x.FieldName + ",").TrimEnd(',')}\");");
            code.AppendLine("            strSql.Append(\") VALUES (\");");
            code.AppendLine($"            strSql.Append(\"{tableInfo.Where(x => x.IdentityKey != "1").Aggregate("", (current, x) => current + "@" + x.FieldName + ",").TrimEnd(',')});\");");
            if (primaryKey != null)
            {
                code.AppendLine("            strSql.Append(\"SELECT @@IDENTITY\");");
                code.AppendLine($"            return DbClient.ExecuteScalar<{typeAndDefault[0]}>(strSql.ToString(), model, conn, transaction);");
            }
            else
            {
                code.AppendLine("            return DbClient.Excute(strSql.ToString(), model, conn, transaction);");
            }
            code.AppendLine("        }\r\n");
            #endregion

            #region Update

            if (primaryKey != null ||
                identityKey != null)
            {
                code.AppendLine($"        public bool Update({tableInfo.Key} model, IDbConnection conn = null, IDbTransaction transaction = null)");
                code.AppendLine("        {");
                code.AppendLine("            var strSql = new StringBuilder();");
                code.AppendLine($"            strSql.Append(\"UPDATE {InfoModel.Info.DBName}.dbo.[{tableInfo.Key}] SET \");");
                code.AppendLine(
                    $"            strSql.Append(\"{tableInfo.Where(x => x.IdentityKey != "1" && x.PrimaryKey != "1").Aggregate("", (current, x) => current + x.FieldName + " = @" + x.FieldName + ",").TrimEnd(',')}\");");
                code.AppendLine(primaryKey != null
                                    ? $"            strSql.Append(\" WHERE {primaryKey.FieldName} = @{primaryKey.FieldName}\");"
                                    : $"            strSql.Append(\" WHERE {identityKey.FieldName} = @{identityKey.FieldName}\");");
                code.AppendLine("            return DbClient.Excute(strSql.ToString(), model, conn, transaction) > 0;");
                code.AppendLine("        }\r\n");

            }
            else
            {
                code.AppendLine($"        public bool Update({tableInfo.Key} model, IDbConnection conn = null, IDbTransaction transaction = null)");
                code.AppendLine("        {");
                code.AppendLine("            return false;");
                code.AppendLine("        }\r\n");
            }
            code.AppendLine($"        public bool Update(Dictionary<{tableInfo.Key}Enum, object> updates, string where, IDbConnection conn = null, IDbTransaction transaction = null)");
            code.AppendLine("        {");
            code.AppendLine("            var strSql = new StringBuilder();");
            code.AppendLine($"            strSql.Append(\"UPDATE {InfoModel.Info.DBName}.dbo.[{tableInfo.Key}] SET \");");
            code.AppendLine("            var para = new DynamicParameters();");
            code.AppendLine("            foreach (var update in updates)");
            code.AppendLine("            {");
            code.AppendLine("                strSql.Append($\" {update.Key} = @{update.Key},\");");
            code.AppendLine("                para.Add(update.Key.ToString(), update.Value);");
            code.AppendLine("            }");
            code.AppendLine("            strSql.Remove(strSql.Length - 1, 1);");
            code.AppendLine("            strSql.Append($\" WHERE 1=1 {where}\");");
            code.AppendLine("            return DbClient.Excute(strSql.ToString(), para, conn, transaction) > 0;");
            code.AppendLine("        }\r\n");
            #endregion

            #region Delete

            if (primaryKey != null)
            {
                typeAndDefault = Helper.GetTypeAndDefault(primaryKey, tableInfo.Key);
                var fileName = primaryKey.FieldName;
                code.AppendLine($"        public bool Delete({typeAndDefault[0]} primaryKey, IDbConnection conn = null, IDbTransaction transaction = null)");
                code.AppendLine("        {");
                code.AppendLine($"            var strSql = \"DELETE FROM {tableName} WHERE {fileName} = @primaryKey\";");
                code.AppendLine("            return DbClient.Excute(strSql, new { primaryKey }, conn, transaction) > 0;");
                code.AppendLine("        }\r\n");
            }
            else
            {
                code.AppendLine("        public bool Delete(object primaryKey, IDbConnection conn = null, IDbTransaction transaction = null)");
                code.AppendLine("        {");
                code.AppendLine("            return false;");
                code.AppendLine("        }\r\n");
            }

            code.AppendLine("        public int DeleteByWhere(string where, IDbConnection conn = null, IDbTransaction transaction = null)");
            code.AppendLine($"            => DbClient.Excute($\"DELETE FROM {tableName} WHERE 1 = 1 {{where}}\", null, conn, transaction);\r\n");
            #endregion

            #region Select

            if (primaryKey != null)
            {
                typeAndDefault = Helper.GetTypeAndDefault(primaryKey, tableInfo.Key);
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

        public static StringBuilder GetDalExtendCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine($"namespace {InfoModel.Info.Dal.Replace("/", ".")}");
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

        public static StringBuilder GetBllCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine($"using {InfoModel.Info.Dal.Replace("/", ".")};");
            code.AppendLine($"using {InfoModel.Info.IDal.Replace("/", ".")};");
            code.AppendLine($"using {InfoModel.Info.IBll.Split('/')[0]};");
            code.AppendLine($"using {InfoModel.Info.Model.Replace("/", ".")};\r\n");
            code.AppendLine($"namespace {InfoModel.Info.Bll.Replace("/", ".")}");
            code.AppendLine("{");
            var primaryKey = tableInfo.FirstOrDefault(x => x.PrimaryKey == "1");
            var typeAndDefault = primaryKey != null ? Helper.GetTypeAndDefault(primaryKey, "") : new[] { "object", "" };
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + tableInfo.FirstOrDefault(x => !string.IsNullOrEmpty(x.TableDescribe))?.TableDescribe + "  逻辑层(此类中的代码不会被覆盖)");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public class {tableInfo.Key}Bll : BaseBll<{tableInfo.Key}, {tableInfo.Key}Enum, {typeAndDefault[0]}>, I{tableInfo.Key}Bll");
            code.AppendLine("    {");
            code.AppendLine($"        // ReSharper disable once NotAccessedField.Local");
            code.AppendLine($"        private readonly {tableInfo.Key}Dal _dal;");
            code.AppendLine($"        public {tableInfo.Key}Bll({tableInfo.Key}Dal dal) : base(dal)");
            code.AppendLine("        {");
            code.AppendLine("            _dal = dal;");
            code.AppendLine("        }\r\n");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        public static StringBuilder GetIBllCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine($"using {InfoModel.Info.Model.Replace("/", ".")};\r\n");
            code.AppendLine($"namespace {InfoModel.Info.IBll.Replace("/", ".")}");
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + tableInfo.FirstOrDefault(x => !string.IsNullOrEmpty(x.TableDescribe))?.TableDescribe + "  逻辑接口层(此类中的代码不会被覆盖)");
            code.AppendLine("    /// </summary>");
            var primaryKey = tableInfo.FirstOrDefault(x => x.PrimaryKey == "1");
            var typeAndDefault = primaryKey != null ? Helper.GetTypeAndDefault(primaryKey, "") : new[] { "object", "" };
            code.AppendLine($"    public interface I{tableInfo.Key}Bll : IBaseBll<{tableInfo.Key}, {tableInfo.Key}Enum, {typeAndDefault[0]}>");
            code.AppendLine("    {\r\n");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        public static StringBuilder GetDiBindCode(Dictionary<string, string> bindToList)
        {
            var code = new StringBuilder();
            code.AppendLine("//*******************************************");
            code.AppendLine("// 依次绑定了接口和实现之间的关系, ");
            code.AppendLine("// 应可以直接引用其DLL去绑定,");
            code.AppendLine("// 但是不才, 先曲线救国一下 ");
            code.AppendLine("//*******************************************");
            code.AppendLine("using Ninject;");
            code.AppendLine($"using {InfoModel.Info.Bll.Replace("/", ".")};");
            code.AppendLine($"using {InfoModel.Info.Dal.Replace("/", ".")};");
            code.AppendLine($"using {InfoModel.Info.IBll.Replace("/", ".")};");
            code.AppendLine($"using {InfoModel.Info.IDal.Replace("/", ".")};\r\n");
            code.AppendLine($"namespace {InfoModel.Info.Infrastructure.Replace("/", ".")}");
            code.AppendLine("{");
            code.AppendLine("    public class BindToConfig");
            code.AppendLine("    {");
            code.AppendLine("        public static void BindTo(IKernel kernel)");
            code.AppendLine("        {");
            foreach (var bindTo in bindToList)
            {
                code.AppendLine($"            kernel.Bind<{bindTo.Key}>().To<{bindTo.Value}>().InSingletonScope();");
            }
            code.AppendLine("        }");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code;
        }

        public static StringBuilder GetDiBaseCode()
        {
            var url = "https://raw.githubusercontent.com/sc1994/CodeGeneration/master/CodeGeneration/Template/InjectionConfig.cs";
            Console.WriteLine("正在获取代码 From " + url);
            Console.WriteLine("这可能需要点时间.....");
            var code = HttpGet(url);
            return new StringBuilder(code);
        }


        /// <summary>
        /// 发送GET请求 
        /// </summary>
        /// <param name="url">服务器地址</param>
        /// <returns></returns>
        public static string HttpGet(string url)
        {
            try
            {
                //创建Get请求
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                //接受返回来的数据
                var response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();
                // ReSharper disable once AssignNullToNotNullAttribute
                var streamReader = new StreamReader(stream, Encoding.GetEncoding("UTF-8"));
                var retString = streamReader.ReadToEnd();

                streamReader.Close();
                stream.Close();
                response.Close();

                return retString;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
