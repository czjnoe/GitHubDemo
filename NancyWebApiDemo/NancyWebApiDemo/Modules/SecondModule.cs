/*
*┌──────────────────────────────────────────┐
*│  描述：SecondModule                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/6/21 12:01:26                        
*└──────────────────────────────────────────┘
*/
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyWebApiDemo.Modules
{
    public class SecondModule: NancyModule
    {
        /// <summary>
        /// 请求地址为:http://localhost:port/Second
        /// </summary>
        public SecondModule():base("/Second")
        {
            Get["/"] = p =>
            {
                return "SecondModule";
            };
        }
    }
}