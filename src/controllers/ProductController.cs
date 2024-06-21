using Api.TheSill.src.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.TheSill.src.controllers {
    [ApiController]
    [Route("api/products")]
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
    }
}