using MediatR;
using Ntp.Application.Interfaces.AutoMapper;
using Ntp.Application.UnitOfWorks;
using Ntp.Domain.Entities;

namespace Ntp.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();
        var response = _mapper.Map<GetAllProductsQueryResponse, Product>(products);
        return response;
    }
}
