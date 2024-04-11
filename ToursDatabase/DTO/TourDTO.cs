using ToursDatabase.Domain.Entities;
using ToursDatabase.Enums;

namespace ToursDatabase.DTO
{
    public class TourDTO
    {
        public Guid TourId { get; set; } = Guid.NewGuid();
        public DateTime TourDate { get; set; }
        public DateTime? TourEndDate { get; set; }
        public string Name { get; set; }
        public string StartTourLocation { get; set; }
        public string? FirstLocation { get; set; }
        public string? LastLocation { get; set; }
        public List<string>? StopDetails { get; set; }
        public int Duration { get; set; }
        public int MaxGroupSize { get; set; }
        public string Difficulty { get; set; }
        public double? RatingsAverage { get; set; }
        public int? RatingsQuantity { get; set; }
        public List<ReviewDTO>? Reviews { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<ImageDTO>? Images { get; set; }
        public bool SecretTour { get; set; }
        public List<LocationDTO>? Locations { get; set; }
        public double DurationWeeks => Duration / 7.0;
        public List<Stop>? Stops { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; }=DateTime.UtcNow;

    }
}
