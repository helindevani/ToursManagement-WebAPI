using ToursDatabase.Enums;

namespace ToursDatabase.DTO
{
    public class TourDTO
    {
        public Guid TourId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double StartingLatitude { get; set; }
        public double StartingLongitude { get; set; }
        public string StartLocationAddress { get; set; }
        public string StartLocationDescription { get; set; }
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
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; }=DateTime.UtcNow;

    }
}
