using Dapper;
using DapperDemo.Dto;
using DapperDemo.Help;
using DapperDemo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DapperDemo
{
    /// <summary>
    /// Dapper 轻量级ORM
    /// github:https://github.com/StackExchange/Dapper
    /// 链接:https://www.cnblogs.com/yankliu-vip/p/4182892.html
    /// 入参类型：
    ///     1.匿名类,如：new {ID="1",NAME="1122"} 
    ///     2.实体类,如：new Student {ID="1",NAME="1122"} 
    ///     3.字典,如：Dictionary<string,object> dic=new                                                          Dictionary<string,object>();
    ///                 dic["ID"]="1";
    ///                 dic["NAME"]="1122";
    ///      
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            //sql server
            {
                Random rand = new Random();
                using (IDbConnection db = DapperFactory.GetConnection(Enums.MyDbType.SqlServer, "Data Source=localhost;Initial Catalog=test;Integrated Security=True"))
                {
                    int effectRows;
                    string id = rand.Next(1, 2000000000).ToString();
                    Student stu = new Student { ID = id, NAME = "春夏之交", AGE = 25, TIME = DateTime.Now };
                    //单个插入
                    {
                        effectRows = db.Execute("insert into Student(ID,NAME,TIME) values(@ID,@NAME,@TIME)", stu);
                    }
                    //多个插入
                    {
                        var stuList = Enumerable.Range(0, 5).Select(i => new Student()
                        {
                            ID = rand.Next(1, 2147483647).ToString(),
                            NAME = "安徽",
                            AGE = i,
                            TIME = DateTime.Now
                        });
                        var result = db.Execute("insert into Student(ID,NAME,TIME,AGE) values(@ID,@NAME,@TIME,@AGE)", stuList);
                    }

                    //字典参数插入
                    {
                        dic["ID"] = id + "1";
                        dic["NAME"] = "陈兆杰" + DateTime.Now.ToString();
                        dic["TIME"] = DateTime.Now;
                        dic["AGE"] = 25;
                        effectRows = db.Execute("insert into Student(ID,NAME,TIME,AGE) values(@ID,@NAME,@TIME,@AGE)", dic);
                    }

                    //更新
                    {
                        var stu1 = db.QuerySingleOrDefault<Student>("select * from Student where ID=@ID", new Student { ID = id });
                        stu1.NAME = "陈兆杰";

                        effectRows = db.Execute("UPDATE Student SET NAME=@NAME WHERE ID =@ID", stu1);
                    }

                    //删除
                    {
                        dic["ID"] = id;
                        effectRows = db.Execute("DELETE FROM Student WHERE ID = @ID", dic);
                    }

                    //事务
                    {
                        db.Open();
                        var tran = db.BeginTransaction();
                        try
                        {
                            Dictionary<string, object> dicParam = new Dictionary<string, object>();
                            dicParam["ID"] = Guid.NewGuid().ToString();
                            dicParam["NAME"] = "陈兆杰";
                            dicParam["TIME"] = DateTime.Now;
                            effectRows = db.Execute("insert into Student(ID,NAME,TIME) values(@ID,@NAME,@TIME)", dicParam, tran);

                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                        }
                    }

                    //多结果查询(Read表顺序，要与sql语句表的顺序一致，不然会有问题)
                    {
                        string sql = @"
                            select * from Student where ID = @ID;
                            select * from Course;";
                        using (var multi = db.QueryMultiple(sql, new { id = "1" }))
                        {
                            var orders = multi.Read<Student>().ToList();
                            var customer = multi.Read<Course>().FirstOrDefault();

                        }
                    }

                    //单个查询
                    {
                        //var stu4 = db.QuerySingle<Student>("select * from Student where ID=@ID", new { ID = "1" });//数据超过一条会报错，没有数据会报错
                        //var stu5 = db.QuerySingleOrDefault<Student>("select * from Student where ID=@ID", new { ID = "1" });//数据超过一条会报错,没有数据是默认为null
                        //var stu6 = db.QueryFirstOrDefault<Student>("select * from Student where ID=@ID", new { ID = "1" });//没有数据时默认为null
                        //var stu7 = db.QueryFirst<Student>("select * from Student where ID=@ID", new { ID = "1" });//没有数据会报错

                    }
                    var list = db.Query<Student>("SELECT * FROM Student").ToList();

                    //多表查询
                    {


                        string sql = @"select s.*,c.ID,c.CourseName from Student s,Course c where s.ID =c.ID and s.ID=@ID";

                        //方法1：
                        var list2 = db.Query<Student, Course, StudentDto>(sql, (student, course) =>
                       {
                           StudentDto stuDto = new StudentDto();
                           stuDto.NAME = student.NAME;
                           stuDto.ID = student.ID;
                           course.ID = student.ID;
                           stuDto.Course = course;
                           return stuDto;

                       }, new { ID = "1786863176" }, splitOn: "ID,CourseName").ToList();

                        //方法2：
                        var dynamic = db.Query(sql, new { ID = "1786863176" }).ToList();

                    }

                    //调用存储过程
                    {
                        var param = new DynamicParameters();
                        param.Add("@StuId", "859713145");
                        param.Add("@Name", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);//输出值需要赋值size
                        param.Add("@result", dbType: DbType.String, direction: ParameterDirection.ReturnValue, size: 50);//输出值需要赋值size

                        db.Execute("TestProc", param, commandType: CommandType.StoredProcedure);
                        string Name = param.Get<string>("Name");
                        int? ReturnValue = param.Get<int>("@result");
                    }


                }
            }
        }
    }
}
