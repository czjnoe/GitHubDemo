using EasyHttp.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHttpDemo
{
    /// <summary>
    /// EasyHttp http请求类库
    /// github:https://github.com/EasyHttp/EasyHttp
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //GET(无参)
            {
                var http = new HttpClient();
                http.Request.Accept = HttpContentTypes.ApplicationJson;
                //http.Request.ContentType = "application/json";
                http.Request.SetBasicAuthentication("admin", "admin");
                var response = http.Get("https://localhost:44370/api/First");
                string responseValue = response.RawText;
                //var dyncValue=response.DynamicBody;

            }
            //GET(单个传参)
            {
                var http = new HttpClient();
                http.Request.Accept = HttpContentTypes.ApplicationJson;
                //http.Request.ContentType = "application/json";
                http.Request.SetBasicAuthentication("admin", "admin");

                var response = http.Get("https://localhost:44370/api/First?id=5");
                string responseValue = response.RawText;
                //T obj=response.StaticBody<T>();
                //var dyncValue=response.DynamicBody;

            }
            //GET(实体传参)
            {
                var http = new HttpClient();
                http.Request.Accept = HttpContentTypes.ApplicationJson;
                //http.Request.ContentType = "application/json";
                http.Request.SetBasicAuthentication("admin", "admin");

                Student stu = new Student
                {
                    AGE = 25,
                    ID = 1,
                    NAME = "czj",
                    PWD = 123456
                };

                var response = http.Get("https://localhost:44370/api/First/GetById", stu);
                string responseValue = response.RawText;
                //T obj=response.StaticBody<T>();
                //var dyncValue=response.DynamicBody;

            }
            //POST(单个参数)
            {
                var http = new HttpClient();
                http.Request.SetBasicAuthentication("admin", "admin");
                //http.Request.Uri = "https://localhost:44370/api/Unity";
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic[""] = "value";
                var response = http.Post("https://localhost:44370/api/Unity", dic, EasyHttp.Http.HttpContentTypes.ApplicationXWwwFormUrlEncoded);
                string responseValue = response.RawText;
            }
            //POST(参数为实体/dynamic)
            {
                var http = new HttpClient();
                http.Request.SetBasicAuthentication("admin", "admin");
                Student stu = new Student
                {
                    AGE = 25,
                    ID = 1,
                    NAME = "czj",
                    PWD = 123456
                };
                var response = http.Post("https://localhost:44370/api/Unity/PostTest", stu, EasyHttp.Http.HttpContentTypes.ApplicationJson);
                var responseValue = response.DynamicBody;
                Student retStu = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(responseValue);
            }
        }

        
    }
}
