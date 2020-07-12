/*
*┌──────────────────────────────────────────┐
*│  描述：ApiModule                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/6/21 11:51:49                        
*└──────────────────────────────────────────┘
*/
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyWebApiDemo.Modules
{
    /// <summary>
    /// github；https://github.com/NancyFx/Nancy
    /// Nancy里面的所有控制器都需要放在Modules文件夹下，且需继承NancyModule类,类比MVC的控制器都需要继承Controller类，同时所有的类都必须是public类，
    /// </summary>
    public class ApiModule : NancyModule
    {

        /// <summary>
        /// 加上base("/nancy")，请求地址为:http://localhost:port/nancy
        /// 去掉base("/nancy")，请求地址为:http://localhost:port
        /// </summary>
        public ApiModule():base("/nancy")
        {
            //get方式 访问当前接口的默认页面
            //注意：如果加上base("/nancy"),那么Views文件夹下，需对应的文件夹，才可访问html
            Get["/"] = p =>
            {
                return View["index"];
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