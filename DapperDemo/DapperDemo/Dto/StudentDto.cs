using DapperDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperDemo.Dto
{
    public class StudentDto
    {
        public string ID { get; set; }
        public string NAME { get; set; }

        public Course Course { get; set; }
    }
}
