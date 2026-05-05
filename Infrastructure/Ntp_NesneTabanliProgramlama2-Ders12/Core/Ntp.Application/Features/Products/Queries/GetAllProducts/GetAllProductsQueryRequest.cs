using MediatR;

namespace Ntp.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
{
}