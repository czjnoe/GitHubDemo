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
using DapperExtensions;
using Oracle.ManagedDataAccess.Client;

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
    /// 
    /// DapperExtensions：
    /// 连接：https://codedefault.com/p/dapper-extensions-library-support-identity-fluent-mapping
    /// https://www.cnblogs.com/xwc1996/p/9580771.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, object> dic = new Dictionary<string, object>();
            //sql server
            {
                //Random rand = new Random();
                //using (IDbConnection db = DapperFactory.GetConnection(Enums.MyDbType.SqlServer, "Data Source=localhost;Initial Catalog=test;Integrated Security=True"))
                //{
                //    int effectRows;
                //    string id = rand.Next(1, 2000000000).ToString();
                //    Student stu = new Student { ID = id, NAME = "春夏之交", AGE = 25, TIME = DateTime.Now };
                //    //单个插入
                //    {
                //        effectRows = db.Execute("insert into Student(ID,NAME,TIME) values(@ID,@NAME,@TIME)", stu);
                //    }
                //    //多个插入
                //    {
                //        var stuList = Enumerable.Range(0, 5).Select(i => new Student()
                //        {
                //            ID = rand.Next(1, 2147483647).ToString(),
                //            NAME = "安徽",
                //            AGE = i,
                //            TIME = DateTime.Now
                //        });
                //        var result = db.Execute("insert into Student(ID,NAME,TIME,AGE) values(@ID,@NAME,@TIME,@AGE)", stuList);
                //    }

                //    //字典参数插入
                //    {
                //        dic["ID"] = id + "1";
                //        dic["NAME"] = "陈兆杰" + DateTime.Now.ToString();
                //        dic["TIME"] = DateTime.Now;
                //        dic["AGE"] = 25;
                //        effectRows = db.Execute("insert into Student(ID,NAME,TIME,AGE) values(@ID,@NAME,@TIME,@AGE)", dic);
                //    }

                //    //更新
                //    {
                //        var stu1 = db.QuerySingleOrDefault<Student>("select * from Student where ID=@ID", new Student { ID = id });
                //        stu1.NAME = "陈兆杰";

                //        effectRows = db.Execute("UPDATE Student SET NAME=@NAME WHERE ID =@ID", stu1);
                //    }

                //    //删除
                //    {
                //        dic["ID"] = id;
                //        effectRows = db.Execute("DELETE FROM Student WHERE ID = @ID", dic);
                //    }

                //    //事务
                //    {
                //        db.Open();
                //        var tran = db.BeginTransaction();
                //        try
                //        {
                //            Dictionary<string, object> dicParam = new Dictionary<string, object>();
                //            dicParam["ID"] = Guid.NewGuid().ToString();
                //            dicParam["NAME"] = "陈兆杰";
                //            dicParam["TIME"] = DateTime.Now;
                //            effectRows = db.Execute("insert into Student(ID,NAME,TIME) values(@ID,@NAME,@TIME)", dicParam, tran);

                //            tran.Commit();
                //        }
                //        catch (Exception ex)
                //        {
                //            tran.Rollback();
                //        }
                //    }

                //    //多结果查询(Read表顺序，要与sql语句表的顺序一致，不然会有问题)
                //    {
                //        string sql = @"
                //            select * from Student where ID = @ID;
                //            select * from Course;";
                //        using (var multi = db.QueryMultiple(sql, new { id = "1" }))
                //        {
                //            var orders = multi.Read<Student>().ToList();
                //            var customer = multi.Read<Course>().FirstOrDefault();

                //        }
                //    }

                //    //单个查询
                //    {
                //        //var stu4 = db.QuerySingle<Student>("select * from Student where ID=@ID", new { ID = "1" });//数据超过一条会报错，没有数据会报错
                //        //var stu5 = db.QuerySingleOrDefault<Student>("select * from Student where ID=@ID", new { ID = "1" });//数据超过一条会报错,没有数据是默认为null
                //        //var stu6 = db.QueryFirstOrDefault<Student>("select * from Student where ID=@ID", new { ID = "1" });//没有数据时默认为null
                //        //var stu7 = db.QueryFirst<Student>("select * from Student where ID=@ID", new { ID = "1" });//没有数据会报错

                //    }

                //    //多个查询
                //    {
                //        var list = db.Query<Student>("SELECT * FROM Student").ToList();
                //        list = db.Query<Student>("SELECT * FROM Student where ID in @IDS", new { IDS = new String[] { "1786863176", "1963140912" } }).ToList();
                //    }

                //    //多表查询
                //    {


                //        string sql = @"select s.*,c.ID,c.CourseName from Student s,Course c where s.ID =c.ID and s.ID=@ID";

                //        //方法1：
                //        var list2 = db.Query<Student, Course, StudentDto>(sql, (student, course) =>
                //       {
                //           StudentDto stuDto = new StudentDto();
                //           stuDto.NAME = student.NAME;
                //           stuDto.ID = student.ID;
                //           course.ID = student.ID;
                //           stuDto.Course = course;
                //           return stuDto;

                //       }, new { ID = "1786863176" }, splitOn: "ID,CourseName").ToList();

                //        //方法2：
                //        var dynamic = db.Query(sql, new { ID = "1786863176" }).ToList();

                //    }

                //    //调用存储过程
                //    {
                //        var param = new DynamicParameters();
                //        param.Add("@StuId", "859713145");
                //        param.Add("@Name", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);//输出值需要赋值size
                //        param.Add("@result", dbType: DbType.String, direction: ParameterDirection.ReturnValue, size: 50);//输出值需要赋值size

                //        db.Execute("TestProc", param, commandType: CommandType.StoredProcedure);
                //        string Name = param.Get<string>("Name");
                //        int? ReturnValue = param.Get<int>("@result");
                //    }


                //}
            }
            //oracle 存储过程
            {
                using (IDbConnection db = DapperFactory.GetConnection(Enums.MyDbType.Oracle, @"User ID=czj;Password=123456;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = orcl)))"))
                {
                    //ado原生调用存储过程
                    {
                        db.Open();
                        var command = (OracleCommand)db.CreateCommand();
                        command.BindByName = true;
                        string returnValue = "";
                        List<OracleParameter> paraList = new List<OracleParameter>
                    {
                        new OracleParameter("spassword", OracleDbType.Varchar2, "123456", ParameterDirection.Input),

                         new OracleParameter("id", OracleDbType.Varchar2, Guid.NewGuid().ToString(), ParameterDirection.Input),

                         new OracleParameter("smobilephone", OracleDbType.Varchar2, "15298506403", ParameterDirection.Input),

                         new OracleParameter("semail", OracleDbType.Varchar2, "15298506403@163.com", ParameterDirection.Input),

                         new OracleParameter("returnValue", OracleDbType.Varchar2, 1000,returnValue,ParameterDirection.Output)
                    };

                        command.CommandText = "proTest1";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(paraList.ToArray());
                        var effectRows = command.ExecuteScalar();
                    }

                    //dapper调用存储过程
                    {
                        //var param = new DynamicParameters();
                        //param.Add("returnValue", null, DbType.String, ParameterDirection.Output, 1000);
                        //param.Add("id", "1234569499", DbType.String,  ParameterDirection.Input);
                        //param.Add("smobilephone", "15298506403", DbType.String, ParameterDirection.Input);
                        //param.Add("semail", "15298506403@163.com", DbType.String, ParameterDirection.Input);
                        //param.Add("spassword", "123456", DbType.String, ParameterDirection.Input);

                        //param.AddDynamicParams(new OracleParameter(":spassword", OracleDbType.NVarchar2, "123456", ParameterDirection.Input));
                        //param.AddDynamicParams(new OracleParameter(":smobilephone", OracleDbType.NVarchar2, "15298506403", ParameterDirection.Input));
                        //param.AddDynamicParams(new OracleParameter(":semail", OracleDbType.NVarchar2, "15298506403@163.com", ParameterDirection.Input));
                        //param.AddDynamicParams(new OracleParameter(":returnValue", OracleDbType.NVarchar2, ParameterDirection.Output).Size = 1000);

                        //var obj=db.ExecuteScalar("PROTEST1", param, commandType: CommandType.StoredProcedure);
                    }
                }
            }

            //DapperExtensions.dll
            {
                Random rand = new Random();
                using (IDbConnection db = DapperFactory.GetConnection(Enums.MyDbType.SqlServer, "Data Source=localhost;Initial Catalog=test;Integrated Security=True"))
                {
                    string id = rand.Next(1, 2000000000).ToString();
                    Student stu = new Student { ID = id, NAME = "陈兆杰", AGE = 25, TIME = DateTime.Now };
                    //Insert
                    {
                        var effectRows = db.Insert(stu);//返回主键值
                    }

                    //Update
                    {
                        stu.TIME = DateTime.Now;
                        if (db.Update(stu))
                        {
                            //成功
                        }
                        else
                        {
                            //失败
                        }
                    }

                    //删除
                    {
                        //方法一
                        {
                            //if (db.Delete(stu))
                            //{
                            //    //成功
                            //}
                            //else
                            //{
                            //    //失败
                            //}
                        }

                        //方法二
                        {
                            var filedPred = Predicates.Field<Student>(o => o.ID, Operator.Eq, stu.ID);
                            if (db.Delete<Student>(filedPred))
                            {
                                //成功
                            }
                            else
                            {
                                //失败
                            }
                        }

                        //查询list
                        {
                            IList<ISort> sortlist = new List<ISort>();
                            sortlist.Add(new Sort { PropertyName = "ID", Ascending = false });//排序条件 降序

                            IList<IPredicate> preList = new List<IPredicate>();
                            preList.Add(Predicates.Field<Student>(o => o.ID, Operator.Eq, "1786863176"));//搜索条件，Operator有很多种的类型如eq是等于、like相当于是sql的like用法还有Lt、Le等

                            BetweenValues betweenValues = new BetweenValues();//搜索条件，between搜索两个值之间的数据
                            betweenValues.Value1 = "1786863176";
                            betweenValues.Value2 = "9786863176";
                            preList.Add(Predicates.Between<Student>(o => o.ID, betweenValues));

                            IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, preList.ToArray());//确认多个搜索条件的连接方式AND 或者 OR
                            var list = db.GetList<Student>(predGroup, sortlist).ToList();
                        }
                    }
                }
            }
        }
    }
}
