using Microsoft.EntityFrameworkCore;

namespace RentX.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car()
                {
                    Id = Guid.Parse("b55a6ed3-2837-4127-965f-b375af07c3e4"),
                    Name = "Audi A3",
                    Description = @"O Audi A3 Sedan impressiona com o seu 
                        exterior esportivo e elegante. Progresso que se pode sentir.",
                    Daily_Rate = 140,
                    Available = true,
                    LicensePlate = "ABC 123A",
                    FineAmount = 100,
                    Brand = "Audi",
                    CategoryId = Guid.Parse("ef354c3c-1a03-4003-971a-1d2af188d6c2")
                },

                new Car()
                {
                    Id = Guid.Parse("c79dd509-55fc-4b14-86e2-73dd5f98dc26"),
                    Name = "Versa",
                    Description = @"O Nissan Versa Sedan impressiona com o seu 
                        exterior esportivo e elegante. Progresso que se pode sentir.",
                    Daily_Rate = 100,
                    Available = true,
                    LicensePlate = "ABC 123B",
                    FineAmount = 40,
                    Brand = "Nissan",
                    CategoryId = Guid.Parse("381f85b0-9810-4331-a69d-d62733cc20ae")
                },

                new Car()
                {
                    Id = Guid.Parse("6c090713-ff4e-46f2-9e20-f3a49f5ac3bc"),
                    Name = "Corolla",
                    Description = @"O Corolla gli Sedan impressiona com o seu 
                        exterior esportivo e elegante. Progresso que se pode sentir.",
                    Daily_Rate = 200,
                    Available = true,
                    LicensePlate = "ABC 123C",
                    FineAmount = 140,
                    Brand = "Toyota",
                    CategoryId = Guid.Parse("2089f4ab-9007-422e-9c9e-87b583423a4e")
                },

                new Car()
                {
                    Id = Guid.Parse("0defbea5-f8c9-47c5-801b-8d2269001dc0"),
                    Name = "HB20",
                    Description = @"O HB20 Sedan impressiona com o seu 
                        exterior esportivo e elegante. Progresso que se pode sentir.",
                    Daily_Rate = 120,
                    Available = true,
                    LicensePlate = "ABC 123D",
                    FineAmount = 80,
                    Brand = "Hyundai",
                    CategoryId = Guid.Parse("8a435f5f-c880-47e5-85a3-0d0451907aa8")
                }
                );
        }
    }
}
