using Confluent.Kafka;

namespace KafkaClusterConsole.Interfaces
{
    public interface IKafkaProducer
    {
        ProducerConfig Config { get; set; }
        string TopicName { get; set; }
        string KafkaMessage { get; set; }
        void ProduceMessage(string messageValue);
    }
}