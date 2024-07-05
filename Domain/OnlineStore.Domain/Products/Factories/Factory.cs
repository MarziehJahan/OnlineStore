using OnlineStore.Domain.Services;

namespace OnlineStore.Domain.Products.Factories
{
    public class Factory
    {
        public static Product? CreateProduct(string title, double price, decimal discount, IProductDomainService productDomainService)
        => new Product(title, price, discount, productDomainService);
    }
}
