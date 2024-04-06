using System.ComponentModel.DataAnnotations;

namespace ToursDatabase.DTO
{
    public class ImageUploadRequest
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }

        public Guid TourId { get; set; }
    }
}
