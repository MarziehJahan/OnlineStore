using Framework.Cache;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using OnlineStore.Application.Contract.Products;
using OnlineStore.Application.Mappers;
using OnlineStore.Domain.Products;

namespace OnlineStore.Application.Products
{
    public class ProductQueryHandler : IRequestHandler<GetProductQuery, GetProductResponse?>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly CacheHelper<Product?> _cache;

        public ProductQueryHandler(IProductRepository productRepository, IMemoryCache memoryCache)
        {
            _productRepository = productRepository;
            _memoryCache = memoryCache;
            _cache = new CacheHelper<Product?>(_memoryCache);

        }
        public async Task<GetProductResponse?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _cache.OnGetCacheGetOrCreate($"GetProductQuery_{request.Discount}", () => _productRepository.GetCheapestProduct(request.Discount, cancellationToken).Result);
            return product?.MapToGetProductResponse();
        }
    }
}
