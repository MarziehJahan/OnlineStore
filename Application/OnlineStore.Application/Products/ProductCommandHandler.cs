using Framework.Exception;
using MediatR;
using OnlineStore.Application.Contract.Products;
using OnlineStore.Domain.Products;
using OnlineStore.Domain.Products.Factories;
using OnlineStore.Domain.Services;
using OnlineStore.Domain.Users;
using OnlineStore.Infrastructure.Persistence.EF;

namespace OnlineStore.Application.Products
{
    public class ProductCommandHandler : IRequestHandler<CreateProductCommand>
                                        , IRequestHandler<UpdateProductInventoryCommand>
                                        , IRequestHandler<BuyProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseDomainService _purchaseDomainService;
        private readonly IProductDomainService _productDomainService;
        private readonly IUserRepository _userRepository;
        private readonly OnlineStoreDbContext _context;

        public ProductCommandHandler(IProductRepository productRepository, IPurchaseDomainService purchaseDomainService, IProductDomainService productDomainService
            , IUserRepository userRepository, OnlineStoreDbContext context)
        {
            _productRepository = productRepository;
            _purchaseDomainService = purchaseDomainService;
            _productDomainService = productDomainService;
            _userRepository = userRepository;
            _context = context;
        }
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Factory.CreateProduct(request.Title, request.Price, request.Discount, _productDomainService);
            await _productRepository.Create(product, cancellationToken);
        }

        public async Task Handle(UpdateProductInventoryCommand request, CancellationToken cancellationToken)
        => await _productRepository.IncreaseInventory(request.Id, cancellationToken);

        public async Task Handle(BuyProductCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var product = await _productRepository.GetBy(request.ProductId, cancellationToken);
                var order = await product.Purchase(_purchaseDomainService, request.ProductId, request.BuyerId);
                var buyer = await _userRepository.GetBy(request.BuyerId, cancellationToken);
                buyer.AddOrder(order);
                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (BusinessException e)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new BusinessException(e.Message);
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception(e.Message);
            }
        }
    }
}
