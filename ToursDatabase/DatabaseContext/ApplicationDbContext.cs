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
        public virtual DbSet<Stop> Stops { get; set; }

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
                    LocationId = Guid.Parse("7209F8DF-5D18-4279-A03D-707624FB86BB"),
                    Name = "New York State Building Observatory",
                    Address = "123 Street, City, Country",
                    Latitude = 40.748817,
                    Longitude = -73.985428,
                    Description = "that is second street of place",
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
                    Description = "that is first street of place",
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
                     TourDate = DateTime.UtcNow,
                     TourEndDate = DateTime.UtcNow,
                     Name = "NewYork Tour",
                     StartTourLocation="Ahmedabad",
                     FirstLocation="Delhi",
                     LastLocation="Mumbai",
                     Duration = 7,
                     MaxGroupSize = 20,
                     Difficulty = DifficultyType.Medium,
                     RatingsAverage = 4.5,
                     RatingsQuantity = 50,
                     Price = 100.00,
                     SecretTour = false,
                     Description = "This Is Compelete Trip About Newyork",
                     Id = Guid.Parse("BFA80C03-5E0B-4D76-A802-D8CE6D2C7587"),
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

                modelBuilder.Entity<Stop>().HasData(
                    new Stop
                    {
                        StopId = Guid.NewGuid(),
                        Order = 2,
                        LocationId = Guid.Parse("7209F8DF-5D18-4279-A03D-707624FB86BB"),
                        ArrivalTime = DateTime.Now,
                        DepartureTime = DateTime.Now.AddHours(10),
                    }
                );

        }

    }
}
