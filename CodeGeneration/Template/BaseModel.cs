using System;

namespace Template
{
    public class BaseModel
    {
        protected static DateTime ToDateTime(string str)
        {
            DateTime data;
            try
            {
                data = Convert.ToDateTime(str);
            }
            catch (Exception)
            {
                data = Convert.ToDateTime("1900-01-01");
            }
            return data;
        }

        protected static int ToInt(string str)
        {
            str = str.Trim();
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            try
            {
                return Convert.ToInt32(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        protected static long ToLong(string str)
        {
            str = str.Trim();
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            try
            {
                return Convert.ToInt64(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        protected static decimal ToDecimal(string str)
        {
            str = str.Trim();
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            try
            {
                return Convert.ToDecimal(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        protected static double ToDouble(string str)
        {
            str = str.Trim();
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            try
            {
                return Convert.ToDouble(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
