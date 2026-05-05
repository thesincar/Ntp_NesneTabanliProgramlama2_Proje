using MediatR;
using Microsoft.AspNetCore.Mvc;
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
}
