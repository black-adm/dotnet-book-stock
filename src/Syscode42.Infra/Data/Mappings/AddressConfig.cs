using Syscode42.Business.Models.Suppliers;
using System.Data.Entity.ModelConfiguration;

namespace Syscode42.Infra.Data.Mappings
{
    public class AddressConfig : EntityTypeConfiguration<Address>
    {
        public AddressConfig()
        {
            HasKey(a => a.Id);

            Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(200);

            Property(a => a.AddressNumber)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(250)
                .IsFixedLength();

            Property(a => a.Complement)
                .HasMaxLength(250);

            Property(a => a.Neighborhood)
                .IsRequired();

            Property(a => a.City)
                .IsRequired();

            Property(a => a.State)
                .IsRequired();

            ToTable("Addresses");
        }
    }
}
