using Dapper;
using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class DbClient
    {
        /// <summary>
        /// 执行带参查询
        /// </summary>
        /// <typeparam name="T">返回列表类型</typeparam>
        /// <param name="sql">脚本</param>
        /// <param name="param">参数</param>
        /// <returns>列表</returns>
        public static IEnumerable<T> Query<T>(string sql, object param = null)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }
            using (var con = DataSource.GetConnection())
            {
                try
                {
                    return con.Query<T>(sql, param);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + "------------ SQL:" + sql);
                }
            }
        }

        /// <summary>
        /// 执行 sql 返回受影响行数
        /// </summary>
        /// <param name="sql">脚本</param>
        /// <param name="param">参数</param>
        /// <param name="connection">连接池(当您传入此参数,那么请记得释放连接池)</param>
        /// <param name="transaction">事务</param>
        /// <returns>受影响行数</returns>
        public static int Excute(string sql, object param = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }
            var isClose = connection == null;
            var con = connection ?? DataSource.GetConnection();
            try
            {
                return con.Execute(sql, param, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "-------------- SQL:" + sql);
            }
            finally
            {
                if (isClose)
                    con.Close();
            }
        }

        /// <summary>
        /// 返回单个值/对象
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="sql">脚本</param>
        /// <param name="param">参数</param>
        /// <param name="connection">连接池(当您传入此参数,那么请记得释放连接池)</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(string sql, object param = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }
            var isClose = connection == null;
            var con = connection ?? DataSource.GetConnection();
            try
            {
                return con.ExecuteScalar<T>(sql, param, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "-------------- SQL:" + sql);
            }
            finally
            {
                if (isClose)
                    con.Close();
            }
        }

        /// <summary>
        /// 执行带参数的存储过程
        /// </summary>
        /// <typeparam name="T">返回值</typeparam>
        /// <param name="strProcName">存储过程名称</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static T ExecuteScalarProc<T>(string strProcName, object param = null)
        {
            using (var con = DataSource.GetConnection())
            {
                return (T)con.ExecuteScalar(strProcName, param, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 执行存储过程(查询)
        /// </summary>
        /// <typeparam name="T">返回列表类型</typeparam>
        /// <param name="strProcName">存储过程名称</param>
        /// <param name="param"></param>
        /// <returns>参数</returns>
        public static IEnumerable<T> ExecuteQueryProc<T>(string strProcName, object param = null)
        {
            using (var con = DataSource.GetConnection())
            {
                var tList = con.Query<T>(strProcName, param, commandType: CommandType.StoredProcedure);
                return tList;
            }
        }
    }

    /// <summary>
    /// 数据源
    /// </summary>
    public class DataSource
    {
        private static readonly string ConnString = ConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
        /// <summary>
        /// 连接池
        /// </summary>
        /// <returns></returns>
        public static IDbConnection GetConnection()
        {
            if (string.IsNullOrEmpty(ConnString))
                throw new NoNullAllowedException(nameof(ConnString));
            return new SqlConnection(ConnString);
        }
    }
}
