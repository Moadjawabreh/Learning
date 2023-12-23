using Learning.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Categ> categs { get; set; } // table name "categs"

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categ>().HasData(
                new Categ { Id = 1, Description = "asxsa", Name = "saxx " },
                new Categ { Id = 2, Description = "asdc dx c ", Name = "sdaew"},
				new Categ { Id = 4, Description = "asdc dx c ", Name = "sdaew" },
				new Categ { Id = 3, Description = "asdc dx c ", Name = "sdaew" }
				);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Title = "Hi",
                Description = "Hi",
                ListPrice = 90,
                CategId = 2,
                imageUrl=""
            });
        }


    }

}
