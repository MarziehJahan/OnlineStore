using OnlineStore.Domain.Orders;

namespace OnlineStore.Infrastructure.Persistence.EF.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineStoreDbContext _dbContext;

        public OrderRepository(OnlineStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> CreateOrder(Order order, CancellationToken cancellationToken)
        {
            await _dbContext.Orders.AddAsync(order, cancellationToken);
            //await _dbContext.SaveChangesAsync(cancellationToken);
            return order;
        }
    }
}
