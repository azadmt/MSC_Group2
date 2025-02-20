using Framework.Application;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.ProductUsecase;
using ProductCatalog.Domain.Product;
using ProductCatalog.DomainContract;
using ProductCatalog.Pesistence.Ef;
using ProductCatalog.Pesistence.Ef.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
        .AddDbContext<ProductCatalogDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));


builder.Services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    //x.AddConsumer<ProductCategoryCreatedEventHandler>();
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

builder.Services
.AddHealthChecks()
.AddSqlServer(builder.Configuration.GetConnectionString("default"))
.AddRabbitMQ(new Uri("amqp://guest:guest@localhost:5672"))
;

//builder.Services.AddHealthChecksUI();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.UseHealthChecks("/hc");
//app.UseHealthChecksUI(options => options.UIPath = "/hc-ui");
app.MapControllers();
//app.MapHealthChecks("/hc");
//app.MapHealthChecks("/hc-d", new HealthCheckOptions
//{
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});

//app.UseEndpoints(endpoints =>
//{
//  //  endpoints.MapHealthChecksUI();
//});

app.Run();
