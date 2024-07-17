using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class LabelConfig : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Country).IsRequired().HasMaxLength(30);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
    }
}