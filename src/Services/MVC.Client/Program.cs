using Microsoft.EntityFrameworkCore;
using MVC.Client.Data;
using MVC.Client.SyncDataClient;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Register HttpClient
builder.Services.AddHttpClient<IDataClient, DataClient>();

// Register Configuration
builder.Services.AddSingleton<IConfiguration>(provider => builder.Configuration);

// Register Db Context
builder.Services.AddDbContext<MVCDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("CatalogConnnection"));
});

// Register Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Authentication Section
JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
.AddCookie("Cookies")
.AddOpenIdConnect(builder.Configuration["Identity:AuthenticationScheme"], options =>
{
    options.RequireHttpsMetadata = false;
    options.Authority = builder.Configuration["Identity:Authority"];

    options.ClientId = builder.Configuration["Identity:ClientId"];
    options.ClientSecret = builder.Configuration["Identity:ClientSecret"];
    options.ResponseType = "code";
    options.UsePkce = true;

    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;

    options.Scope.Add("profile");
    options.GetClaimsFromUserInfoEndpoint = true;

    //options.Scope.Add("CatalogAPI");
    //options.Scope.Add("DiscountAPI");
    //options.Scope.Add("BasketAPI");

    //options.Scope.Add("offline_access");
});
#endregion

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

/////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
