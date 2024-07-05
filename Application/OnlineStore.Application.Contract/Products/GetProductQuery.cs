using MediatR;

namespace OnlineStore.Application.Contract.Products;

public class GetProductQuery : IRequest<GetProductResponse>
{
    public decimal Discount { get; set; }
}