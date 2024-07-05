using OnlineStore.Domain.Orders;

namespace OnlineStore.Domain.Services;

public interface IPurchaseDomainService
{
    Task<Order> Purchase(long productId, long buyerId);
}