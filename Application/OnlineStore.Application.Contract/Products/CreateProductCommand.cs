using MediatR;

namespace OnlineStore.Application.Contract.Products
{
    public class CreateProductCommand : IRequest
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public decimal Discount { get; set; }
    }
}
