
using ToursDatabase.Domain.Entities;
using ToursDatabase.DTO;

namespace ToursDatabase.ServiceContracts.Repository
{
    public interface IImageRepository
    {
        Task<Image> UploadImage(ImageUploadRequest image);

        Task<bool> ValidateBySignature(IFormFile file);
    }
}
