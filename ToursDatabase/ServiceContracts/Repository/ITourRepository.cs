using ToursDatabase.Domain.Entities;
using ToursDatabase.DTO;

namespace ToursDatabase.ServiceContracts.Repository
{
    public interface ITourRepository
    {
        Task<IEnumerable<TourDTO>> GetToursAsync();
        Task<TourDTO> GetTourByIdAsync(Guid id);
        Task<TourDTO> AddTourAsync(TourDTO tourDTO);
        Task<bool> UpdateTourAsync(Guid id, TourDTO tourDTO);
        Task<bool> DeleteTourAsync(Guid id);
    }
}
