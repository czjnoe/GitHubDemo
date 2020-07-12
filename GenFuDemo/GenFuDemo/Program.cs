using GenFu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFuDemo
{
    /// <summary>
    /// GenFu       生成模拟数据的类库   通过反射来填充属性
    /// GitHub:https://github.com/MisterJames/GenFu
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //单个实体
            var person = A.New<Person>();
            //生成25个person实体集合
            var personList = A.ListOf<Person>();
            //生成100个person实体集合
            personList = A.ListOf<Person>(100);

            //限制年龄字段在19到25之间
            A.Configure<Person>()
                .Fill(p => p.Age)
                .WithinRange(19, 25);
            var people = A.ListOf<Person>();


            //自定义属性值
            var blogTitle = "GenFu";
            A.Configure<Person>()
                .Fill(b => b.Title, () => { return blogTitle; });
            var post = A.New<Person>();

            //实体嵌套实体属性或字段，嵌套集合
            A.Configure<Department>()
              .Fill(b => b.Office, () => { return A.New<Office>(); })
              .Fill(b => b.Users, () => { return A.ListOf<Person>(); });
            var Department = A.New<Department>();

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }
        public int NumberOfKids { get; set; }

        private string _middleName;
        public void SetMiddleName(string name) { _middleName = name; }
    }

    /// <summary>
    /// 部门
    /// </summary>
    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Office Office { get; set; }
        public List<Person> Users
        {
            get
            {
                return _users;
            }

            set
            {
                _users = value;
            }
        }

        private List<Person> _users = new List<Person>();

    }

    /// <summary>
    /// 大部门
    /// </summary>
    public class Office
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
