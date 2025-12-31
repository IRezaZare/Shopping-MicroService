using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Queries.Products;

public class GetProductByTypeQuery : IRequest<IEnumerable<ProductResponse>>
{
    public string Type { get; set; }

    public GetProductByTypeQuery(string type)
    {
        Type = type;
    }
}
public class GetProductByTypeQueryHandler(IProductRepository productRepository , IMapper mapper) : IRequestHandler<GetProductByTypeQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetProductByTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetProductsByType(request.Type);
        return mapper.Map<IEnumerable<ProductResponse>>(result);
    }
}