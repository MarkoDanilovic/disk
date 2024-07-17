using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }

    
    
    

    public DbSet<Genre> Genre { get; set; }

    public DbSet<Label> Label { get; set; }

    public DbSet<Medium> Medium { get; set; }

    

    public DbSet<User> User { get; set; }

    public DbSet<Track> Track { get; set; }

    public DbSet<Producer> Producer { get; set; }
    
    public DbSet<Cart> Cart { get; set; }
    
    public DbSet<CartItem> CartItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<CartItem>().ToTable(tb => tb.HasTrigger("dbo.cartitem_quantity_tr"));
        
        modelBuilder.Entity<Producer>().HasData(
            new
            {
                Id = 1,
                Name = "Tim",
                Surname = "Bergling",
                Email = "avicii@gmail.com",
                ArtistName = "Avicii",
                Birthday = new DateTime(1989, 9, 8),
                Country = "Sweden"
            },
            new
            {
                Id = 2,
                Name = "Sebastian",
                Surname = "Ingrosso",
                Email = "sebastianingrosso@gmail.com",
                ArtistName = "Sebastian Ingrosso",
                Birthday = new DateTime(1983, 4, 20),
                Country = "Sweden"
            },
            new
            {
                Id = 3,
                Name = "Amelie",
                Surname = "Lens",
                Email = "lens@gmail.com",
                ArtistName = "Amelie Lens",
                Birthday = new DateTime(1990, 5, 30),
                Country = "Belgium"
            },
            new
            {
                Id = 4,
                Name = "Joris",
                Surname = "Voorn",
                Email = "jorisvoorn@gmail.com",
                ArtistName = "Joris Voorn",
                Birthday = new DateTime(1977, 2, 25),
                Country = "Netherlands"
            }
        );
        modelBuilder.Entity<Label>().HasData(
            new
            {
                Id = 1,
                Name = "Drumcode",
                Country = "Sweden",
                Email = "drumcode@gmail.com"
            },
            new
            {
                Id = 2,
                Name = "LE7ELS",
                Country = "Sweden",
                Email = "le7els@gmail.com"
            }
        );
        modelBuilder.Entity<Medium>().HasData(
            new
            {
                Id = 1,
                MediumName ="Vinyl"
            },
            new
            {
                Id = 2,
                MediumName = "CD"
            },
            new
            {
                Id =3,
                MediumName = "Cassette tape"
            }
        );
        modelBuilder.Entity<Genre>().HasData(
            new
            {
                Id = 1,
                GenreName = "Techno"
            },
            new
            {
                Id = 2,
                GenreName = "EDM"
            }
        );
        modelBuilder.Entity<Track>().HasData(
            new
            {
                Id = 1,
                TrackName = "Your Mind",
                Price = 14.99m,
                Duration = 8.23m,
                PublishDate = new DateTime(2018, 6, 18),
                PictureUrl = "picture",
                GenreId = 1,
                ProducerId = 3,
                LabelId = 1,
                MediumId = 1,
                Quantity = 100
            },
            new
            {
                Id = 2,
                TrackName = "Levels",
                Price = 14.99m,
                Duration = 4.29m,
                PublishDate = new DateTime(2011, 5, 30),
                PictureUrl = "picture",
                GenreId = 2,
                ProducerId = 1,
                LabelId = 2,
                MediumId = 2,
                Quantity = 5
            },
            new
            {
                Id = 3,
                TrackName = "Goodbye fly",
                Price = 14.99m,
                Duration = 6.57m,
                PublishDate = new DateTime(2012, 4, 30),
                PictureUrl = "picture",
                GenreId = 1,
                ProducerId = 4,
                LabelId = 1,
                MediumId = 3,
                Quantity = 25
            },
            new
            {
                Id = 4,
                TrackName = "More than you know",
                Price = 14.99m,
                Duration = 3.23m,
                PublishDate = new DateTime(2017, 6, 7),
                PictureUrl = "picture",
                GenreId = 2,
                ProducerId = 2,
                LabelId = 2,
                MediumId = 2,
                Quantity = 20
            }
        );
        
        
        modelBuilder.Entity<User>().HasData(
            new
            {
                Id = 1,
                Name = "Vitomir",
                Lastname = "Has",
                Email = "has@gmail.com",
                Password = "vitapuska",
                Address = "Adresa 1",
                City = "Novi Sad",
                Username = "Has",
                Telephone = "555333",
                Country = "Serbia",
                Role="User"
            },
            
        new
            {
                Id = 2,
                Name = "Marko" ,
                Lastname ="Danilovic",
                Email = "admin@admin.com",
                Password = "admin",
                Address = "Moja adresa 359",
                City = "Belgrade",
                Username = "markodan",
                Telephone = "553265",
                Country = "Serbia",
                Role = "Admin"
            }
            );

        modelBuilder.Entity<Cart>().HasData(
            new
            {
                Id = 1,
                OrderDate = new DateTime(),
                Subtotal = 14.52M,
                Comment = "",
                Address = "Bulevar umetnosti 16a",
                PaymentMethod = "",
                Payment = false,
                City = "Beograd",
                UserId = 1
            }
            );
        modelBuilder.Entity<CartItem>().HasData(
            new
            {
                Id = 1,
                TrackId = 1,
                CartId = 1,
                Quantity = 1
            }
            );
        
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
} //dotnet ef migrations add "Initial creation" -p Infrastructure -s API -c StoreContext -o Data/Migrations