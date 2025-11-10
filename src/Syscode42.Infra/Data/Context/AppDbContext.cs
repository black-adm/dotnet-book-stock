using Syscode42.Business.Models.Products;
using Syscode42.Business.Models.Suppliers;
using Syscode42.Infra.Data.Mappings;
using System.Data.Entity;

namespace Syscode42.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SupplierConfig());
            modelBuilder.Configurations.Add(new AddressConfig());
            modelBuilder.Configurations.Add(new ProductConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
