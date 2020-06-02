using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RestSharpDemo
{
    /// <summary>
    /// RestSharp是一个轻量的，不依赖任何第三方的组件或者类库的Http的组件。RestSharp具体以下特性；
    /// 1、通过NuGet方便引入到任何项目(Install-Package restsharp)
    /// 2、可以自动反序列化XML和JSON
    /// 3、支持自定义的序列化与反序列化
    /// 4、自动检测返回的内容类型
    /// 5、支持HTTP的GET, POST, PUT, HEAD, OPTIONS, DELETE等操作
    /// 6、可以上传多文件
    /// 7、支持oAuth 1, oAuth 2, Basic, NTLM and Parameter-based Authenticators等授权验证等
    /// 8、支持异步操作
    /// 9、极易上手并应用到任何项目中
    /// 
    /// 官方文档：https://restsharp.dev/get-help/
    /// github:https://github.com/restsharp/RestSharp
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Get
            {
                var client = new RestClient("https://localhost:44370/api/First");
                client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator("admin", "admin");

                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.Timeout = 10000;
                request.AddHeader("Cache-Control", "no-cache");
                request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
                request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

                // add parameters for all properties on an object
                //request.AddJsonObject(@object);

                //直接传输一个实体
                //request.AddJsonBody("实体");

                //request.AddObject(object, "PersonId", "Name", ...);
                request.AddHeader("header", "value");

                //add files to upload (works with compatible verbs)
                //request.AddFile("file", path);

                var response = client.Execute(request);
                var content = response.Content;
            }
            //POST(单个参数与)
            {
                var client = new RestClient("https://localhost:44370/api/Unity");
                var request = new RestRequest(Method.POST);
                request.AddParameter("", "value");

                var response = client.Execute(request);
                var content = response.Content;
            }
            //POST(实体参数)
            {
                var client = new RestClient("https://localhost:44370/api/Unity/PostTest");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                Student stu = new Student
                {
                    AGE = 26,
                    ID = 1,
                    NAME = "czk",
                    PWD = 123456
                };
                request.AddJsonBody(stu);

                //var response = client.Execute<Student>(request);//报错
                var response = client.Execute<dynamic>(request);
                var retStu = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(response.Data);
            }

            //上传文件
            {
                var client = new RestClient("https://localhost:44370/api/File/UploadFiles");
                var request = new RestRequest(Method.POST);
                var imagePath = AppDomain.CurrentDomain.BaseDirectory + @"File\image.jpg";
                request.AddFile("image", imagePath);

                var response = client.Execute(request);
                var content = response.Content;
            }
            //下载文件
            {
                var client = new RestClient("https://localhost:44370/api/File/DownloadFile");
                var request = new RestRequest(Method.GET);

                string tempFile = Path.GetTempFileName();
                var writer = File.OpenWrite(tempFile);
                request.ResponseWriter = responseStream =>
                {
                    using (responseStream)
                    {
                        responseStream.CopyTo(writer);
                    }
                };
                byte[] bytes = client.DownloadData(request);
            }

        }
    }
}
