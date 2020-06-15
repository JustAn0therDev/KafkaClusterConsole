using System;
using Confluent.Kafka;
using KafkaClusterConsole.Interfaces;

namespace KafkaClusterConsole.Brokers
{
    class GeneralProducer : IKafkaProducer
    {
        public ProducerConfig Config { get; set; }
        public string TopicName { get; set; }
        public string KafkaMessage { get; set; }

        public GeneralProducer(ProducerConfig config, string topicName)
        {
            Config = config;
            TopicName = topicName;
        }

        public void ProduceMessage(string messageValue)
        {
            try
            {
                CreateMessageToProduce(messageValue);
                SendProducedMessageToTopic();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateMessageToProduce(string messageValue)
           => KafkaMessage = messageValue;

        public void SendProducedMessageToTopic()
        {
            using var producer = new ProducerBuilder<Null, string>(Config).Build();
            producer.Produce(TopicName, new Message<Null, string>
            {
                Value = KafkaMessage
            });
        }
    }
}