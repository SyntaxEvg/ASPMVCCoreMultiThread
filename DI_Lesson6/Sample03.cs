using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orders.DAL.OrderDB;
using System;
using System.Runtime.CompilerServices;

namespace DI_Lesson6
{
    internal class Sample03
    {
        private static  IHost? _host;
        public static IHost Hosting => _host ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider serviceProvider => Hosting.Services;
        private static IHostBuilder CreateHostBuilder(string[] strings)
        {
           return Host.CreateDefaultBuilder(strings)
                .ConfigureHostConfiguration(opt => opt.AddJsonFile("appSettings.json"))
                .ConfigureAppConfiguration(opt =>
                                           opt.AddJsonFile("appSettings.json")
                                           .AddEnvironmentVariables()
                                           .AddCommandLine(strings)).ConfigureLogging(conf=>
                                                conf.ClearProviders().AddConsole().AddDebug()).ConfigureServices(ConfigureServices);
                
        }
      

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection serv)
        {
            serv.AddDbContext<OrdersDBContext>(opt => opt.UseSqlServer(host.Configuration["Settings:DBoptions:ConnectionStrings"]));
            //// serviceBuilder.AddScoped<IOrdersDBContext, OrdersDBContext>

            //var services = serv.BuildServiceProvider();
            //var context = services.GetRequiredService<OrdersDBContext>();
            //foreach (var item in context.Buyers)
            //{
            //    Console.WriteLine(item.ToString());
            //}
        }

        static async void Main(string[] args)
        {
            var host = Hosting;
            await  host.RunAsync();
            await PrintByuersAsync();
            Console.ReadLine();
            await host.StopAsync();
        }

        private static async Task PrintByuersAsync()
        {
            await using var servScope = serviceProvider.CreateAsyncScope();
             var servProv = servScope.ServiceProvider;

            var context = servProv.GetRequiredService<OrdersDBContext>();
            var logger = servProv.GetRequiredService<ILogger<Sample03>>();
            foreach (var item in context.Buyers)
            {
                logger.LogInformation($"Byuer:{item}");
            }
        }
    }
}