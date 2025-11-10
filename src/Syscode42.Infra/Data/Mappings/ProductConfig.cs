using Syscode42.Business.Models.Products;
using System.Data.Entity.ModelConfiguration;

namespace Syscode42.Infra.Data.Mappings
{
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
           HasKey(p => p.Id);

           Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(200);

            Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(1000);

            Property(p => p.Image)
               .IsRequired()
               .HasMaxLength(100);

            HasRequired(p => p.Supplier)
               .WithMany(s => s.Products)
               .HasForeignKey(p => p.SupplierId);

            ToTable("Products");
        }
    }
}
