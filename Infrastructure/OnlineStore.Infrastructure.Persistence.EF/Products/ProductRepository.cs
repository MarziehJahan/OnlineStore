using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Products;

namespace OnlineStore.Infrastructure.Persistence.EF.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineStoreDbContext _dbContext;

        public ProductRepository(OnlineStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Product? product, CancellationToken cancellationToken)
        {
            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task IncreaseInventory(long id, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(id);
            product?.IncreaseInventory();
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ProductTitleExists(string title, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.AnyAsync(x =>
                x.Title.Replace(" ", "").ToLower() == title.Replace(" ", "").ToLower(), cancellationToken: cancellationToken);
        }

        public async Task<Product> GetBy(long id, CancellationToken cancellationToken)
            => await _dbContext.Products.FindAsync(id, cancellationToken);

        public async Task<Product?> GetCheapestProduct(decimal discount, CancellationToken cancellationToken)
        => await _dbContext.Products.Where(x => x.Discount == discount).OrderBy(x => x.Price)
                .FirstOrDefaultAsync(cancellationToken);

    }
}
