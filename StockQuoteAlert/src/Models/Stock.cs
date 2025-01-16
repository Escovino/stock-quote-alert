public class Stock
{
    private string Symbol { get; set; }
    private decimal SellPrice { get; set; }
    private decimal BuyPrice { get; set; }

    public Stock(string symbol, decimal sellPrice, decimal buyPrice)
    {
        Symbol = symbol;
        SellPrice = sellPrice;
        BuyPrice = buyPrice;
    }

    public int SalesSituation(int price)
    {
        return price > SellPrice ? 1 : price < BuyPrice ? -1 : 0;
    }
}