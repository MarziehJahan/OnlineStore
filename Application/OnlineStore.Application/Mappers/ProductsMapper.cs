using OnlineStore.Application.Contract.Products;
using OnlineStore.Domain.Products;

namespace OnlineStore.Application.Mappers
{
    public static class ProductsMapper
    {
        public static GetProductResponse? MapToGetProductResponse(this Product model)
        {
            return new GetProductResponse(model.Id, model.Title, model.InventoryCount, model.Price, model.Discount);
        }
    }
}
