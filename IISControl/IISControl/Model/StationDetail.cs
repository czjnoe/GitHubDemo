using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISControl.Model
{
   public class StationDetail
    {
        public string Status { get; set; }
        public string StationName { get; set; }
        public Site Site { get; set; }
}
}
