namespace ToursDatabase.DTO
{
    public class LocationDTO
    {
        public Guid LocationId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid TourId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
