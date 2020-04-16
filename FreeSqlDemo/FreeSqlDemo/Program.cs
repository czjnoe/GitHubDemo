using FreeSql.DataAnnotations;
using FreeSqlDemo.Model;
using FreeSqlDemo.Util;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FreeSqlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //sqlite
            {
                var db = FreeSqlHelp.GetFreeSqlClient(FreeSql.DataType.Sqlite, "default");

                var topicRepository = db.GetGuidRepository<student>();
                //insert
                {
                    Random random = new Random();
                    int i=random.Next(0, 100000000);
                    student stu = new student
                    {
                        AGE = 26,
                        ID = i,
                        NAME = "长长久久" + i.ToString()
                    };
                    var returnValue = topicRepository.Insert(stu);
                    //var rowCount =db.Insert(stu).ExecuteAffrows();
                }
                //update
                {
                    student item = db.Select<student>().First();
                    item.NAME = "123456789000";

                    //UPDATE Sys_user SET MOBILEPHONE = '123456789000' WHERE (GUID = item.guID)
                    //var rowCount = db.Update<student>()
                    //    .SetSource(item)
                    //    .UpdateColumns(a => new { a.NAME })
                    //    .ExecuteAffrows();//执行更新操作，返回受影响行数
                    var rowCount = topicRepository.Update(item);//执行更新操作，返回受影响行数（推荐此方法）
                }
                //query
                {
                    var list = db.Queryable<student>().ToList();
                    var dt = db.Select<student>().ToList();
                    var userDt = db.Ado.ExecuteNonQuery(CommandType.Text, @"select * from  student", null);
                   var userList= topicRepository.Select.ToList();
                }
                //delete
                {
                    var firstUser=topicRepository.Select.First();
                    var rowCount = topicRepository.Delete(firstUser);
                    //var rowCount = db.Delete<student>(firstUser).ExecuteAffrows();
                }
               

            }
            //oracle
            {
                var db = FreeSqlHelp.GetFreeSqlClient(FreeSql.DataType.Oracle, "oracle");
                string guid = Guid.NewGuid().ToString();
                OracleParameter para1 = new Oracle.ManagedDataAccess.Client.OracleParameter("id", OracleDbType.Varchar2, guid, ParameterDirection.Input);

                List<OracleParameter> paras = new List<OracleParameter>();
                paras.Add(para1);
                var returnV = db.Ado.ExecuteScalar(System.Data.CommandType.StoredProcedure, "proTest", paras.ToArray());//执行存储过程
                var stus = db.Select<Student>().ToList();

                var list = db.Queryable<Student>().Where(w => w.ID.Contains("陈")).ToList();
                var list1 = db.Queryable<Student>().ToList();
                int deleteSql = db.Delete<Student>().Where(w => w.ID == "1").ExecuteAffrows();



                list1 = db.Queryable<Student>().ToList();
                //插入 insert
                {
                    List<Sys_user> sysList = new List<Sys_user>();
                    Sys_user sys_user = new Sys_user
                    {
                        CREATETIME = DateTime.Now,
                        EMAIL = "15298506403@163.com",
                        GUID = Guid.NewGuid().ToString(),
                        MOBILEPHONE = "15298506403",
                        PASSWORD = "123"
                    };
                    sysList.Add(sys_user);
                    string insertSql = db.Insert(sysList).ToSql();//返回sql语句,不执行插入
                    //int rowsCount=db.Insert(sysList).ExecuteAffrows();//执行插入，返回受影响行数
                    var sys_user1 = db.Insert(sysList).ExecuteInserted();//执行插入，返回插入后的记录
                }
                //更新 update
                {
                    //方法一  需添加FreeSql.Repository引用
                    //缺点 需要添加特性[Column(IsIdentity = true, IsPrimary = true)] 指定主键
                    {
                        //var repo = db.GetRepository<Sys_user>();
                        //var item = repo.Select.First();
                        //item.MOBILEPHONE = "123456789";
                        //repo.Update(item);//直接更新,可以是实体，也可是集合
                    }
                    //方法二 
                    {
                        //Sys_user item = db.Select<Sys_user>().First();
                        //item.MOBILEPHONE = "123456789000";

                        ////UPDATE Sys_user SET MOBILEPHONE = '123456789000' WHERE (GUID = item.guID)
                        //var rowCount = db.Update<Sys_user>()
                        //    .SetSource(item)
                        //    .UpdateColumns(a => new { a.MOBILEPHONE })
                        //    .ExecuteAffrows();//执行更新操作，返回受影响行数

                    }
                    //方法三 推荐
                    {
                        var Sys_userRepository = db.GetGuidRepository<Sys_user>();
                        var firstUser=Sys_userRepository.Select.First();
                        firstUser.MOBILEPHONE = "123456789000";
                        var rowCount = Sys_userRepository.Update(firstUser);
                    }
                }
                //删除 delete
                {
                    db.Select<Student>().Where(a => a.ID == "2").ToDelete().ExecuteAffrows(); //执行delete操作
                }
            }
            //mysql
            {

            }
        }

        public class test
        {
            public string name { get; set; }
            public int id { get; set; }
        }
    }
}
