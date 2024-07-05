namespace OnlineStore.Application.Contract.Products
{
    public class GetProductResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int InventoryCount { get; set; }
        public double Price { get; set; }
        public decimal Discount { get; set; }

        public GetProductResponse(long id, string title, int inventoryCount, double price, decimal discount)
        {
            Id = id;
            Title = title;
            InventoryCount = inventoryCount;
            Price = price;
            Discount = discount;
        }
    }
}
