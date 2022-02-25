using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlayService;
using PlayService.Interfaces;
using PlayService.Models;

namespace BedeSlotGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ISlotMachine, SlotMachine>();
                    services.AddTransient<ISymbolGenerator, SymbolGenertor>();
                    services.AddTransient<IStartGame, StartGame>();
                    services.AddTransient<IContinueGame, ContinueGame>();
                    //services.AddTransient<IIsGameOver, >();
                    services.AddTransient<ICalculateRow, CalculateRow>();
                })

            .Build();

            //Needs a concrete type for starting off, not the interface.
            var svc = ActivatorUtilities.CreateInstance<SlotMachine>(host.Services);

            svc.BedeSlot();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
    }

}
