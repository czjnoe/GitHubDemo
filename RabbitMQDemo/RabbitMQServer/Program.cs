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
                    ///同一时间给一个工作者发送1个的消息，或者换句话说。在一个工作者还在处理消息，并且没有响应消息之前，不要给他分发新的消息。相反，将这条新的消息发送给下一个不那么忙碌的工作者。
                    channel.BasicQos(0, 1, false);
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
