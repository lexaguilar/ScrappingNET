using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using scrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace scrapper.HostedServices
{
    public class TaskService : BackgroundService
    {
        private IServiceProvider _services { get; }
        private readonly ILogger<TaskService> _logger;

        public TaskService(IServiceProvider services, ILogger<TaskService> logger)
        {
            _services = services;
            _logger = logger;

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            int executionCount = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("TaskService running.");

                executionCount++;

                await NotifyExpiredBills(stoppingToken);


                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);

            }
        }

        private async Task NotifyExpiredBills(CancellationToken stoppingToken)
        {
            try
            {
                using (var scope = _services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<SmScrap>();

                    var productos = RequestPageExtensions.GetRequests();


                    using var playwright = await Playwright.CreateAsync();
                    await using var browser = await playwright.Chromium.LaunchAsync();

                    foreach (var producto in productos)
                    {
                        var page = await browser.NewPageAsync();
                        await page.GotoAsync(producto.Url);
                        var price = await producto.CheckPrice(page);

                        var tv = new Tv
                        {
                            Name = producto.ProductId,
                            Description = producto.Vendor,
                            PriceString = price,
                            CreatedAt = DateTime.Now
                        };

                        context.Add(tv);
                        await context.SaveChangesAsync();


                    }


                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    static class TaskServiceCollectionExtensions
    {
        public static void AddTaskService(this IServiceCollection services)
        {

            services.AddHostedService<TaskService>();
        }
    }


}