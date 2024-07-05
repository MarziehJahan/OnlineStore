using OnlineStore.Domain.Products;

namespace OnlineStore.Domain.Tests.Utils
{
    public class ProductTestBuilder : ProductTestOption<ProductTestBuilder>
    {
        public Product Build()
        {
            return new Product(Title, Price, Discount, ProductDomainService);
        }
    }
}
