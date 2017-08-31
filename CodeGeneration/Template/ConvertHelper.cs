using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Common
{
    public static class ConverHelper
    {
        #region 基础类型转换
        public static int ToInt(this object o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public static bool ToBool(this object o)
        {
            try
            {
                return Convert.ToBoolean(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static double ToDouble(this object o)
        {
            try
            {
                return Convert.ToDouble(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public static DateTime ToDate(this object o)
        {
            try
            {
                return Convert.ToDateTime(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Convert.ToDateTime("1900-1-1");
            }
        }

        public static decimal ToDecimal(this object o)
        {
            try
            {
                return Convert.ToDecimal(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        #endregion

        #region JSON 类型转换
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T JsonToObject<T>(this string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Activator.CreateInstance<T>();
            }
        }
        #endregion

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
                    return sww.ToString();
                }
            }
        }

        #endregion

        #region 字符串加密
        /// <summary>
        /// 基于Sha1的自定义加密字符串方法：输入一个字符串，返回一个由40个字符组成的十六进制的哈希散列（字符串）。
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的十六进制的哈希散列（字符串）</returns>
        public static string ToSha1(this string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);
            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>  
        /// MD5 加密字符串  
        /// </summary>  
        /// <param name="str">源字符串</param>  
        /// <returns>加密后字符串</returns>  
        public static string ToMd5(this string str)
        {
            var md5 = MD5.Create();
            var bs = Encoding.UTF8.GetBytes(str);
            var hs = md5.ComputeHash(bs);
            var sb = new StringBuilder();
            foreach (var b in hs)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion

        #region Table 和 List 互操作
        public static DataTable ToDataTable<T>(this List<T> entitys)
        {
            if (entitys == null || entitys.Count < 1)
            {
                return new DataTable();
            }
            var entityType = entitys[0].GetType();
            var entityProperties = entityType.GetProperties();

            var dt = new DataTable("dt");
            foreach (var t in entityProperties)
            {
                dt.Columns.Add(t.Name);
            }

            foreach (object entity in entitys)
            {
                var entityValues = new object[entityProperties.Length];
                for (var i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }

        public static IList<T> ToList<T>(this DataTable table) where T : new()
        {
            var properties = typeof(T).GetProperties().ToList();
            return (from object row in table.Rows select CreateItemFromRow<T>((DataRow)row, properties)).ToList();
        }
        #endregion

        /// <summary>
        /// 两个类之间相同的字段浅拷贝
        /// 并不太好用(只能适用于简单类) 如类中包含属性也是类可能使用此扩展无效
        /// </summary>
        /// <typeparam name="TToObject"></typeparam>
        /// <typeparam name="TFromObject"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static TToObject Map<TToObject, TFromObject>(this TFromObject from)
        {
            var fs = typeof(TFromObject).GetProperties();
            var ts = typeof(TToObject).GetProperties();
            var to = Activator.CreateInstance<TToObject>();
            foreach (var f in fs)
            {
                foreach (var t in ts)
                {
                    if (f.Name == t.Name)
                    {
                        var propertyInfo = to.GetType().GetProperty(t.Name);
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(to, f.GetValue(from, null), null);
                            break;
                        }
                    }
                }
            }
            return to;
        }

        /// <summary>
        /// 字符串为空验证,无需去除前后空格
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s)
        {
            if (s == null) return true;
            if (s.Trim() == string.Empty) return true;
            return false;
        }

        #region 其他
        /// <summary>  
        /// 获取当前时间戳  
        /// </summary>  
        /// <param name="bflag">为真时获取10位时间戳,为假时获取13位时间戳.</param>  
        /// <returns></returns>  
        public static string GetTimeStamp(bool bflag = true)
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var ret = bflag ? Convert.ToInt64(ts.TotalSeconds).ToString() : Convert.ToInt64(ts.TotalMilliseconds).ToString();
            return ret;
        }

        /// <summary>
        /// 一定长度的随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetNonce(int length)
        {
            const string n = "qwertyuioplkjhgfdsazxcvbnm1234567890QWERTYUIOPLKJHGFDSAZXCVBNM";
            var s = "";
            var r = new Random();
            for (var i = 0; i < length; i++)
            {
                s += n[r.Next(0, n.Length)];
            }
            return s;
        }
        #endregion

        #region 私方法
        private static T CreateItemFromRow<T>(DataRow row, IEnumerable<PropertyInfo> properties) where T : new()
        {
            var item = new T();
            foreach (var property in properties)
            {
                try
                {
                    property.SetValue(item, row[property.Name] ?? "", null);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return item;
        }
        #endregion
    }
}