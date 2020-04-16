using System.Net;
using Confluent.Kafka;
using KafkaClusterConsole.Brokers;
using KafkaClusterConsole.Interfaces;
using KafkaClusterConsole.Configs;

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
            IKafkaProducer producer = new GeneralProducer(KafkaProducerConfig.Config, ".NET Core topic");
            producer.ProduceMessage("Message", "Hello");
        }

        static void InitializeConsumer() {
            IKafkaConsumer consumer = new GeneralConsumer(KafkaConsumerConfig.Config, ".NET Core topic");
            consumer.ConsumeTopic();
        }
    }
}
