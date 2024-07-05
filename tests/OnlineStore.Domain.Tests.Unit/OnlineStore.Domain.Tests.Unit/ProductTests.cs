using FluentAssertions;
using NSubstitute;
using OnlineStore.Domain.Exceptions;
using OnlineStore.Domain.Products;
using OnlineStore.Domain.Services;
using OnlineStore.Domain.Tests.Utils;

namespace OnlineStore.Domain.Tests.Unit
{
    public class ProductTests
    {
        private readonly ProductTestBuilder _productTestBuilder;
        private readonly IProductRepository _productRepository;
        private IProductDomainService _productDomainService;
        public ProductTests()
        {
            _productTestBuilder = new ProductTestBuilder();
            _productRepository = Substitute.For<IProductRepository>();
            _productDomainService = new ProductDomainService(_productRepository);
        }

        [Fact]
        public void Concrete_properly()
        {
            var product = _productTestBuilder.WithProductDomainService(_productDomainService).Build();

            product.Title.Should().Be(_productTestBuilder.Title);
            product.Price.Should().Be(_productTestBuilder.Price);
            product.Discount.Should().Be(_productTestBuilder.Discount);
        }

        [Fact]
        public void given_title_when_duplicated_return_error()
        {
            var product = _productTestBuilder.WithProductDomainService(_productDomainService).Build();

            _productRepository.ProductTitleExists(product.Title, CancellationToken.None).Returns(true);

            Action expectedProduct = () =>
                _productTestBuilder.WithTitle(product.Title).WithProductDomainService(_productDomainService).Build();

            expectedProduct.Should().Throw<DuplicatedProductNameException>();
        }


        [Fact]
        public void Increase_inventory_count_given_product_when_inventory_is_increased_then_inventory_count_is_plussed()
        {
            var product = _productTestBuilder.WithProductDomainService(_productDomainService).Build();
            var oldInventoryCount = product.InventoryCount;
            product.IncreaseInventory();
            product.InventoryCount.Should().Be(oldInventoryCount + 1);
        }

    }
}