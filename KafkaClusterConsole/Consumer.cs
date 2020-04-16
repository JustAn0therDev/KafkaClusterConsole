using Confluent.Kafka;
using System;

namespace KafkaClusterConsole
{
    class Consumer
    {
        private readonly ConsumerConfig _config;
        private bool Consuming { get; set; }
        private string TopicName { get; set; }

        public Consumer(ConsumerConfig config, string queueTopic)
        {
            _config = config;
            TopicName = queueTopic;
            Consuming = true;
        }

        public void ConsumeTopic()
        {
            using var consumer = new ConsumerBuilder<string, string>(_config).Build();
            consumer.Subscribe(TopicName);
            while (Consuming)
            {
                ConsumeResult<string, string> consumeResult = consumer.Consume();
                WriteConsumedMessageOnConsole(consumeResult.Message.Value);
            }
            consumer.Close();
        }

        public void WriteConsumedMessageOnConsole(string consumedMessage)
            => Console.WriteLine($"Consumed message '{consumedMessage}' from '{TopicName}'");
    }
}
