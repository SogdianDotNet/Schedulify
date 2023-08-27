using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulify.Infrastructure.Data.Entities.Base;

namespace Schedulify.Infrastructure.Data.Configurations;

internal class BaseEntityConfig : IEntityTypeConfiguration<BaseEntity>
{
    public void Configure(EntityTypeBuilder<BaseEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
