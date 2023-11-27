using Microsoft.AspNetCore.Mvc;
using Quadro.Core.Infrastructure.WebApi;

namespace Quadro.Product.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : CustomControllerBase
{
    public ProductController(ICommandBus commandBus, IQueryBus queryBus)
                                     : base(commandBus, queryBus) { }


    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductModel model)
    {
        return await CommandResponse<bool>(new CreateProductCommand(model));
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductModel model)
    {
        return await CommandResponse<bool>(new UpdateProductCommand(model));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        return await CommandResponse<bool>(new DeleteProductCommand(id));
    }

    [HttpGet("getProduct")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return await QueryResponse<ProductModel>(new GetProductQuery(id));
    }

    [HttpGet("getProducts")]
    public async Task<IActionResult> GetAll()
    {
        return await QueryResponse<IEnumerable<ProductModel>>(new GetProductsQuery());
    }



}
