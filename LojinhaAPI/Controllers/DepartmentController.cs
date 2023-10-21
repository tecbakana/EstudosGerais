using LojinhaAPI.Data;
using LojinhaAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DataContext _context;
        public DepartmentController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            return Ok(await _context.Departments.ToListAsync());
            /*return new List<Department>
            {
                new Product { Id = 1,
                Name="IronMan",
                Description="Bone do Iron Man",
                Category=9
                }
            };*/
        }

        [HttpPost]
        public async Task<ActionResult<List<Department>>> CreateProduct(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return Ok(await _context.Departments.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Department>>> UpdateProduct(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return Ok(await _context.Departments.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Department>>> DeleteProduct(Department department)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return Ok(await _context.Departments.ToListAsync());
        }
    }
}
