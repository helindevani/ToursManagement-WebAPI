using Microsoft.EntityFrameworkCore;
using ToursDatabase.DatabaseContext;
using ToursDatabase.Domain.Entities;
using ToursDatabase.DTO;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Services.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LocationDTO>> GetAllLocationsAsync()
        {
            var locations = await _context.Locations.Include(s=>s.Stops).Include(t => t.Tour).ToListAsync();

            return locations.Select(location => new LocationDTO
            {
                LocationId = location.LocationId,
                Name = location.Name,
                Address = location.Address,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Description = location.Description,
                Stops = location.Stops,
                TourId = location.TourId,
                CreateDate = location.CreateDate,
                UpdateDate = location.UpdateDate,
            });
        }

        public async Task<LocationDTO> GetLocationByIdAsync(Guid id)
        {
            var location = await _context.Locations.Include(t => t.Tour).FirstOrDefaultAsync(i => i.LocationId == id);

            if (location == null)
            {
                return null;
            }

            return new LocationDTO
            {
                LocationId = location.LocationId,
                Name = location.Name,
                Address = location.Address,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                TourId = location.TourId,
                CreateDate = location.CreateDate,
                UpdateDate = location.UpdateDate,
            };
        }

        public async Task<bool> UpdateLocationAsync(Guid id, LocationDTO locationDTO)
        {
            var existingLocation = await _context.Locations.FindAsync(id);

            if (existingLocation == null)
            {
                return false;
            }

            existingLocation.Name = locationDTO.Name;
            existingLocation.Address = locationDTO.Address;
            existingLocation.Latitude = locationDTO.Latitude;
            existingLocation.Longitude = locationDTO.Longitude;
            existingLocation.Description = locationDTO.Description;
            existingLocation.TourId = locationDTO.TourId;
            existingLocation.UpdateDate = locationDTO.UpdateDate;
            existingLocation.Stops = locationDTO.Stops?.Select(stop => new Stop
            {
                StopId = stop.StopId,
                ArrivalTime = stop.ArrivalTime,
                DepartureTime = stop.DepartureTime,
                LocationId = locationDTO.LocationId,
                Order = stop.Order
            }).ToList();

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateLocationAsync(LocationDTO locationDTO)
        {
            var location = new Location
            {
                LocationId = locationDTO.LocationId,
                Name = locationDTO.Name,
                Address = locationDTO.Address,
                Latitude = locationDTO.Latitude,
                Longitude = locationDTO.Longitude,
                TourId = locationDTO.TourId,
                CreateDate = locationDTO.CreateDate,
                UpdateDate = locationDTO.UpdateDate,
                Description=locationDTO.Description,
                Stops = locationDTO.Stops?.Select(stop => new Stop
                {
                    StopId=stop.StopId,
                    ArrivalTime=stop.ArrivalTime,
                    DepartureTime=stop.DepartureTime,
                    LocationId=locationDTO.LocationId,
                    Order=stop.Order
                }).ToList()
            };

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteLocationAsync(Guid id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return false;
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
