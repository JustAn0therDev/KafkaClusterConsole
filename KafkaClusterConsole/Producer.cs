using Confluent.Kafka;
using System;
using System.Collections.Generic;

namespace KafkaClusterConsole
{
    class GeneralProducer : IKafkaProducer
    {
        public ProducerConfig Config { get; set; }
        public DeliveryResult<string, string> ProducedMessageDeliveryResult { get; set; }
        public string TopicName { get; set; }
        public KeyValuePair<string, string> KafkaMessage { get; set; }

        public GeneralProducer(ProducerConfig config, string topicName)
        {
            Config = config;
            TopicName = topicName;
        }

        public void ProduceMessage(string messageKey, string messageValue)
        {
            try
            {
                CreateMessageToProduce(messageKey, messageValue);
                SendProducedMessageToTopic();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateMessageToProduce(string messageKey, string messageValue) {
            KafkaMessage = new KeyValuePair<string, string>(messageKey, messageValue);
        }

        public void SendProducedMessageToTopic()
        {
            using var producer = new ProducerBuilder<string, string>(Config).Build();
            producer.Produce(TopicName, new Message<string, string>
            {
                Key = KafkaMessage.Key,
                Value = KafkaMessage.Value.ToString()
            });
            Console.WriteLine($"Produced message...");
        }
    }
}