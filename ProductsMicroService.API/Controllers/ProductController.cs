using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.IServices;
using BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductsMicroService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService _productService,IValidator<ProductAddRequest> _Addvalidator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutById([FromRoute] int id)
        {
            var product=await _productService.GetProductByCondition(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]ProductAddRequest productAddRequest)
        {
            var result = await _Addvalidator.ValidateAsync(productAddRequest);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var product = await _productService.AddProduct(productAddRequest);
            return  CreatedAtAction(nameof(GetProdutById), new {id=product.Id},product);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _productService.DeleteProduct(id);
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct( [FromRoute]int id,[FromBody]ProductUpdateRequest productUpdateRequest)
        {
            productUpdateRequest.Id = id;
            var product = await _productService.UpdateProduct(productUpdateRequest);
            return Ok(product);
        }
    }
}
