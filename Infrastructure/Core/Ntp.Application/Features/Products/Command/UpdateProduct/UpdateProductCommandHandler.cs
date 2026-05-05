using MediatR;
using Ntp.Application.Interfaces.AutoMapper;
using Ntp.Application.UnitOfWorks;
using Ntp.Domain.Entities;

namespace Ntp.Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
{
    private readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;
    public UpdateProductCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        UnitOfWork = _unitOfWork;
        Mapper = _mapper;
    }


    public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await UnitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
        var map = Mapper.Map<Product, UpdateProductCommandRequest>(request);

        var productCategories = await UnitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x => x.ProductId == product.Id);

        await UnitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

        foreach (var categoryId in request.CategoryIds)
            await UnitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new() { ProductId = product.Id, CategoryId = categoryId });

        await UnitOfWork.GetWriteRepository<Product>().UpdateAsync(map);

        await UnitOfWork.SaveAsync();
    }
}