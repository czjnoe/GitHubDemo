using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.IE.Demo.Model
{
    public class Student
    {
        public string ID { get; set; }
        public int AGE { get; set; }
        public string NAME { get; set; }

        public List<Course> Course
        {
            get
            {
                return _course;
            }

            set
            {
                _course = value;
            }
        }

        private List<Course> _course = new List<Course>();
    }
}
