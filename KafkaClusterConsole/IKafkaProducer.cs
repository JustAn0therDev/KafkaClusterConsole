﻿using Confluent.Kafka;
using System.Collections.Generic;

namespace KafkaClusterConsole
{
    public interface IKafkaProducer
    {
        ProducerConfig Config { get; set; }
        DeliveryResult<string, string> ProducedMessageDeliveryResult { get; set; }
        string TopicName { get; set; }
        KeyValuePair<string, string> KafkaMessage { get; set; }
        void ProduceMessage(string messageKey, object messageValue);
    }
}