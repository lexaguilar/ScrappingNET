using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using scrapper.Models;

namespace scrapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SmScrap _smScrap;

        public HomeController(ILogger<HomeController> logger, SmScrap smScrap)
        {
            _logger = logger;
            _smScrap = smScrap;
        }

        public async Task<IActionResult> Index()
        {

            

            //var page = await browser.NewPageAsync();
            //await page.GotoAsync("https://playwright.dev/dotnet");
            //await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });
            return View();
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
}
