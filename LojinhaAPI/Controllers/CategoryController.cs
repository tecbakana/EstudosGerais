using LojinhaAPI.Data;
using LojinhaAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private DataContext _context;
        public CategoryController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<ActionResult<Product>> GetCategoryById(string id)
        {
            int idItem = 0;

            if (!string.IsNullOrEmpty(id))
            {
                idItem = int.Parse(id);
            }

            return Ok(await _context.Categories.Where(p => p.Id == idItem).FirstOrDefaultAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category category)
        {
            var dbCategory = await _context.Categories.FindAsync(category.Id);
            if (dbCategory == null)
                return BadRequest("Category not found");

            dbCategory.Name = category.Name;
            dbCategory.Description = category.Description;
            dbCategory.Status = category.Status;

            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(string catId)
        {
            int idItem = 0;

            if (!string.IsNullOrEmpty(catId))
            {
                idItem = int.Parse(catId);
            }

            var dbCategory = await _context.Categories.FindAsync(idItem);
            if (dbCategory == null)
                return BadRequest("Category not found");

            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }
    }
}
