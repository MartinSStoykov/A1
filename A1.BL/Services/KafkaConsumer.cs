using A1.Models;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace A1.BL.Services
{
    public class KafkaConsumer : IHostedService
    {
        private IConsumer<byte[], Motor> _consumer;

        public KafkaConsumer()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost",
                AutoCommitIntervalMs = 5000,
                FetchWaitMaxMs = 50,
                GroupId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true,
                ClientId = "2"
            };

            _consumer = new ConsumerBuilder<byte[], Motor>(config)
                            .SetValueDeserializer(new MsgPackDeserializer<Motor>())
                            .Build();
        }

        void Print(string s)
        {
            Console.WriteLine(s);
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _consumer.Subscribe("Motors");
            Task.Factory.StartNew(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var result = _consumer.Consume(cancellationToken);
                        MotorList.motor.Add(result.Message.Value);
                        Console.WriteLine("Incoming message:");
                        Console.WriteLine($"Motor with name: {result.Message.Value.Name}, with year of production: {result.Message.Value.Year} \n");
                    }
                    catch (ConsumeException ex)
                    {
                        Console.WriteLine($"Error: {ex.Error.Reason}");
                    }
                }
            }, cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}