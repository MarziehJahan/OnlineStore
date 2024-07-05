namespace OnlineStore.Domain.Products
{
    public interface IProductRepository
    {
        Task Create(Product? product, CancellationToken cancellationToken);
        Task IncreaseInventory(long id, CancellationToken cancellationToken);
        Task<bool> ProductTitleExists(string title, CancellationToken cancellationToken);
        Task<Product> GetBy(long id, CancellationToken cancellationToken);
        Task<Product?> GetCheapestProduct(decimal discount, CancellationToken cancellationToken);
    }
}
