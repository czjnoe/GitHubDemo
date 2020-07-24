using Confluent.KafkaClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confluent.KafkaDemo
{
    /// <summary>
    /// GitHub：https://github.com/confluentinc/confluent-kafka-dotnet
    /// 安装配置Kafka和Zookeeper:
    ///         https://www.cnblogs.com/IT-Ramon/p/12029092.html
    ///         https://blog.csdn.net/czjnoe/article/details/107555375
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                KafkaProducer.ProduceAsync(i.ToString(),"czj"+i);
            }
            Console.ReadKey();
        }
    }
}
