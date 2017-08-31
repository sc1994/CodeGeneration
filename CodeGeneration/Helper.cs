﻿using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace CodeGeneration
{
    public static class Helper
    {
        public static void WriteToFile(StringBuilder sb, string path, string csprojPath)
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
        public static void IntoCsproj(string path, string fileName)
        {
            var xml = path.GetFileText();
            var csproj = xml.XmlToObject<Project>();
            // 找到需要配置文件的实体
            foreach (var item in csproj.Items)
            {
                var type = item.GetType();
                if (type.Name == "ProjectItemGroup")
                {
                    var group = item as ProjectItemGroup;
                    if (group?.Compile?.Count > 0)
                    {
                        if (group.Compile != null)
                        {
                            group.Compile.Add(new ProjectItemGroupCompile
                            {
                                Include = fileName
                            });
                        }
                    }
                }
            }
            // 重新写入然后关闭文件
            var sw = File.CreateText(path);
            sw.Write(csproj.ToXml<Project>());
            sw.Close();
        }

        public static IEnumerable<TableInfo> GetTableInfos(string tables)
        {
            var where =
                tables.ToLower() == "all"
                    ? "1=1"
                    : $@"( CASE WHEN a.colorder = 1 THEN d.name
	                               ELSE d.name
	                          END ) IN ('{tables.Replace(",", "','")}')";

            var sql = $@"USE {Program.InfoModel.DBName};
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
        public static string ExamineFolder(string layer, string path)
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

        public static string[] GetTypeAndDefault(TableInfo field, string tableName)
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

        public static void Load()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Console.WriteLine();
        }

        public static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(msg);
            Console.ResetColor();
            Console.Write(" ===> 回车继续.....");
            Console.ReadLine();
        }

        public static void ShowGood(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("**********************************************************************************");
            Console.WriteLine($"*  解决方案路径 : {Program.InfoModel.SolutionPath} ");
            Console.WriteLine($"*  数据库连接信息 : {Program.InfoModel.DBService} ");
            Console.WriteLine($"*  数据层代码将生成在 : {Program.InfoModel.Dal} 文件夹中 ");
            Console.WriteLine($"*  逻辑层代码将生成在 : {Program.InfoModel.Bll} 文件夹中 ");
            Console.WriteLine($"*  实体层代码将生成在 : {Program.InfoModel.Model} 文件夹中 ");
            Console.WriteLine("*  将使用工厂模式  ");
            //Console.WriteLine($"*  *");
            //Console.WriteLine($"*  *");
            Console.WriteLine("**********************************************************************************");
            Console.WriteLine("请确认配置信息Y/N ?");
            Console.ResetColor();
        }

        public static void Logo()
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

        /// <summary>
        /// json 转 object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObjectByJson<T>(this string json)
            => JsonConvert.DeserializeObject<T>(json);

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

        #region XML 类型转换
        public static T XmlToObject<T>(this string xml)
        {
            using (var rdr = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(rdr);
            }
        }

        public static string ToXml<T>(this object o)
        {
            var xsSubmit = new XmlSerializer(typeof(T));
            using (var sww = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, o);
                    return XElement.Parse(sww.ToString()).ToString();
                }
            }
        }
        #endregion
    }
}