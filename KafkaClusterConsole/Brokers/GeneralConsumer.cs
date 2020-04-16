using Confluent.Kafka;
using System;
using KafkaClusterConsole.Interfaces;

namespace KafkaClusterConsole.Brokers
{
    class GeneralConsumer : IKafkaConsumer
    {
        public ConsumerConfig Config { get; set; }
        private bool Consuming { get; set; }
        public string TopicName { get; set; }

        public GeneralConsumer(ConsumerConfig config, string queueTopic)
        {
            Config = config;
            TopicName = queueTopic;
            Consuming = true;
        }

        public void ConsumeTopic()
        {
            try {
                StartConsumingTopic();
            }
            catch (Exception ex) {
                StopConsuming();
                Console.WriteLine(ex.Message);
            }
        }

        public void StartConsumingTopic() {
            using var consumer = new ConsumerBuilder<string, string>(Config).Build();
            consumer.Subscribe(TopicName);
            while (Consuming)
            {
                ConsumeResult<string, string> consumeResult = consumer.Consume();
                WriteConsumedMessageOnConsole(consumeResult.Message.Value);
            }
            consumer.Close();
        }
        private void WriteConsumedMessageOnConsole(string consumedMessage) {
            if (ConsumedMessageIsNull(consumedMessage))
                Console.WriteLine($"Consumed null message from '{TopicName}'.");
            else 
                Console.WriteLine($"Consumed message '{consumedMessage}' from '{TopicName}'");
        }
            
        private bool ConsumedMessageIsNull(string consumedMessage) 
            => !string.IsNullOrEmpty(consumedMessage) ? false : true;

        private bool StopConsuming() => Consuming = false;

    }
}
