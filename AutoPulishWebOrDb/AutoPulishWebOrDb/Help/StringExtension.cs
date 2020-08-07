using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoPulishWebOrDb.Help
{
    public static class StringExtension
    {
        public static string ToFormat(this string @this, params object[] args)
        {
            return string.Format(@this, args);
        }

        public static bool IsNotNullOrEmpty(this string @this)
        {
            return !string.IsNullOrEmpty(@this);
        }
        public static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }

        public static Boolean IsNotNullOrWhiteSpace(this string value)
        {
            return !String.IsNullOrWhiteSpace(value);
        }

        //public static Boolean IsNullOrWhiteSpace(this string value)
        //{
        //    return String.IsNullOrWhiteSpace(value);
        //}
        public static bool IsNumeric(this string @this)
        {
            return !Regex.IsMatch(@this, "[^0-9]");
        }

    }
}
