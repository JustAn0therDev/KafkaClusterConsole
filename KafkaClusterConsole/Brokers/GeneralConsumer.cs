using System;
using Confluent.Kafka;
using KafkaClusterConsole.Interfaces;

namespace KafkaClusterConsole.Brokers
{
    class GeneralConsumer : IKafkaConsumer
    {
        public ConsumerConfig Config { get; set; }
        private bool _consuming { get; set; }
        public string TopicName { get; set; }

        public GeneralConsumer(ConsumerConfig config, string queueTopic)
        {
            Config = config;
            TopicName = queueTopic;
            _consuming = true;
        }

        public void ConsumeTopic()
        {
            try
            {
                StartConsumingTopic();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                StopConsuming();
            }
        }

        public void StartConsumingTopic()
        {
            using var consumer = new ConsumerBuilder<string, string>(Config).Build();
            consumer.Subscribe(TopicName);
            while (_consuming)
            {
                ConsumeResult<string, string> consumeResult = consumer.Consume();
                WriteConsumedMessageOnConsole(consumeResult.Message.Value);
            }
            consumer.Close();
        }
        private void WriteConsumedMessageOnConsole(string consumedMessage)
        {
            if (ConsumedMessageIsNull(consumedMessage))
                Console.WriteLine($"Consumed null message from '{TopicName}'.");
            else
                Console.WriteLine($"Consumed message '{consumedMessage}' from '{TopicName}'");
        }

        private bool ConsumedMessageIsNull(string consumedMessage)
            => !string.IsNullOrEmpty(consumedMessage) ? false : true;

        private void StopConsuming() => _consuming = false;
    }
}
