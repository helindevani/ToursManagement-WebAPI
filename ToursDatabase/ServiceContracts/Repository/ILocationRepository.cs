using ToursDatabase.DTO;

namespace ToursDatabase.ServiceContracts.Repository
{
    public interface ILocationRepository
    {
        Task<IEnumerable<LocationDTO>> GetAllLocationsAsync();
        Task<LocationDTO> GetLocationByIdAsync(Guid id);
        Task<bool> UpdateLocationAsync(Guid id, LocationDTO locationDTO);
        Task<bool> CreateLocationAsync(LocationDTO locationDTO);
        Task<bool> DeleteLocationAsync(Guid id);
    }
}
