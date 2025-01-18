using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Timers;
using StockQuoteAlert.Models;
using StockQuoteAlert.Utils;

namespace StockQuoteAlert.Services
{
    public class StockQuoteAlertService
    {
        private Stock _stock;
        private EmailService _emailService;
        private Timer _timer;

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
            _stock.UpdateSalesSituation(currentPrice);
            if(_stock.SalesSituationChanged){
                var subject = $"Stock Alert: {_stock.AssetSymbol} - {_stock.LastSalesSituation}";
                var body = $"Current price: {currentPrice}";
                _emailService.SendEmail(subject, body);
            }
        }

        public async Task<decimal> GetCurrentPrice()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync($"https://brapi.dev/api/quote/{_stock.AssetSymbol}?token=kfhjUmDuFEZusvXsvucSoT");
                var json = JObject.Parse(response);
                var currentPrice = json["results"][0]["regularMarketPrice"].Value<decimal>();
                return currentPrice;
            }
        }
    }
}