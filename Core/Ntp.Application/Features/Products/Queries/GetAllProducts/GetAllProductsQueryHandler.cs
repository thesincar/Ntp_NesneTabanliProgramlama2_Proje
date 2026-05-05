using MediatR;
using Microsoft.EntityFrameworkCore;
using Ntp.Application.DTOs;
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
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }
    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        //var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

        //List<GetAllProductsQueryResponse> response = new List<GetAllProductsQueryResponse>();

        var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Categories));

        var category = _mapper.Map<CategoryDto, Category>(new Category());
        var map = _mapper.Map<GetAllProductsQueryResponse, Product>(products);


        return map;
    }
}