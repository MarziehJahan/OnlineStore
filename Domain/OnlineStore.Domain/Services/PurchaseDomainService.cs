using OnlineStore.Domain.Orders;
using OnlineStore.Domain.Orders.Factories;
using OnlineStore.Domain.Products;
using OnlineStore.Domain.Users;

namespace OnlineStore.Domain.Services
{
    public class PurchaseDomainService : IPurchaseDomainService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public PurchaseDomainService(IProductRepository productRepository, IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }
        public async Task<Order> Purchase(long productId, long buyerId)
        {
            var product = await _productRepository.GetBy(productId, CancellationToken.None);
            GuardAgainstNotChargedProductsBeingPurchased(product);
            var buyer = await _userRepository.GetBy(buyerId, CancellationToken.None);
            GuardAgainstNotExistingUsers(buyer);

            var order = await _orderRepository.CreateOrder(Factory.CreateOrder(productId, DateTime.Now, buyer.Id), CancellationToken.None);
            return order;
        }

        private static void GuardAgainstNotExistingUsers(User? buyer)
        {
            if (buyer == null)
                throw new Exception("User not exist");
        }

        private static void GuardAgainstNotChargedProductsBeingPurchased(Product product)
        {
            if (product?.InventoryCount == 0)
                throw new Exception("Product not charged yet!");
        }
    }
}
