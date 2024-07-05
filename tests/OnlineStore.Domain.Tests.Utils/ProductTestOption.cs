using OnlineStore.Domain.Services;

namespace OnlineStore.Domain.Tests.Utils
{
    public class ProductTestOption<T> where T : ProductTestOption<T>
    {
        public string Title;
        public double Price;
        public decimal Discount;
        public IProductDomainService ProductDomainService;

        protected ProductTestOption()
        {
            Title = ProductTestUtil.Title;
            Price = ProductTestUtil.Price;
            Discount = ProductTestUtil.Discount;
        }

        public T WithTitle(string title)
        {
            this.Title = title;
            return this as T;
        }
        public T WithPrice(double price)
        {
            this.Price = price;
            return this as T;
        }
        public T WithDiscount(decimal discount)
        {
            this.Discount = discount;
            return this as T;
        }

        public T WithProductDomainService(IProductDomainService productDomainService)
        {
            this.ProductDomainService = productDomainService;
            return this as T;
        }
    }
}
