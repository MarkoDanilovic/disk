using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);
    }
}