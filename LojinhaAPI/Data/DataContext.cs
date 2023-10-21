using LojinhaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LojinhaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();

        public DbSet<Category> Categories => Set < Category>();
        public DbSet<Department> Departments => Set<Department>();
    }
}
