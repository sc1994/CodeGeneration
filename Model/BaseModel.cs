using System;

namespace Model
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

        protected static long Tolong(string str)
        {
            long data;
            try
            {
                data = Convert.ToInt64(str);
            }
            catch (Exception)
            {
                data = 0;
            }
            return data;
        }

        protected static int ToInt(string str)
        {
            int data;
            try
            {
                data = Convert.ToInt32(str);
            }
            catch (Exception)
            {
                data = 0;
            }
            return data;
        }

        protected static decimal ToDecimal(string str)
        {
            decimal data;
            try
            {
                data = Convert.ToDecimal(str);
            }
            catch (Exception)
            {
                data = 0;
            }
            return data;
        }

        protected static double ToDouble(string str)
        {
            double data;
            try
            {
                data = Convert.ToDouble(str);
            }
            catch (Exception)
            {
                data = 0;
            }
            return data;
        }

        protected static bool ToBool(string str)
        {
            return str == "1";
        }

    }
}
