using Catalog.Application.Commands.Products;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Brands;
using Catalog.Application.Queries.Products;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

public class CatalogController(IMediator mediator) : ApiController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetProductById(string id, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetProductByIdQuery(id), cancellationToken));
    }
    [HttpGet("{name}")]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProductByName(string name, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetProductsByNameQuery(name), cancellationToken));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts()
    {
        return Ok(await mediator.Send(new GetAllProductsQuery()));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BrandResponse>>> GetAllBrands(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAllProductBrandsQuery(), cancellationToken));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TypeResponse>>> GetAllTypes(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAllProductTypeQuery(), cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GatProductsByBrandName(string brand ,
        CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetProductsByBrandQuery(brand), cancellationToken));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GatProductsByTypeName(string type ,
        CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetProductByTypeQuery(type), cancellationToken));
    }
    [HttpPost]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> CreateProduct([FromBody] CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(command, cancellationToken));
    }
    [HttpPut]
    public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(command, cancellationToken));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id , CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new DeleteProductCommand(id), cancellationToken));
    }
}