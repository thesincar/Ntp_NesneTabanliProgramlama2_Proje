using MediatR;
using Ntp.Application.UnitOfWorks;
using Ntp.Domain.Entities;

namespace Ntp.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

        List<GetAllProductsQueryResponse> response = new List<GetAllProductsQueryResponse>();

        foreach (var product in products)
        {
            response.Add(new GetAllProductsQueryResponse
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price
            });

        }
        return response;
    }
}