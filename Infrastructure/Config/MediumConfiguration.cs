using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class MediumConfig : IEntityTypeConfiguration<Medium>
{
    public void Configure(EntityTypeBuilder<Medium> builder)
    {
        builder.Property(p => p.MediumName).IsRequired().HasMaxLength(25);
        builder.Property(p => p.Id).IsRequired();
    }
}