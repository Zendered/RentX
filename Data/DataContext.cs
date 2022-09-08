using Microsoft.EntityFrameworkCore;
using RentX.Models;

namespace RentX.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
