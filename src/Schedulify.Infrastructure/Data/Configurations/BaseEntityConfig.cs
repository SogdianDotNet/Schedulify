using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulify.Domain.Entities.Base;

namespace Schedulify.Infrastructure.Data.Configurations;

internal class BaseEntityConfig : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
