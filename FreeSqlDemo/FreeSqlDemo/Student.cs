using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeSqlDemo
{
    [Table(Name = "Student")]
    public class Student
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string AGE { get; set; }
    }
    [Table(Name = "student")]
    public class student
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int AGE { get; set; }
    }
}
