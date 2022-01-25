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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;


        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var Product = await _ProductService.GetProductById(id);

            return Ok(Product);
        }

        [HttpGet]
        [Route("GetPage")]
        public async Task<IActionResult> GetPage(int page = 1, int countReg = 10)
        {
            var listProduct = await _ProductService.GetPage(page, countReg);

            return Ok(listProduct);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Product = await _ProductService.GetProductById(id);
                if (Product == null) return NotFound();

                await _ProductService.DeleteProduct(id);
                return Ok("Produto deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Product Product)
        {
            try
            {
                await _ProductService.CreateProduct(Product);
                return Ok(Product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product Product)
        {
            try
            {
                await _ProductService.UpdateProduct(Product);
                return Ok(Product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("Patch")]
        [HttpPatch]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Product> patchProduct)
        {
            var Product = await _ProductService.GetProductById(id);

            if (Product != null)
                patchProduct.ApplyTo(Product);

            await _ProductService.UpdateProduct(Product);

            return Ok(Product);
        }
    }
}
