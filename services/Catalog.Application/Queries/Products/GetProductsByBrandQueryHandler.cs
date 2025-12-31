using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Queries.Products;

public class GetProductsByBrandQuery : IRequest<IEnumerable<ProductResponse>>
{
    public string Brnad { get; set; }

    public GetProductsByBrandQuery(string brnad)
    {
        Brnad = brnad;
    }
}
public class GetProductsByBrandQueryHandler(IProductRepository productRepository , IMapper mapper) : IRequestHandler<GetProductsByBrandQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetProductsByBrand(request.Brnad);

        return mapper.Map<IEnumerable<ProductResponse>>(result);
    }
}