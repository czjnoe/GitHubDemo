using Nancy;
using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyConsoleDemo
{
    /// <summary>
    /// Nancy 寄宿在控制台程序
    /// 快速搭建后台接口
    /// 访问地址;http://localhost:50003/
    /// </summary>
    class Program
    {
        private string _url = "http://localhost";
        private int _port = 50003;
        private NancyHost _nancyHost = null;

        public Program()
        {
            var url = new Url($"{_url}:{_port}/");
            _nancyHost = new NancyHost(url);
        }

        private void Start()
        {
            _nancyHost.Start();
            Console.WriteLine("Nancy Start");
            Console.ReadKey();

            _nancyHost.Stop();
        }

        static void Main(string[] args)
        {
            var p=new Program();
            p.Start();
        }
    }
}
