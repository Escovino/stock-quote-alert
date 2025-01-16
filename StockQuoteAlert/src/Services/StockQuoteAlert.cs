using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Timers;
using StockQuoteAlert.Models;

namespace StockQuoteAlert.Services
{
    public class StockQuoteAlertService
    {
        private Stock _stock;
        private EmailService _emailService;

        public StockQuoteAlertService(string assetSymbol, decimal sellingPrice, decimal buyingPrice)
        {
            _stock = new Stock(assetSymbol, sellingPrice, buyingPrice);
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
            if(_stock.SalesSituationChanged){
                var salesSituation = _stock.SalesSituation(currentPrice);
                var subject = $"Stock Alert: {_stock.AssetSymbol} - {salesSituation}";
                var body = $"Current price: {currentPrice}";
                _emailService.SendEmailAlert(null, subject, body);//TODO Revisar o serviço de envio de email
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