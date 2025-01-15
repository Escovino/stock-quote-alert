using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using Utils;
using Models;

namespace StockQuoteAlert.Services
{
    public class StockQuoteAlertService
    {
        private Stock _stock;
        private EmailService _emailService;

        public StockQuoteAlertService(Stock stock, EmailService emailService)
        {
            _stock = stock;
            _emailService = emailService;
            _timer = new Timer(60000); // Check every minute
            _timer.Elapsed += async (sender, e) => await MonitorPrice();
        }

        public void StartMonitoring()
        {
            _timer.Start();
        }

        public void StopMonitoring()
        {
            _timer.Stop();
        }

        private async Task MonitorPrice()
        {
            var currentPrice = await GetCurrentPrice();
            if (currentPrice < _buyingPrice)
            {
                // Trigger alert for buying price
                // EmailService.SendEmailAlert($"Price Alert: {_asset} is below the buying price of {_buyingPrice}. Current price: {currentPrice}");
            }
            else if (currentPrice > _sellingPrice)
            {
                // Trigger alert for selling price
                // EmailService.SendEmailAlert($"Price Alert: {_asset} is above the selling price of {_sellingPrice}. Current price: {currentPrice}");
            }
        }

        public async Task<decimal> GetCurrentPrice()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync($"{ApiUrl}?symbol={_asset}");
                // Parse response to get the current price
                // This is a placeholder; actual implementation will depend on the API response format
                return decimal.Parse(response); 
            }
        }
    }
}