using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Confluent.KafkaServer
{
    class Program
    {
        /// <summary>
        /// 以逗号隔开的多个代理地址
        /// </summary>
        public static string brokerUrl = "localhost:9092";
        public static string topic = "test-topic";
        public static string groupid = "test-consumer-group";

        static void Main(string[] args)
        {
            var conf = new ConsumerConfig
            {
                GroupId = groupid,//消费者分组id
                BootstrapServers = brokerUrl,
                EnableAutoCommit = true,//是否自动提交Offset，否的话需要Commit
                EnableAutoOffsetStore = false,

                // Note: The AutoOffsetReset property determines the start offset in the event
                // there are not yet any committed offsets for the consumer group for the
                // topic/partitions of interest. By default, offsets are committed
                // automatically, so in this example, consumption will only start from the
                // earliest message in the topic 'my-topic' the first time you run the program.
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var c = new ConsumerBuilder<Ignore, string>(conf).SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}")).Build())
            {
                c.Subscribe(topic);//主题

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var consumeResult = c.Consume(cts.Token);
                            Console.WriteLine($"Consumed message '{consumeResult.Message.Value}' at: '{consumeResult.TopicPartitionOffset}'.");
                            //c.Commit(consumeResult);//手动提交Offset,这种commit会产生阻塞，影响吞吐量
                            c.StoreOffset(consumeResult);//注意---->EnableAutoCommit = true时，才可真真提交
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
            }
        }
    }
}
