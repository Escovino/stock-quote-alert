namespace StockQuoteAlert.Models
{
    public class Stock
    {
        public string AssetSymbol { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public bool SalesSituationChanged { get; set; }
        public string LastSalesSituation { get; set; }
    
        public Stock(string assetSymbol, decimal sellingPrice, decimal buyingPrice)
        {
            this.AssetSymbol = assetSymbol;
            this.SellingPrice = sellingPrice;
            this.BuyingPrice = buyingPrice;
            this.SalesSituationChanged = false;
            this.LastSalesSituation = "";
        }
    
        public void UpdateSalesSituation(decimal price)
        {
            string salesSituation = price > this.SellingPrice ? "vender" : price < this.BuyingPrice ? "comprar" : "manter";

            if (!salesSituation.Equals(LastSalesSituation))
            {
                this.SalesSituationChanged = true;
            }else{
                this.SalesSituationChanged = false;
            }

            this.LastSalesSituation = salesSituation;
        }
    }
}