using Confluent.Kafka;
using System.Net;

namespace KafkaClusterConsole
{
    class Program
    {
        static void Main()
        {
            InitializeKafkaProducerAndConsumer();
        }

        static void InitializeKafkaProducerAndConsumer()
        {

            ProducerConfig producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:5357",
                ClientId = Dns.GetHostName(),
                ReceiveMessageMaxBytes = int.MaxValue
            };

            IKafkaProducer producer = new Producer(producerConfig, ".NET Core topic");

            producer.ProduceMessage("Message", "Hello");

            ConsumerConfig consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:5357",
                GroupId = Dns.GetHostName(),
                ReceiveMessageMaxBytes = int.MaxValue,
            };

            Consumer consumer = new Consumer(consumerConfig, ".NET Core topic");

            consumer.ConsumeTopic();

        }
    }
}
