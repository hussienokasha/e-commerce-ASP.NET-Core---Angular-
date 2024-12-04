
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IGenericRepository<Product> repo)  : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var products = await repo.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            if (!ProductExist(id))
            {
                return NotFound("product not found");
            }
            var product = await repo.GetById(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> AddAsync(Product product)
        {
            repo.Add(product);
            if (await repo.SaveChangesAsync())
            {
                return Ok("New Product Added");
            }
            return BadRequest("Failed to add product");
        }
        [HttpPut]
        public async Task<ActionResult> Update(int id, Product product)
        {
            if (!ProductExist(id))
            {
                return BadRequest($"product with id {id} not exist");
            }
            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            repo.Update(product);
            return Ok("product updated");
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (!ProductExist(id))
            {
                return NotFound("product not exist");
            }
            var product = await repo.GetById(id);
            repo.Delete(product!);
            if (await repo.SaveChangesAsync())
                return Ok("product deleted");
            return BadRequest("Failed to delete product");
        }

        private bool ProductExist(int id)
        {
            return repo.IsExist(id);
        }
    }
}
