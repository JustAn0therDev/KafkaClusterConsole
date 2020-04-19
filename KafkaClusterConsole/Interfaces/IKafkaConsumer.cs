using Confluent.Kafka;

namespace KafkaClusterConsole.Interfaces
{
    public interface IKafkaConsumer
    {
        ConsumerConfig Config { get; set; }
        string TopicName { get; set; }
        void ConsumeTopic();
    }
}