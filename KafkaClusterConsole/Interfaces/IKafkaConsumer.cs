using Confluent.Kafka;

namespace KafkaClusterConsole.Interfaces
{
    internal interface IKafkaConsumer
    {
        ConsumerConfig Config { get; set; }
        string TopicName { get; set; }
        void ConsumeTopic();
    }
}