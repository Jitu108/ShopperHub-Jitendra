using Basket.API.Data;
using Basket.API.InterServiceCommunication.SyncDataService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
// Register Db Context
builder.Services.AddDbContext<ShoppingCartDbContext>(option =>
{
    option.UseInMemoryDatabase("InMem");
});

// Add GRPC
builder.Services.AddGrpc();

// Register Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();

//app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGrpcService<GrpcBasketService>();
});

app.Run();
