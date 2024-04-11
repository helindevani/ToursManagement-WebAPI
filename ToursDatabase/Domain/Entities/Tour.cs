using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToursDatabase.Domain.Identity;
using ToursDatabase.Enums;
using ToursDatabase.ServiceContracts;

namespace ToursDatabase.Domain.Entities
{
    public class Tour : IAuditable
    {
        [Key]
        public Guid TourId { get; set; }  = Guid.NewGuid();

        [Required]
        public DateTime TourDate { get; set; }

        [Required]
        public DateTime? TourEndDate { get; set; }

        [Required]
        public string Name { get; set; }

        public string StartTourLocation {  get; set; }
        public string? FirstLocation { get; set; }

        public string? LastLocation { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Duration { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int MaxGroupSize { get; set; }

        public DifficultyType Difficulty { get; set; }

        [Range(0, 5)]
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
        public List<Stop>? Stops { get; set; }
        public double DurationWeeks => Duration / 7.0;

        [ForeignKey("AspNetUsers")]
        public Guid? Id { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;

    }
}
