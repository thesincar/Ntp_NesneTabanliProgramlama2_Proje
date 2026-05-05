using MediatR;
using Ntp.Application.UnitOfWorks;
using Ntp.Domain.Entities;

namespace Ntp.Application.Features.Products.Command.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
{
    private readonly IUnitOfWork unitOfWork;
    public DeleteProductCommandHandler(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
        product.IsDeleted = true;

        await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await unitOfWork.SaveAsync();

    }
}