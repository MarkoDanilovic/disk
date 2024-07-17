using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class ProducerConfig : IEntityTypeConfiguration<Producer>
{
    public void Configure(EntityTypeBuilder<Producer> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.ArtistName).IsRequired().HasMaxLength(40);
        builder.Property(p => p.Surname).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Country).IsRequired().HasMaxLength(30);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Birthday).IsRequired();

    }
}