using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Lastname).IsRequired();
        builder.Property(p => p.Telephone).IsRequired();
        builder.Property(p => p.Role).IsRequired();
        builder.Property(p => p.Address).IsRequired();
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.Password).IsRequired();
        builder.Property(p => p.City).IsRequired();
        builder.Property(p => p.Country).IsRequired();
    }
}