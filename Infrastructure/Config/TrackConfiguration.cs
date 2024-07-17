using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class TrackConfiguration : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.Property(p => p.Id).IsRequired().UseIdentityColumn();
        builder.Property(p => p.PictureUrl).IsRequired();
        builder.Property(p => p.TrackName).IsRequired().HasMaxLength(50);
        builder.HasOne(p => p.Producer).WithMany().HasForeignKey(p => p.ProducerId);
        builder.HasOne(p => p.Label).WithMany().HasForeignKey(p => p.LabelId);
        builder.HasOne(p => p.Genre).WithMany().HasForeignKey(p => p.GenreId);
        builder.Property(p => p.PublishDate).IsRequired();
        builder.Property(p => p.Duration).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.Quantity).IsRequired();
        builder.HasOne(p => p.Medium).WithMany().HasForeignKey(p => p.MediumId);
       
    }
}