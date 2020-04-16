using System.Net;
using Confluent.Kafka;

namespace KafkaClusterConsole.Configs
{
    static class KafkaProducerConfig
    {
        public static ProducerConfig Config {
            get {
                return new ProducerConfig {
                    BootstrapServers = "localhost:135",
                    ClientId = Dns.GetHostName(),
                    Debug = "topic"
                };
            }
        }
    }
}