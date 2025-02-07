using InventoryMnagement.Worker.DataAccess;
using InventoryMnagement.Worker.EventHandler;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace InventoryMnagement.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {

                    services
            .AddDbContext<InventoryManagementDbContext>(opt =>
                opt.UseSqlServer(hostContext.Configuration.GetConnectionString("default")));
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<OrderCreatedEventHandler>();
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.ConfigureJsonSerializerOptions(options =>
                            {
                                // customize the JsonSerializerOptions here
                                return options;
                            });
                            cfg.ConfigureEndpoints(context);
                            //cfg.UseConsumeFilter(typeof(MyConsumeLogFilter<>), context);

                            //cfg.ReceiveEndpoint(nameof(ProductCategoryCreatedEvent), e =>
                            //{
                            //    e.ConfigureConsumer<ProductCategoryCreatedEventHandler>(context);
                            //});
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