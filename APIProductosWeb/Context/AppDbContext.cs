using APIProductosWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProductosWeb.Context
{
    public class AppDbContext:DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {



            
        }

        public DbSet<Products_DB> Products { get; set;}
        public DbSet<Categories_DB> Categories { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }


    }
}
