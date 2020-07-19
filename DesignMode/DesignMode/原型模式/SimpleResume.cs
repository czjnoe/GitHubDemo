/*
*┌──────────────────────────────────────────┐
*│  描述：SimpleResume                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/7/19 10:58:02                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public class SimpleResume : ICloneable
    {
        private string _name;
        private string _email;

        private string _timePeriod;
        private string _company;

        public void SetPersonalInfo(string name, string email)
        {
            _name = name;
            _email = email;
        }

        public void SetWorkExperience(string company, string timePeriod)
        {
            _company = company;
            _timePeriod = timePeriod;
        }

        public void Display()
        {
            Console.WriteLine($"{_name} {_email}");
            Console.WriteLine($"工作经历：{_timePeriod} {_company}");
        }

        public object Clone() => MemberwiseClone();
    }
}
