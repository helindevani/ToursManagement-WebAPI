using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ToursDatabase.ServiceContracts;

namespace ToursDatabase.Domain.Entities
{
    public class Location:IAuditable
    {
        [Key]
        public Guid LocationId { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [ForeignKey("Tour")]
        public Guid TourId { get; set; }

        [JsonIgnore]
        public Tour? Tour { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;

    }
}
