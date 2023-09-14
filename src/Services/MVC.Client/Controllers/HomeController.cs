using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Client.Infrastructure;
using MVC.Client.Models;
using MVC.Client.SyncDataClient;
using Newtonsoft.Json.Linq;

namespace MVC.Client.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly IDataClient dataClient;
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration configuration;

    public HomeController(IDataClient dataClient, ILogger<HomeController> logger, IConfiguration configuration)
    {
        this.dataClient = dataClient;
        _logger = logger;
        this.configuration = configuration;
    }

    public async Task<IActionResult> Index()
    {
        return RedirectToAction("Index", "Products");
    }

    public IActionResult Logout()
    {
        TokenHelper.Token = null;
        return SignOut("Cookies", "oidc");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
