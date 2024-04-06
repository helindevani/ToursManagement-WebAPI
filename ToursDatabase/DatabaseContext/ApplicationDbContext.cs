using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToursDatabase.Domain.Entities;
using ToursDatabase.Domain.Identity;
using ToursDatabase.Enums;
using ToursDatabase.ServiceContracts;

namespace ToursDatabase.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
            
        }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<TourBooking> TourBookings { get; set; }

        public override int SaveChanges()
        {
            UpdateTimeStamp();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateTimeStamp();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateTimeStamp()
        {
            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IAuditable && (
            e.State == EntityState.Added
            || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((IAuditable)entityEntry.Entity).UpdateDate = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IAuditable)entityEntry.Entity).CreateDate = DateTime.UtcNow;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var AdminId = "7DBD5480-1224-4288-AEE8-1249F8A94E1A";
            var UserId = "3AC53885-3553-4B1C-93D2-4DECA3B4CB54";

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole
                {
                    Id = Guid.Parse(AdminId),
                    ConcurrencyStamp = AdminId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new ApplicationRole
                {
                    Id = Guid.Parse(UserId),
                    ConcurrencyStamp = UserId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            };

            modelBuilder.Entity<ApplicationRole>().HasData(roles);

            //Configure Review-Tour relationship
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Tour)
                .WithMany(t => t.Reviews)
                .HasForeignKey(r => r.TourId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Location-Tour relationship
            modelBuilder.Entity<Location>()
                .HasOne(l => l.Tour)
                .WithMany(t => t.Locations)
                .HasForeignKey(l => l.TourId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TourBooking>()
               .HasOne(r => r.Tour)
               .WithMany()
               .HasForeignKey(r => r.TourId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Image>()
               .HasOne(r => r.Tour)
               .WithMany(i => i.Images)
               .HasForeignKey(r => r.TourId)
               .OnDelete(DeleteBehavior.Cascade);

            // Seed data for Review
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ReviewId = Guid.NewGuid(),
                    ReviewDetail = "Great tour!",
                    Rating = 4.5,
                    TourId = Guid.Parse("9C0CF771-2A31-44C9-ADFD-B08C30397392"),
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                },
                new Review
                {
                    ReviewId = Guid.NewGuid(),
                    ReviewDetail = "Amazing experience!",
                    Rating = 5.0,
                    TourId = Guid.Parse("9C0CF771-2A31-44C9-ADFD-B08C30397392"),
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                }
            );

            //Seed data for Location

            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Empire State Building Observatory",
                    Address = "123 Street, City, Country",
                    Latitude = 40.748817,
                    Longitude = -73.985428,
                    TourId = Guid.Parse("9C0CF771-2A31-44C9-ADFD-B08C30397392"),
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,

                },
                new Location
                {
                    LocationId = Guid.NewGuid(),
                    Name = "NYC Cruise by Circle Line",
                    Address = "456 Road, City, Country",
                    Latitude = 40.7128,
                    Longitude = -74.0060,
                    TourId = Guid.Parse("9C0CF771-2A31-44C9-ADFD-B08C30397392"),
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,

                }
            );

            // Seed data for Tour
            modelBuilder.Entity<Tour>().HasData(
                 new Tour()
                 {
                     TourId = Guid.Parse("9C0CF771-2A31-44C9-ADFD-B08C30397392"),
                     Name = "NewYork Tour",
                     StartingLatitude = 40.7128,
                     StartingLongitude = -74.0060,
                     StartLocationAddress = "123 Main St, New York, NY",
                     StartLocationDescription = "This is the starting point of the tour.",
                     Duration = 7,
                     MaxGroupSize = 20,
                     Difficulty = DifficultyType.Medium,
                     RatingsAverage = 4.5,
                     RatingsQuantity = 50,
                     Price = 100.00,
                     Description = "This is a sample tour description.",
                     SecretTour = false,
                     CreateDate = DateTime.Now,
                     UpdateDate = DateTime.Now,

                 }
            );

            modelBuilder.Entity<TourBooking>().HasData(
                new TourBooking
                {
                    BookingID = Guid.Parse("CE12BFBD-465E-43A5-8576-65D5F1FE1E16"),
                    CustomerName = "John Doe",
                    CustomerEmail = "john@example.com",
                    BookingDate = DateTime.Now,
                    TourDate = DateTime.Now.AddDays(7),
                    TourId = Guid.Parse("9C0CF771-2A31-44C9-ADFD-B08C30397392"),
                    Status = BookingStatus.Confirmed,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,

                }
            );

            modelBuilder.Entity<Image>().HasData(
                    new Image
                    {
                        ImageId = Guid.NewGuid(),
                        FileName = "example.jpg",
                        FileDescription = "An example image",
                        FileExtension = ".jpg",
                        FileSizeInBytes = 1024,
                        FilePath = "/Images/example.jpg",
                        TourId = Guid.Parse("9C0CF771-2A31-44C9-ADFD-B08C30397392"),
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                    }
                );

        }

    }
}
