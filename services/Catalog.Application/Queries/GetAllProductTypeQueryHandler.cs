using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Queries;

public class GetAllProductTypeQuery : IRequest<IEnumerable<TypeResponse>>
{

}
public class GetAllProductTypeQueryHandler(ITypeRepository repository , IMapper mapper) : IRequestHandler<GetAllProductTypeQuery , IEnumerable<TypeResponse>>
{
    public async Task<IEnumerable<TypeResponse>> Handle(GetAllProductTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetProductTypes();
        return mapper.Map<IEnumerable<TypeResponse>>(result);
    }
}