using System;
using Microsoft.Extensions.Configuration;
using StockQuoteAlert.Services;
using StockQuoteAlert.Models;
using StockQuoteAlert.Utils;
//TODO Revisar progam
namespace StockQuoteAlert
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: StockQuoteAlert <AssetSymbol> <SellingPrice> <BuyingPrice>");
                return;
            }

            string assetSymbol = args[0];
            if (!decimal.TryParse(args[1], out decimal sellingPrice))
            {
                Console.WriteLine("Invalid Selling Price.");
                return;
            }

            if (!decimal.TryParse(args[2], out decimal buyingPrice))
            {
                Console.WriteLine("Invalid Buying Price.");
                return;
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var emailService = new EmailService(configuration);
            var stock = new Stock(assetSymbol, sellingPrice, buyingPrice);
            var stockQuoteAlertService = new StockQuoteAlertService(stock, emailService);

            stockQuoteAlertService.StartMonitoring();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            stockQuoteAlertService.StopMonitoring();
        }
    }
}