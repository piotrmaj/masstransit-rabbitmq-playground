using MassTransit;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventConsumer
{
    public class ValueEnteredConsumer : IConsumer<ValueEntered>
    {
        public Task Consume(ConsumeContext<ValueEntered> context)
        {
            var message = context.Message;
            return Console.Out.WriteLineAsync($"Message recieved.\n\tid: {message.Value}\n\n");
            //return Console.Out.WriteLineAsync(
            //    $"Message recieved.\n\tid: {message.CorrelationId.Stringify()}\n\ttimestamp: {message.Timestamp.ToLongTimeString()}\n\tmessage: {message.Message}\n\n"
            //);
        }
    }
}
