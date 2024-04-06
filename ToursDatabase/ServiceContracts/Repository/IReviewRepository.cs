using ToursDatabase.Domain.Entities;
using ToursDatabase.DTO;

namespace ToursDatabase.ServiceContracts.Repository
{
    public interface IReviewRepository
    {
        Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync();
        Task<ReviewDTO> GetReviewByIdAsync(Guid id);
        Task<bool> UpdateReviewAsync(Guid id, ReviewDTO reviewDTO);
        Task<bool> CreateReviewAsync(ReviewDTO reviewDTO);
        Task<bool> DeleteReviewAsync(Guid id);
    }
}
