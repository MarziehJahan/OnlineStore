using OnlineStore.Domain.Products;
using OnlineStore.Domain.Users;

namespace OnlineStore.Domain.Orders
{
    public class Order
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public DateTime CreationDate { get; set; }
        public long BuyerId { get; set; }

        public Order(long productId, DateTime creationDate, long buyerId)
        {
            ProductId = productId;
            CreationDate = creationDate;
            BuyerId = buyerId;
        }

        //For Orm
        public Order()
        {
        }
    }
}
