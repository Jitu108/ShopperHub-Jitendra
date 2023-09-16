using Microsoft.EntityFrameworkCore;
using Ordering.API.Data;
using Ordering.API.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddDbContext<OrderingDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("CatalogConnnection"));
});

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
DataSeeder.Seed(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
