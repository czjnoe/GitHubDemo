using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confluent.KafkaClient
{
    public class KafkaProducer
    {
        /// <summary>
        /// 以逗号隔开的多个代理地址
        /// </summary>
        public static string brokerUrl = "localhost:9092";
        public static string topic = "test-topic";
        private static readonly object Locker = new object();
        private static ProducerBuilder<string, string> _producer;

        /// <summary>
        /// 单例生产
        /// </summary>
         static KafkaProducer()
        {
            if (_producer == null)
            {
                lock (Locker)
                {
                    if (_producer == null)
                    {
                        var config = new ProducerConfig
                        {
                            BootstrapServers = brokerUrl
                        };
                        _producer = new ProducerBuilder<string, string>(config);
                    }
                }
            }
        }


        /// <summary>
        /// 生产消息并发送消息
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="message">需要传送的消息</param>
        public async static void ProduceAsync(string key, string message)
        {
            using (var p = _producer.Build())
            {
                try
                {
                    var dr = await p.ProduceAsync(topic, new Message<string, string> { Key = key, Value = message });
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }

        /// <summary>
        /// 创建生产者
        /// </summary>
        public async static void ProduceAsync1(string message)
        {
            var config = new ProducerConfig { BootstrapServers = brokerUrl };
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync(topic, new Message<Null, string> { Value = message });
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }

        /// <summary>
        /// 创建生产者
        /// </summary>
        /// <param name="message"></param>
        public static void Produce(string message)
        {
            var conf = new ProducerConfig { BootstrapServers = brokerUrl };

            Action<DeliveryReport<Null, string>> handler = r =>
                Console.WriteLine(!r.Error.IsError
                    ? $"Delivered message to {r.TopicPartitionOffset}"
                    : $"Delivery Error: {r.Error.Reason}");

            using (var p = new ProducerBuilder<Null, string>(conf).Build())
            {
                for (int i = 0; i < 100; ++i)
                {
                    p.Produce(topic, new Message<Null, string> { Value = i.ToString() }, handler);
                }

                // wait for up to 10 seconds for any inflight messages to be delivered.
                p.Flush(TimeSpan.FromSeconds(10));
            }
        }

    }
}
