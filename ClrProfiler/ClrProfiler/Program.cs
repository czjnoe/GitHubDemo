using ClrProfiler.Help;
using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ClrProfiler
{
    class Program
    {
        static void Main(string[] args)
        {
            //int start = Environment.TickCount;
            //for (int i = 0; i < 1000; i++)
            //{
            //    string s = "";
            //    for (int j = 0; j < 100; j++)
            //    {
            //        s += "Outer index = ";
            //        s += i;
            //        s += " Inner index = ";
            //        s += j;
            //        s += " ";
            //    }
            //}
            //Console.WriteLine("Program ran for {0} seconds",
            //    0.001 * (Environment.TickCount - start));
            //string s = "ddd";
            //for (int j = 0; j < 100; j++)
            //{
            //    s += "Outer index = ";
            //    s += " Inner index = ";
            //    s += j.ToString();
            //    s += " ";
            //}

            //StringBuilder sb = new StringBuilder("ddd");
            //for (int j = 0; j < 100; j++)
            //{
            //    sb .Append( "Outer index = ");
            //    sb.Append(" Inner index = ");
            //    sb.Append(j.ToString());
            //    sb.Append(" ");
            //}

            //string s = "ggg";
            //string s1 = ("ggg");
            //s1 = ("gfg544");

            //var Students = Enumerable.Range(0, 20 * 10000).Select(m => new Student()
            //{
            //    ID = m,
            //    NAME = string.Intern(File.ReadLines(Environment.CurrentDirectory + "//TextFile1.txt")
            //                    .ElementAt(m % 4))
            //}).ToList();


            //List<string> nameList = new List<string>() { "WAP", "TAOBAO", "ETAO", "TMALL" };
            //using (IDbConnection db = DapperFactory.GetConnection(Enums.MyDbType.Oracle, @"User ID=czj;Password=123456;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = orcl)))"))
            //{
            //    var list = db.Query<Student>("SELECT * FROM Student").ToList();

            //    //var wList=list.Where(w => w.ID < 1000);
            //    //var sList = list.Select(s => new Student { ID = s.ID, NAME = s.NAME }).ToList();

            //    //var stuList = Enumerable.Range(0, 20 * 10000).Select(i => new Student()
            //    //{
            //    //    ID = i,
            //    //    NAME = (nameList.ElementAt(i % 4))
            //    //}).ToList();
            //    //var result = db.Execute("insert into Student(ID,NAME) values(:ID,:NAME)", stuList);
            //}

            //string s1 = "22222222";
            //string str = string.Format("{0}", s1);

            //for (int i = 0; i < 100; i++)
            //{
            //    //if (nameList.Contains("tmall", new CustomEqComparer()))
            //    //{

            //    //}
            //    foreach (var name in nameList)
            //    {
            //        if (name.Compare("tmall"))
            //        {

            //        }
            //    }
            //}

            string str = "dsdsd"+"dsdsdsffg"+"jkjjhjh";
            //string str = string.Format("{0}{1}{2}", "dsdsd", "dsdsdsffg", "jkjjhjh");

            GC.Collect();
            //Console.WriteLine("执行成功");
            Console.ReadLine();
        }
    }
}
