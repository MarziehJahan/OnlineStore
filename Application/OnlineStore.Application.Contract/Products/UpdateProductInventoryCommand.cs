using MediatR;

namespace OnlineStore.Application.Contract.Products;

public class UpdateProductInventoryCommand : IRequest
{
    public long Id { get; set; }
}