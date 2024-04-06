using System.ComponentModel.DataAnnotations;
using ToursDatabase.Enums;
using ToursDatabase.ServiceContracts;

namespace ToursDatabase.Domain.Entities
{
    public class Tour : IAuditable
    {
        [Key]
        public Guid TourId { get; set; }  = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        // Coordinates should be stored as a custom class or structure
        [Required]
        public double StartingLatitude { get; set; }

        [Required]
        public double StartingLongitude { get; set; }

        public string StartLocationAddress { get; set; }
        public string StartLocationDescription { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Duration { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int MaxGroupSize { get; set; }

        public DifficultyType Difficulty { get; set; }

        [Range(0, 5)] // Assuming ratings are from 0 to 5
        public double? RatingsAverage { get; set; }

        public int? RatingsQuantity { get; set; }
        public List<Review>? Reviews { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public string Description { get; set; }
        public List<Image>? Images { get; set; }
        public bool SecretTour { get; set; }
        public List<Location> Locations { get; set; }
        public double DurationWeeks => Duration / 7.0;

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
