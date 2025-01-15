using System;

namespace StockPriceMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: StockPriceMonitor <AssetSymbol> <SellingPrice> <BuyingPrice>");
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

            StockPriceService stockPriceService = new StockPriceService(assetSymbol, sellingPrice, buyingPrice);
            stockPriceService.StartMonitoring();

            Console.WriteLine("Monitoring started. Press any key to exit...");
            Console.ReadKey();
        }
    }
}