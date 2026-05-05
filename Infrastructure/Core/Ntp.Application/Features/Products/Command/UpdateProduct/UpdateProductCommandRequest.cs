using MediatR;

namespace Ntp.Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommandRequest : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public IList<int> CategoryIds { get; set; }
}
