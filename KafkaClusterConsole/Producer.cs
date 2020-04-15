using Confluent.Kafka;
using System;
using System.Collections.Generic;

namespace KafkaClusterConsole
{
    public class Producer : IKafkaProducer
    {
        public ProducerConfig Config { get; set; }
        public DeliveryResult<string, string> ProducedMessageDeliveryResult { get; set; }
        public string TopicName { get; set; }
        public KeyValuePair<string, string> KafkaMessage { get; set; }

        public Producer(ProducerConfig config, string topicName)
        {
            Config = config;
            TopicName = topicName;
        }

        public void ProduceMessage(string messageKey, object messageValue)
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

        public void CreateMessageToProduce(string messageKey, object messageValue)
            => KafkaMessage = new KeyValuePair<string, string>(messageKey, messageValue.ToString());

        public void SendProducedMessageToTopic()
        {
            using var producer = new ProducerBuilder<string, string>(Config).Build();
            producer.Produce(TopicName, new Message<string, string>
            {
                Key = KafkaMessage.Key,
                Value = KafkaMessage.Value
            }, (DeliveryReport<string, string> deliveryReport) => LogProducedMessage(deliveryReport));
        }

        private void LogProducedMessage(DeliveryReport<string, string> deliveryReport) 
            => Console.WriteLine($"Produced message. Delivery report: {deliveryReport.Key} {deliveryReport.Value}");
    }
}