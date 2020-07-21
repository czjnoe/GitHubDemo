using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemcachedClientDemo
{
    /// <summary>
    /// 安装：https://www.runoob.com/memcached/window-install-memcached.html
    /// https://www.cnblogs.com/edisonchou/p/3855969.html
    /// github:https://github.com/memcached/memcached
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Memcached服务器列表
            // 如果有多台服务器，则以逗号分隔，例如："192.168.80.10:11211","192.168.80.11:11211"
            string[] serverList = { "192.168.0.103:11211" };
            // 初始化SocketIO池
            string poolName = "MyPool";
            SockIOPool sockIOPool = SockIOPool.GetInstance(poolName);
            // 添加服务器列表
            sockIOPool.SetServers(serverList);
            // 设置连接池初始数目
            sockIOPool.InitConnections = 3;
            // 设置连接池最小连接数目
            sockIOPool.MinConnections = 3;
            // 设置连接池最大连接数目
            sockIOPool.MaxConnections = 5;
            // 设置连接的套接字超时时间（单位：毫秒）
            sockIOPool.SocketConnectTimeout = 1000;
            // 设置套接字超时时间（单位：毫秒）
            sockIOPool.SocketTimeout = 3000;
            // 设置维护线程运行的睡眠时间：如果设置为0，那么维护线程将不会启动
            sockIOPool.MaintenanceSleep = 30;
            // 设置SockIO池的故障标志
            sockIOPool.Failover = true;
            // 是否用nagle算法启动
            sockIOPool.Nagle = false;
            // 正式初始化容器
            sockIOPool.Initialize();

            // 获取Memcached客户端实例
            MemcachedClient memClient = new MemcachedClient();
            // 指定客户端访问的SockIO池
            memClient.PoolName = poolName;
            // 是否启用压缩数据：如果启用了压缩，数据压缩长于门槛的数据将被储存在压缩的形式
            memClient.EnableCompression = false;

            Console.WriteLine("----------------------------测试开始----------------------------");

            // 01.简单的添加与读取操作
            memClient.Set("test1", "edisonchou");
            Console.WriteLine("test1:{0}", memClient.Get("test1"));
            // 02.先添加后修改再读取操作
            memClient.Set("test2", "jacky");
            Console.WriteLine("test2:{0}", memClient.Get("test2"));
            memClient.Set("test2", "edwin");
            Console.WriteLine("test2:{0}", memClient.Get("test2"));
            memClient.Replace("test2", "lousie");
            Console.WriteLine("test2:{0}", memClient.Get("test2"));
            // 03.判断Key值是否存在
            if (memClient.KeyExists("test2"))
            {
                Console.WriteLine("Key:test2 is existed");
            }
            // 04.删除指定Key值的数据
            memClient.Add("test3", "memcached");
            Console.WriteLine("test3:{0}", memClient.Get("test3"));
            memClient.Delete("test3");
            if (!memClient.KeyExists("test3"))
            {
                Console.WriteLine("Key:test3 is not existed");
            }
            // 05.设置数据过期时间：5秒后过期
            memClient.Add("test4", "expired", DateTime.Now.AddSeconds(5));
            Console.WriteLine("test4:{0}", memClient.Get("test4"));
            Console.WriteLine("Please waiting the sleeping time");
            System.Threading.Thread.Sleep(6000);
            if (!memClient.KeyExists("test4"))
            {
                Console.WriteLine("test4 is expired");
            }
            Console.WriteLine("----------------------------测试完成----------------------------");

            // 关闭SockIO池
            sockIOPool.Shutdown();

            Console.ReadKey();
        }
    }
}
