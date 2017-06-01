using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json;

namespace CodeGeneration
{
    class Program
    {
        public static Info InfoModel = "../../Info.json".GetFileText().ToObjectByJson<Info>();
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
            var arrLayer = InfoModel.Layers.Split(',');
            foreach (var a in arrLayer)
            {
                if (directoryInfos.Any(d => d.FullName.Contains(a)))
                {
                    Console.WriteLine($"验证{a}层 Success");
                }
                else
                {
                    ShowError($"验证{a}层 Error");
                    return;
                }
            }
            Console.Write("尝试连接: " + InfoModel.DBName);
            Load();
            try
            {
                DataSource.GetConnection();
            }
            catch (Exception ex)
            {
                ShowError($"连接: {InfoModel.DBName} Error");
                return;
            }
            Console.WriteLine($"连接: {InfoModel.DBName} Success");
            Console.ReadLine();
        }

        static void Load()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
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

        public class Info
        {
            public string SolutionPath { get; set; }
            public string Layers { get; set; }
            // ReSharper disable once InconsistentNaming
            public string DBService { get; set; }
            // ReSharper disable once InconsistentNaming
            public string DBName { get; set; }
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

}























