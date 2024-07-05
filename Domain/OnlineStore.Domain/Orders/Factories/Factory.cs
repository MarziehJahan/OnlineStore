namespace OnlineStore.Domain.Orders.Factories
{
    public class Factory
    {
        public static Order CreateOrder(long productId, DateTime creationDate, long buyerId)
            => new Order(productId, creationDate, buyerId);
    }
}
