using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQDemo
{
    /// <summary>
    /// EasyNetQ  Rabbit类库
    /// GitHub:https://github.com/EasyNetQ/EasyNetQ
    /// https://www.cnblogs.com/shanfeng1000/p/12359190.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "host=localhost;virtualHost=/;username=admin;password=123456;timeout=60";

            //连接方式
            {
                //方式1
                {

                    //var bus1 = RabbitHutch.CreateBus(connectionString);
                }
                //方式2
                {
                    //HostConfiguration host = new HostConfiguration();
                    //host.Host = "192.168.18.129";
                    //host.Port = 5672;
                    //ConnectionConfiguration connection = new ConnectionConfiguration();
                    //connection.Port = 5672;
                    //connection.Password = "123456";
                    //connection.UserName = "admin";
                    //connection.VirtualHost = "/";
                    //connection.Timeout = 60;
                    //connection.Hosts = new HostConfiguration[] { host };
                    //var bus2 = RabbitHutch.CreateBus(connection, services => { });
                    //bus2.Dispose();//关闭连接
                }
            }

            ///Publish/Subscribe 模式
            ///一个队列对应一个实体，也就是说，一个队列中只能存放一个类型序列化后的数据
            ///rabbitmq中会创建一个名为 my_exchange_name 的交换机和一个名为 my_queue_name_subscriptionId 的队列，当然，交换机和队列的名称也可以自定义。
            {
                //订阅/Subscribe
                {
                    var bus = RabbitHutch.CreateBus(connectionString);
                    var result = bus.Subscribe<TextMessage>("subscriptionId", tm =>
                      {
                          Console.WriteLine("Recieve Message: {0}", tm.Text);
                      }, cfg =>
                      {
                          cfg.WithQueueName("my_queue_name")//生成的队列名是my_queue_name，不带subscriptionId
                             .WithTopic("a#");//路由匹配以a开头的路由，WithTopic是可以多次调用，让队列可以以不同的路由绑定到交换机
                      });

                    ///调用Dispose方法将停止EasyNetQ对队列的消费，并且关闭这个消费者的channel。
                    ///注意：IBus和IAndvancedBus的dispose，能够取消所有消费者，并关闭对RabbitMQ的连接。
                    //result.Dispose();//取消订阅。这个等价与 result.ConsumerCancellation.Dispose();
                }
                //发布/Publish
                using (var bus = RabbitHutch.CreateBus(connectionString, registerServices => { }))
                {
                    var input = "";
                    Console.WriteLine("Please enter a message. 'q'/'Q' to quit.");
                    while ((input = Console.ReadLine()).ToLower() != "q")
                    {
                        bus.Publish<TextMessage>(new TextMessage
                        {
                            Text = input
                        });
                    }
                }
            }


            ///Request/Response模式
            ///一个队列对应一个实体，也就是说，一个队列中只能存放一个类型序列化后的数据
            ///Request/Response模式类似于请求响应的过程——发送一个请求到服务器，服务器然后处理请求后返回一个响应。上述代码执行后，会在rabbitmq中创建一个名为easy_net_q_rpc的交换机，但是类型是direct
            {
                //响应/Respond
                {
                    var bus = RabbitHutch.CreateBus(connectionString);
                    bus.Respond<MyRequest, MyResponse>(request =>
                    {
                        return new MyResponse { Text = "Respond: " + request.Text };
                    },
                    cfg =>
                    {
                        cfg.WithQueueName("my_queue_name1");
                    });
                }

                //请求/Request
                using (var bus = RabbitHutch.CreateBus(connectionString))
                {
                    var input = "";
                    Console.WriteLine("Please enter a message. 'q'/'Q' to quit.");
                    while ((input = Console.ReadLine()).ToLower() != "q")
                    {
                        var response = bus.Request<MyRequest, MyResponse>(new MyRequest
                        {
                            Text = input
                        }, cfg =>
                        {
                            cfg.WithQueueName("my_queue_name1");
                        });
                        Console.WriteLine(response.Text);
                    }
                }
            }

            ///Send/Receive模式
            ///
            ///该模式不会创建交换机，也就是说Send/Receive不是基于交换机
            {
                //接收/Receive
                {
                    var bus = RabbitHutch.CreateBus(connectionString);

                    //多个接受类型
                    bus.Receive("my_queue_name2", hander =>
                    {
                        hander.Add<MyMessage>(r =>
                        {
                            Console.WriteLine(r.Text);
                        });
                        hander.Add<string>(r =>
                        {
                            Console.WriteLine(r);
                        });
                    });

                    //单个接受类型
                    //bus.Receive<MyMessage>("my_queue_name2", r =>
                    //{
                    //    Console.WriteLine("Receive:" + r.Text);
                    //});
                }

                //发送/Send
                using (var bus = RabbitHutch.CreateBus(connectionString))
                {
                    var input = "";
                    Console.WriteLine("Please enter a message. 'q'/'Q' to quit.");
                    while ((input = Console.ReadLine()).ToLower() != "q")
                    {
                        bus.Send("my_queue_name2", new MyMessage
                        {
                            Text = input
                        });
                        bus.Send("my_queue_name2", input);
                    }
                }
            }

            Console.ReadKey();


        }


        [Queue("my_queue_name", ExchangeName = "my_exchange_name")]
        public class TextMessage
        {
            public string Text { get; set; }
        }

        public class MyRequest
        {
            public string Text { get; set; }
        }
        public class MyResponse
        {
            public string Text { get; set; }
        }

        public class MyMessage
        {
            public string Text { get; set; }
        }

    }
}
