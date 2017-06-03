using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
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

        public static IEnumerable<T> ExecuteQueryProc<T>(string strProcName, object param = null)
        {
            using (IDbConnection con = DataSource.GetConnection())
            {
                IEnumerable<T> tList = con.Query<T>(strProcName, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return tList;
            }
        }

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


    public class DataSource
    {
        public static string ConnString = ConfigurationManager.ConnectionStrings["DJES"].ConnectionString;
        public static IDbConnection GetConnection()
        {
            if (string.IsNullOrEmpty(ConnString))
                throw new NoNullAllowedException(nameof(ConnString));
            return new SqlConnection(ConnString);
        }
    }
}
