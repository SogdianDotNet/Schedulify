using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulify.Domain.Entities.Common;

namespace Schedulify.Infrastructure.Data.Configurations;

internal class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses", x => x.IsTemporal());
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Street).IsRequired().HasMaxLength(100);
        builder.Property(x => x.City).IsRequired().HasMaxLength(100);
        builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(12);
        builder.Property(x => x.HouseNumber).IsRequired();
        builder.Property(x => x.StartDate).IsRequired();
        builder
            .HasOne(x => x.Country)
            .WithMany(x => x.Addresses);
    }
}
