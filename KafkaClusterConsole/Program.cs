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
            InitializeGeneralConsumer();
        }

        static void InitializeGeneralProducer() {
            IKafkaProducer producer = new GeneralProducer(KafkaProducerConfig.Config, "testing");
            producer.ProduceMessage("Hello");
        }

        static void InitializeGeneralConsumer() {
            IKafkaConsumer consumer = new GeneralConsumer(KafkaConsumerConfig.Config, "testing");
            consumer.ConsumeTopic();
        }
    }
}
