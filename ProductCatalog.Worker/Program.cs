using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Query.DAL;
using ProductCatalog.Worker;
using ProductCatalog.Worker.EventHandler;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
     
        services
            .AddDbContext<QueryDbContext>(opt =>
        opt.UseSqlServer(hostContext.Configuration.GetConnectionString("default")));
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ProductCreatedEventHandler>();
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

await host.RunAsync();
