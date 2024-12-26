using Framework.Application;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application;
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
