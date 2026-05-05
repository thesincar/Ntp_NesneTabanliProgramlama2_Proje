using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ntp.Application.Features.Products.Command.CreateProduct;
using Ntp.Application.Features.Products.Command.DeleteProduct;
using Ntp.Application.Features.Products.Command.UpdateProduct;
using Ntp.Application.Features.Products.Queries.GetAllProducts;

namespace Ntp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var values = await mediator.Send(new GetAllProductsQueryRequest());
        return Ok(values);
    }

    [HttpPost("createproduct")]
    public async Task<IActionResult> CreateProduct(CreateProductCommandRequest createProductCommandRequest)
    {
        await mediator.Send(createProductCommandRequest);
        return Ok();
    }
    [HttpPost("updateproduct")]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest updateProductCommandRequest)
    {
        await mediator.Send(updateProductCommandRequest);
        return Ok();
    }
    [HttpPost("deleteproduct")]
    public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest deleteProductCommandRequest)
    {
        await mediator.Send(deleteProductCommandRequest);
        return Ok();
    }
}
