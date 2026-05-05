using MediatR;
using Ntp.Application.UnitOfWorks;
using Ntp.Domain.Entities;

namespace Ntp.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
{
    private readonly IUnitOfWork unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Product product = new Product(
            request.Name,
            request.Price,
            request.Description
            );
        await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

        var result = await unitOfWork.SaveAsync();

        if (result > 0)
        {
            foreach (var categoryıd in request.CategoryIds)
            {
                await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                {
                    ProductId = product.Id,
                    CategoryId = categoryıd
                });
            }
            await unitOfWork.SaveAsync();
        }
    }
}