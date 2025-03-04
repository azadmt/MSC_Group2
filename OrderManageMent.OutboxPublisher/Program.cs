using Framework.OutboxPublisher;
using MassTransit;
using System.Data;
using System.Data.SqlClient;

namespace OrderManageMent.OutboxPublisher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext,services) =>
                {

                    services.AddSingleton<IDbConnection>(new SqlConnection(hostContext.Configuration.GetConnectionString("default")));

                    services.AddSingleton<OutboxManager>();

                    services.AddMassTransit(x =>
                    {
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host("localhost", "/", h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                            });
                        });
                    });
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}