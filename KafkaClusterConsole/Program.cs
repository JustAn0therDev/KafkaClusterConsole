using Confluent.Kafka;
using System.Net;

namespace KafkaClusterConsole
{
    class Program
    {
        static void Main() => InitializeKafkaProducerAndConsumer();

        static void InitializeKafkaProducerAndConsumer()
        {
            InitializeGeneralProducer();
            InitializeConsumer();
        }

        static void InitializeGeneralProducer() {
            ProducerConfig producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:135",
                ClientId = Dns.GetHostName(),
            };

            IKafkaProducer producer = new GeneralProducer(producerConfig, ".NET Core topic");

            producer.ProduceMessage("Message", "Hello");
        }

        static void InitializeConsumer() {
            ConsumerConfig consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:135",
                GroupId = Dns.GetHostName()
            };

            Consumer consumer = new Consumer(consumerConfig, ".NET Core topic");

            consumer.ConsumeTopic();
        }
    }
}
