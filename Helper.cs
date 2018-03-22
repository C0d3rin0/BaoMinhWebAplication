using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Text;

namespace BaoMinhWebApplication
{
    public static class Helper
    {
        public static string convertToCorrectDateTime(string s)
        {
            DateTime dt = DateTime.ParseExact(s, "yyyyMMdd", CultureInfo.InvariantCulture);
            return dt.ToString("dd/MM/yyyy");
        }

        public static bool KiemTraHopLeMatKhau(string s)
        {
            if (s.Length > 8 && s.Any(c => char.IsUpper(c)))
                return true;

            return false;
        }


    }
}