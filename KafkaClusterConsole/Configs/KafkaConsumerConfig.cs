using System.Net;
using Confluent.Kafka;

namespace KafkaClusterConsole.Configs
{
    static class KafkaConsumerConfig
    {
        public static ConsumerConfig Config {
            get {
                return new ConsumerConfig {
                    BootstrapServers = "localhost:9092",
                    GroupId = Dns.GetHostName()
                };
            }
        }
    }
}