using Framework.Application;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.OrderUseCase;
using OrderManagement.Domain.Contract;
using OrderManagement.Domain.Order;
using OrderManagement.Persistence;
using OrderManagement.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services
        .AddDbContext<OrderManagementDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped<ICommandHandler<CreateOrderCommand>, CreateOrderCommandHamdler>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSwaggerGen();

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
