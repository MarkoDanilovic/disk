using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        //builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
        builder.HasOne(p => p.Track).WithMany().HasForeignKey(p => p.TrackId);
        //builder.ToTable(tb => tb.HasTrigger("dbo.cartitem_quantity_tr"));
        //builder.HasOne(p => p.Cart).WithMany().HasForeignKey(p => p.CartId);
    }
}