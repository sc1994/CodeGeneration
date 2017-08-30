using System.Linq;
using System.Text;

namespace CodeGeneration
{
  public  class Code
    {
        public static StringBuilder GetBaseModelCode()
        {
            var code = new StringBuilder();
            code.AppendLine("using System;\r\n");
            code.AppendLine($"namespace {Program.InfoModel.Model.Split('/')[0]}");
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

        public static StringBuilder GetIBaseDalCode()
        {
            var code = new StringBuilder();
            code.AppendLine($"using {Program.InfoModel.Model.Split('/')[0]};");
            code.AppendLine("using System.Collections.Generic;\r\n");
            code.AppendLine($"namespace {Program.InfoModel.IDal.Split('/')[0]}");
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

        public static StringBuilder GetDbClientCode()
        {
            var code = new StringBuilder();
            code.AppendLine("using Dapper;");
            code.AppendLine("using System;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Configuration;");
            code.AppendLine("using System.Data.SqlClient;");
            code.AppendLine("using System.Data;\r\n");
            code.AppendLine($"namespace {Program.InfoModel.Dal.Split('/')[0]}");
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

        public static StringBuilder GetBaseBllCode()
        {
            var code = new StringBuilder();
            code.AppendLine($"using {Program.InfoModel.IDal.Split('/')[0]};");
            code.AppendLine($"using {Program.InfoModel.Model.Split('/')[0]};");
            code.AppendLine("using System.Collections.Generic;\r\n");
            code.AppendLine($"namespace {Program.InfoModel.Bll.Split('/')[0]}");
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

        public static StringBuilder GetModelCode(IGrouping<string, TableInfo> tableInfo)
        {
            var code = new StringBuilder();
            code.AppendLine("using System;\r\n");
            code.AppendLine($"namespace {Program.InfoModel.Model.Replace("/", ".")}");
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
            code.AppendLine($"using {Program.InfoModel.Model.Replace("/", ".")};\r\n");
            code.AppendLine($"namespace {Program.InfoModel.IDal.Replace("/", ".")}");
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
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Linq;");
            code.AppendLine($"using {Program.InfoModel.IDal.Replace("/", ".")};");
            code.AppendLine($"using {Program.InfoModel.Model.Replace("/", ".")};");
            code.AppendLine("using System.Text;\r\n");
            code.AppendLine($"namespace {Program.InfoModel.Dal.Replace("/", ".")}");
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + tableInfo.FirstOrDefault(x => !string.IsNullOrEmpty(x.TableDescribe))?.TableDescribe + "  数据访问层");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public partial class {tableInfo.Key}Dal : I{tableInfo.Key}Dal");
            code.AppendLine("    {");
            var primaryKey = tableInfo.FirstOrDefault(x => x.PrimaryKey == "1");
            var identityKey = tableInfo.FirstOrDefault(x => x.IdentityKey == "1");
            var typeAndDefault = new string[2];
            var tableName = $"{Program.InfoModel.DBName}.dbo.[{tableInfo.Key}]";

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
                code.AppendLine($"        public {typeAndDefault[0]} Add({tableInfo.Key} model)");
            }
            else
            {
                code.AppendLine($"        public object Add({tableInfo.Key} model)");
            }
            code.AppendLine("        {");
            code.AppendLine("            var strSql = new StringBuilder();");
            code.AppendLine($"            strSql.Append(\"INSERT INTO {Program.InfoModel.DBName}.dbo.[{tableInfo.Key}] (\");");
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
                code.AppendLine($"            strSql.Append(\"UPDATE {Program.InfoModel.DBName}.dbo.[{tableInfo.Key}] SET \");");
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
            code.AppendLine($"            strSql.Append(\"UPDATE {Program.InfoModel.DBName}.dbo.[{tableInfo.Key}] SET \");");
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
                typeAndDefault = Helper.GetTypeAndDefault(primaryKey, tableInfo.Key);
                var fileName = primaryKey.FieldName;
                code.AppendLine($"        public bool Delete({typeAndDefault[0]} primaryKey)");
                code.AppendLine("        {");
                code.AppendLine($"            var strSql = \"DELETE FROM {tableName} WHERE {fileName} = @primaryKey\";");
                code.AppendLine("            return DbClient.Excute(strSql, new { primaryKey }) > 0;");
                code.AppendLine("        }\r\n");
            }
            else
            {
                code.AppendLine("        public bool Delete(object primaryKey)");
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
            code.AppendLine($"namespace {Program.InfoModel.Dal.Replace("/", ".")}");
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
            code.AppendLine($"using {Program.InfoModel.Dal.Replace("/", ".")};");
            code.AppendLine($"using {Program.InfoModel.IDal.Replace("/", ".")};");
            code.AppendLine($"using {Program.InfoModel.Model.Replace("/", ".")};");
            code.AppendLine($"namespace {Program.InfoModel.Bll.Replace("/", ".")}");
            code.AppendLine("{");
            var primaryKey = tableInfo.FirstOrDefault(x => x.PrimaryKey == "1");
            var typeAndDefault = primaryKey != null ? Helper.GetTypeAndDefault(primaryKey, "") : new[] { "object", "" };
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
    }
}
