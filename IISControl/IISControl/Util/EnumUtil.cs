using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IISControl.Model;
using Microsoft.Web.Administration;

using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;

using System.Windows.Forms;
using System.Xml.Serialization;

namespace IISControl.Util
{
    public class EnumUtil
    {
        /// <summary>
        /// 获取字典
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns></returns>
        public static Dictionary<string, string> GetEnumDic<T>()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var item in Enum.GetNames(typeof(T)))
            {
                string key = ((int)Enum.Parse(typeof(T), item.ToString())).ToString();
                dic.Add(key, item);
            }
            return dic;
        }
    }
}
