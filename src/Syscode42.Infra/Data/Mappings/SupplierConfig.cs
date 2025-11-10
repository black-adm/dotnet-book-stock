using System.Data.Entity.Infrastructure.Annotations;
using Syscode42.Business.Models.Suppliers;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syscode42.Infra.Data.Mappings
{
    public class SupplierConfig : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfig()
        {
            HasKey(s => s.Id);

            Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            Property(s => s.Document)
            .IsRequired()
            .HasMaxLength(14)
            .HasColumnAnnotation("Index", 
                new IndexAnnotation(new IndexAttribute{ IsUnique = true }));

            HasRequired(s => s.Address)
                .WithRequiredPrincipal(a => a.Supplier);

            ToTable("Suppliers");
        }
    }
}
