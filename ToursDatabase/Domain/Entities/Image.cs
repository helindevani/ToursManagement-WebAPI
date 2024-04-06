using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToursDatabase.ServiceContracts;

namespace ToursDatabase.Domain.Entities
{
    public class Image : IAuditable
    {
        [Key]
        public Guid ImageId { get; set; } = Guid.NewGuid();

        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; }
        public long FileSizeInBytes { get; set; }
        public string FilePath { get; set; }

        [ForeignKey("Tour")]
        public Guid TourId { get; set; }
        public Tour? Tour { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
