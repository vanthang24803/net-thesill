using Api.TheSill.src.common.validations;
using Api.TheSill.src.domain.dtos.product;
using Api.TheSill.src.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.TheSill.src.controllers {
    [ApiController]
    [Route("api/products")]
    [ValidateModelState]
    public class ProductController : ControllerBase {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _productService.FindAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDetail([FromRoute] Guid id) {
            return Ok(await _productService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request,  IFormFile thumbnail) {
            return Ok(await _productService.Save(thumbnail, request));
        }

        [HttpPut]
        [Route("{productId}")]

        public async Task<IActionResult> Update(
            [FromBody] UpdateProductRequest request,
            [FromRoute] Guid productId
        ) {
            return Ok(await _productService.Update(productId, request));
        }

        [HttpDelete]
        [Route("{productId}")]

        public async Task<IActionResult> Delete(
             [FromRoute] Guid productId
        ) {

            return Ok(await _productService.Delete(productId));
        }
    }
}