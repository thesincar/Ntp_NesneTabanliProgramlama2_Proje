using MediatR;

namespace Ntp.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandRequest : IRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public IList<int> CategoryIds { get; set; }

}
