using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToursDatabase.Enums;
using ToursDatabase.ServiceContracts;

namespace ToursDatabase.Domain.Entities
{
    public class TourBooking : IAuditable
    {
        [Key]
        public Guid BookingID { get; set; } = Guid.NewGuid();
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public DateTime TourDate { get; set; } = DateTime.Now.AddDays(7);

        [ForeignKey("Tour")]
        public Guid TourId { get; set; } 
        public Tour? Tour { get; set; } 
        public BookingStatus Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
