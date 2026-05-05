using Microsoft.AspNetCore.Mvc;
using Ntp.Application.UnitOfWorks;
using Ntp.Domain.Entities;

namespace Ntp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;

    public ValuesController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var values = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
        return Ok(values);
    }
}
