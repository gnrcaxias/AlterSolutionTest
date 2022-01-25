using AlterSolutionTest.Domain.Entities;
using AlterSolutionTest.Domain.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AlterSolutionTest.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            return Ok(category);
        }

        [HttpGet]
        [Route("GetPage")]
        public async Task<IActionResult> GetPage(int page = 1, int countReg = 10)
        {
            var listCategory = await _categoryService.GetPage(page, countReg);

            return Ok(listCategory);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                if (category == null) return NotFound();

                await _categoryService.DeleteCategory(id);
                return Ok("Produto deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Category category)
        {
            try
            {
                await _categoryService.CreateCategory(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            try
            {
                await _categoryService.UpdateCategory(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("Patch")]
        [HttpPatch]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Category> patchCategory)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category != null)
                patchCategory.ApplyTo(category);

            await _categoryService.UpdateCategory(category);

            return Ok(category);
        }
    }
}
