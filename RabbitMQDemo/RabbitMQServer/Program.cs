using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQServer
{
    /// <summary>
    /// 消息队列 消费者
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
                    channel.QueueDeclare(queueName, durable, false, false, null);

                    var consumer = new EventingBasicConsumer(channel);
                   
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body.ToArray());
                        Console.WriteLine("已接收： {0}", message);

                        channel.BasicAck(ea.DeliveryTag, false);//消息确认提交，会释放掉消息
                    };
                    channel.BasicConsume(queueName, false, consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}
