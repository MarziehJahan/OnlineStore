namespace OnlineStore.Domain.Orders
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order,CancellationToken cancellationToken);
    }
}
