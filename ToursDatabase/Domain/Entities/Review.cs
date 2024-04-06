using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToursDatabase.ServiceContracts;

namespace ToursDatabase.Domain.Entities
{
    public class Review : IAuditable
    {
        [Key]
        public Guid ReviewId { get; set; }= Guid.NewGuid();

        public string ReviewDetail { get; set; }

        [Range(0, 5)] // Assuming ratings are from 0 to 5
        public double Rating { get; set; }

        [ForeignKey("Tour")]
        public Guid TourId { get; set; }

        public Tour? Tour { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
