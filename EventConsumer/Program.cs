using MassTransit;
using Shared;
using System;

namespace EventConsumer
{
    public class Program
    {
        public static void Main()
        {
            IBusControl busControl = null;
            try
            {
                busControl = ConfigureBus();

                // Important! The bus must be started before using it!
                busControl.Start();
            }
            catch (Exception ex)
            {
                busControl.Stop();
            }
        }

        static IBusControl ConfigureBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                //cfg.Host(host);

                cfg.ReceiveEndpoint(host, "value_entered_queue", e =>
                {
                    e.Consumer<ValueEnteredConsumer>();
                });
            });
        }
    }
}
