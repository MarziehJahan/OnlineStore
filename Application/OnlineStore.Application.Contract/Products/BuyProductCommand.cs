using MediatR;

namespace OnlineStore.Application.Contract.Products;

public class BuyProductCommand : IRequest
{
    public long ProductId { get; set; }
    public long BuyerId { get; set; }
}