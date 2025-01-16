namespace StockQuoteAlert.Models
{
    public class Stock
    {
        private string AssetSymbol { get; set; }
        private decimal SellingPrice { get; set; }
        private decimal BuyingPrice { get; set; }
        private bool SalesSituationChanged { get; set; }
        private string LastSalesSituation { get; set; }
    
        public Stock(string assetSymbol, decimal sellingPrice, decimal buyingPrice)
        {
            this.AssetSymbol = assetSymbol;
            this.SellingPrice = sellPrice;
            this.BuyingPrice = buyPrice;
            this.SalesSituationChange = false;
            this.LastSalesSituation = '';
        }
    
        public string SalesSituation(int price)
        {
            int salesSituation = price > this.SellPrice ? 'vender' : price < this.BuyPrice ? 'comprar' : 'manter';

            if (!salesSituation.Equals(LastSalesSituation))
            {
                this.SalesSituationChanged = true;
            }else{
                this.SalesSituationChanged = false;
            }

            this.LastSalesSituation = salesSituation;

            return salesSituation;
        }
    }
}