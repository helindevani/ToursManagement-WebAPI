
using ToursDatabase.Domain.Entities;

namespace ToursDatabase.ServiceContracts.Repository
{
    public interface IImageRepository
    {
        Task<Image> UploadImage(Image image);
    }
}
