using Api.TheSill.src.common.validations;
using Api.TheSill.src.domain.dtos.category;
using Api.TheSill.src.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.TheSill.src.services {
    [ApiController]
    [Route("api/categories")]
    [ValidateModelState]
    public class CategoryController : ControllerBase {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("seeds")]
        public async Task<IActionResult> GetSeeds() {
            var result = await _categoryService.Seeds();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await _categoryService.FindAll();
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> Create(
            [FromBody] CategoryRequest request
        ) {
            return Ok(await _categoryService.Create(request));
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(
            Guid id, [FromBody] CategoryRequest request
        ) {
            return Ok(await _categoryService.Update(id, request));
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FindOne(
            Guid id
        ) {
            return Ok(await _categoryService.FindOne(id));
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            return Ok(await _categoryService.Delete(id));
        }

    }
}