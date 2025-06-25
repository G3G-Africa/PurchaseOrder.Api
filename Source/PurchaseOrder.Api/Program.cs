using PurchaseOrder.Api.Repository;
using ServiceLayer.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton(typeof(IInMemoryRepository<>), typeof(InMemoryRepository<>));
builder.Services.AddSingleton<IServiceLayerClient, ServiceLayerClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
