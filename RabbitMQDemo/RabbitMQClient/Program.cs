using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient
{
    /// <summary>
    /// RabbitMQ
    /// 消息队列 生产者
    /// Exchange 交换机概念
    /// 使用RabbitMQ.Client类库
    /// GitHub:https://github.com/rabbitmq/rabbitmq-dotnet-client
    /// https://www.cnblogs.com/stulzq/p/7551819.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";//RabbitMQ服务地址
            factory.UserName = "guest";//用户名
            factory.Password = "guest";//密码
            bool durable = true;//持久化

            var queueName = "hello1";
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, durable, false, false, null);//创建一个名称为hello的消息队列
                    string message = "Hello World"; //传递的消息内容
                    var body = Encoding.UTF8.GetBytes(message);

                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;
                    properties.Persistent = true;//持久化  确保rabbitmq服务器重启不丢失数据


                    channel.BasicPublish("", queueName, properties, body); //开始传递
                    Console.WriteLine("已发送： {0}", message);
                    Console.ReadLine();
                }
            }
        }
    }
}
