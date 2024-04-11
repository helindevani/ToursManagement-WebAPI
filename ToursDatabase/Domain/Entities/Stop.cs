using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToursDatabase.Domain.Entities
{
    public class Stop
    {
        [Key]
        public Guid StopId { get; set; } = Guid.NewGuid();

        public int Order {  get; set; }

        [ForeignKey("Location")]
        public Guid LocationId { get; set; } = Guid.NewGuid();

        [JsonIgnore]
        public Location? Location { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
