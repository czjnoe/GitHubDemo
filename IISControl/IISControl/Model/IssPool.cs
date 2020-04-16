using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISControl.Model
{
    public class IssPool
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int ProcessCount { get; set; }
        public string Identity { get; set; }
        public string NetVersion { get; set; }

        public List<StationDetail> StationList
        {
            get
            {
                return _stationList;
            }

            set
            {
                _stationList = value;
            }
        }

        private List<StationDetail> _stationList = new List<StationDetail>();
    }
}
