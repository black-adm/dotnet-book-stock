using Syscode42.Business.Models.Products;
using Syscode42.Business.Models.Suppliers;
using System.Data.Entity;

namespace Syscode42.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
