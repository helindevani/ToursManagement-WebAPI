namespace ToursDatabase.DTO
{
    public class ReviewDTO
    {
        public Guid ReviewId { get; set; } = Guid.NewGuid();
        public string ReviewDetail { get; set; }
        public double Rating { get; set; }
        public Guid TourId { get; set; }
        public TourDTO? Tour { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; }= DateTime.UtcNow;
    }
}
