using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulify.Domain.Entities.Companies;

namespace Schedulify.Infrastructure.Data.Configurations;

internal class CompanyBranchAddressConfig : IEntityTypeConfiguration<CompanyBranchAddress>
{
    public void Configure(EntityTypeBuilder<CompanyBranchAddress> builder)
    {
        builder.ToTable("CompanyBranchAddresses", x => x.IsTemporal());
        builder.HasKey(x => new { x.AddressId, x.CompanyBranchId });

        builder.HasOne(x => x.Address)
            .WithMany(a => a.CompanyBranchAddresses)
            .HasForeignKey(x => x.AddressId);

        builder.HasOne(x => x.CompanyBranch)
            .WithMany(c => c.CompanyBranchAddresses)
            .HasForeignKey(x => x.CompanyBranchId);
    }
}
