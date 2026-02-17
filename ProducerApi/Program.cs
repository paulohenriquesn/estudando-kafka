using ProducerApi.Infra;
using ProducerApi.Repositories;
using ProducerApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddSingleton<DBContext>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IMessageService, KafkaService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();