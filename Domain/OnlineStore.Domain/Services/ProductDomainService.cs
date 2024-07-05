using OnlineStore.Domain.Products;

namespace OnlineStore.Domain.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> TitleIsDuplicate(string title)
        {
            return await _productRepository.ProductTitleExists(title, CancellationToken.None);
        }
    }
}
