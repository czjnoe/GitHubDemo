using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClrProfiler
{
    public sealed class CustomEqComparer : EqualityComparer<string>
    {
        public override bool Equals(string x, string y)
        {
            if (x.Compare(y))
                return true;
            return false;
        }

        public override int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }

    public static class StringExtension
    {
        public static bool Compare(this string @this, string comStr)
        {
            var res = string.Compare(@this, comStr, StringComparison.CurrentCultureIgnoreCase);
            if (res == 0)
                return true;
            return false;
        }
    }
}
