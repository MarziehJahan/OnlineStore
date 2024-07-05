using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Contract.Products;

namespace OnlineStore.Interface.WebApi.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost(nameof(PurchaseProduct))]
        public async Task<IActionResult> PurchaseProduct(BuyProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPatch(nameof(IncreaseInventoryProduct))]
        public async Task<IActionResult> IncreaseInventoryProduct(UpdateProductInventoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<GetProductResponse> Get([FromQuery] GetProductQuery query)
        {
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
