using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeSqlDemo.Model
{
    public class Sys_user
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public string GUID { get; set; }
        public string PASSWORD { get; set; }
        public string MOBILEPHONE { get; set; }
        public string EMAIL { get; set; }
        public DateTime CREATETIME { get; set; }
    }
}
