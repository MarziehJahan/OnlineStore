using OnlineStore.Domain.Orders;

namespace OnlineStore.Domain.Users
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public User(long id, string name, List<Order> orders)
        {
            Id = id;
            Name = name;
            Orders = orders;
        }
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public User()
        { }
    }
}
