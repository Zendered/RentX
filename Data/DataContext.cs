using Microsoft.EntityFrameworkCore;

namespace RentX.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Specification> Specifications { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
