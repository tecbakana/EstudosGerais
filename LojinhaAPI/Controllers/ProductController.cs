using LojinhaAPI.Data;
using LojinhaAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private DataContext _context;
        public ProductController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _context.Products.ToListAsync());
            /*return new List<Product>
            {
                new Product { Id = 1,
                Name="IronMan",
                Description="Bone do Iron Man",
                Category=9
                }
            };*/
        }

        [HttpGet]
        [Route("GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            int idItem = 0;

            if(!string.IsNullOrEmpty(id))
            {
                idItem = int.Parse(id);
            }

            return Ok( await _context.Products.Where(p=>p.Id==idItem).FirstOrDefaultAsync());
        }
     
        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var dbProduct =await _context.Products.FindAsync(product.Id);
            if (dbProduct == null)
                return BadRequest("Product not found");

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Category = product.Category;
            dbProduct.productGender = product.productGender;

            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(string prodId)
        {
            int idItem = 0;

            if (!string.IsNullOrEmpty(prodId))
            {
                idItem = int.Parse(prodId);
            }

            var dbProduct = await _context.Products.FindAsync(idItem);
            if (dbProduct == null)
                return BadRequest("Product not found");

            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }
    }
}
