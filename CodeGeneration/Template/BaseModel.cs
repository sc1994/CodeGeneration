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
    }
}
