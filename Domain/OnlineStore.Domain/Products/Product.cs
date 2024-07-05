using OnlineStore.Domain.Orders;
using OnlineStore.Domain.Services;

namespace OnlineStore.Domain.Products
{
    public class Product
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int InventoryCount { get; set; }
        public double Price { get; set; }
        public decimal Discount { get; set; }

        protected Product()
        { }

        public Product(string title, double price, decimal discount, IProductDomainService productDomainService)
        {
            if (productDomainService.TitleIsDuplicate(title).Result)
                throw new Exception("Duplicated Title");
            Title = title;
            Price = price;
            Discount = discount;
        }

        public void IncreaseInventory()
        {
            InventoryCount++;
        }

        public async Task<Order> Purchase(IPurchaseDomainService purchaseDomainService, long productId, long buyerId)
        {
            var order = await purchaseDomainService.Purchase(productId, buyerId);

            InventoryCount--;
            return order;
        }
    }
}
