/*
*┌──────────────────────────────────────────┐
*│  描述：ComplexResume                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/7/19 11:02:22                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public class WorkExperience : ICloneable
    {
        public string TimePeriod { get; set; }
        public string Company { get; set; }

        public object Clone() => MemberwiseClone();
    }

    public class ComplexResume : ICloneable
    {
        private readonly WorkExperience _workExperience;
        private string _name;
        private string _email;

        public ComplexResume()
        {
            _workExperience = new WorkExperience();
        }

        private ComplexResume(WorkExperience workExperience)
        {
            _workExperience = (WorkExperience)workExperience.Clone();
        }

        public void SetPersonalInfo(string name, string email)
        {
            _name = name;
            _email = email;
        }

        public void SetWorkExperience(string comapny, string timePeriod)
        {
            _workExperience.Company = comapny;
            _workExperience.TimePeriod = timePeriod;
        }

        public void Show()
        {
            Console.WriteLine($"{_name} {_email}");
            Console.WriteLine($"Work Experience: {_workExperience.Company} {_workExperience.TimePeriod}");
        }

        public object Clone() => new ComplexResume(_workExperience)
        {
            _name = _name,
            _email = _email
        };
    }
}
