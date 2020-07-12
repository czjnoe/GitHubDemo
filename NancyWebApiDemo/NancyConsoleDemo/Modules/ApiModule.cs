/*
*┌──────────────────────────────────────────┐
*│  描述：ApiModule                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/6/21 12:11:12                        
*└──────────────────────────────────────────┘
*/
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyConsoleDemo.Modules
{
    public class ApiModule: NancyModule
    {
        /// <summary>
        /// 加上base("/nancy")，请求地址为:http://localhost:port/nancy
        /// 去掉base("/nancy")，请求地址为:http://localhost:port
        /// </summary>
        public ApiModule()
        {
            //get方式 访问当前接口的默认页面
            //注意：控制台在Debug运行时是不在根目录下读取文件的，你需要复制一份Views到bin/Debug目录下才可以
            Get["/"] = p =>
            {
                return View["index"];//返回页面
            };

            Get["string"] = p =>
            {
                return "WebApi Program Started!";
            };

            //post方式才能访问当前接口方法
            Get["queryUser"] = p =>
            {
                //获取参数值
                string userId = Request.Query["userID"];
                //初始化一个返回对象
                var user = new { id = userId, name = "Tom", phone = "13000000000" };
                return Newtonsoft.Json.JsonConvert.SerializeObject(user); ;
            };


            Post["DeleUser/{id}"] = parameters =>
            {
                return $"id:{parameters.id},删除成功";
            };
        }
    }
}
