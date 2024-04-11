using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ToursDatabase.DatabaseContext;
using ToursDatabase.Domain.Entities;
using ToursDatabase.Domain.Identity;
using ToursDatabase.DTO;
using ToursDatabase.Enums;
using ToursDatabase.Migrations;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Services.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TourRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<TourDTO>> GetToursAsync(int? minRating, int? maxRating, string difficultyLevel, string sortBy, DateTime? startDate)
        {
            var tours = await _context.Tours
                .Include(i => i.Images)
                .Include(t => t.Locations)
                .ThenInclude(s=>s.Stops)
                .ToListAsync();

            if (startDate != null)
            {
                tours = (List<Tour>)tours.Where(t => t.TourDate >= startDate);
            }

            if (minRating != null)
            {
                tours = (List<Tour>)tours.Where(t => t.RatingsAverage >= minRating);
            }
            if (maxRating != null)
            {
                tours = (List<Tour>)tours.Where(t => (t.RatingsAverage <= maxRating));
            }
            if (!string.IsNullOrEmpty(difficultyLevel))
            {
                tours = tours.Where(t => string.Equals(t.Difficulty.ToString(), difficultyLevel, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "LowToHigh":
                        tours = (List<Tour>)tours.OrderBy(t => t.Price);
                        break;
                    case "HighToLow":
                        tours = (List<Tour>)tours.OrderByDescending(t => t.Price);
                        break;
                    default:
                        break;
                }
            }

            var tourDTOs = new List<TourDTO>();

            foreach (var tour in tours)
            {
                var tourDTO = await MapTourToDTO(tour);
                tourDTOs.Add(tourDTO);
            }

            return tourDTOs;
        }

        public async Task<TourDTO> GetTourByIdAsync(Guid id)
        {
            Tour tour = await _context.Tours
                .Include(i => i.Images)
                .Include(t => t.Locations)
                .FirstOrDefaultAsync(t => t.TourId == id);

            if (tour == null)
                return null;

            return await MapTourToDTO(tour);
        }

        public async Task<TourDTO> AddTourAsync(TourDTO tourDTO)
        {
            if (!Enum.TryParse(tourDTO.Difficulty, true, out DifficultyType difficulty))
            {
                throw new ArgumentException("Invalid difficulty value.");
            }
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var tour = new Tour
            {
                TourId = tourDTO.TourId,
                TourDate = tourDTO.TourDate,
                TourEndDate = tourDTO.TourEndDate,
                Name = tourDTO.Name,
                StartTourLocation = tourDTO.StartTourLocation,
                FirstLocation = tourDTO.FirstLocation,
                LastLocation = tourDTO.LastLocation,
                Duration = tourDTO.Duration,
                MaxGroupSize = tourDTO.MaxGroupSize,
                Difficulty = difficulty,
                RatingsAverage = tourDTO.RatingsAverage,
                RatingsQuantity = tourDTO.RatingsQuantity,
                Price = tourDTO.Price,
                Description = tourDTO.Description,
                SecretTour = tourDTO.SecretTour,
                CreateDate = tourDTO.CreateDate,
                UpdateDate = tourDTO.UpdateDate,
                Locations = tourDTO.Locations?.Select(location => new Location
                {
                    LocationId = location.LocationId,
                    Name = location.Name,
                    Address = location.Address,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    TourId = tourDTO.TourId,
                    Description = location.Description,
                    CreateDate = location.CreateDate,
                    UpdateDate = location.UpdateDate,
                    Stops = location.Stops?.Select(stop => new Stop
                    {
                        StopId = stop.StopId,
                        ArrivalTime = stop.ArrivalTime,
                        DepartureTime = stop.DepartureTime,
                        LocationId = location.LocationId,
                        Order = stop.Order
                    }).ToList()
                }).ToList(),
                Id = userId != null ? Guid.Parse(userId) : (Guid?)null
            };

            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();

            return await MapTourToDTO(tour);
        }

        public async Task<bool> UpdateTourAsync(Guid id, TourDTO tourDTO)
        {
            if (id != tourDTO.TourId)
                return false;

            var existingTour = await _context.Tours.FindAsync(id);

            if (existingTour == null)
                return false;

            existingTour.TourDate = tourDTO.TourDate;
            existingTour.TourEndDate = tourDTO.TourEndDate;
            existingTour.StartTourLocation = tourDTO.StartTourLocation;
            existingTour.FirstLocation = tourDTO.FirstLocation;
            existingTour.LastLocation = tourDTO.LastLocation;
            existingTour.Name = tourDTO.Name;
            existingTour.Duration = tourDTO.Duration;
            existingTour.MaxGroupSize = tourDTO.MaxGroupSize;
            existingTour.Difficulty = Enum.Parse<DifficultyType>(tourDTO.Difficulty);
            existingTour.RatingsAverage = tourDTO.RatingsAverage;
            existingTour.RatingsQuantity = tourDTO.RatingsQuantity;
            existingTour.Price = tourDTO.Price;
            existingTour.Description = tourDTO.Description;
            existingTour.SecretTour = tourDTO.SecretTour;
            existingTour.UpdateDate = tourDTO.UpdateDate;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteTourAsync(Guid id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
                return false;

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<TourDTO> MapTourToDTO(Tour tour)
        {
            var reviews = await _context.Reviews
                .Where(r => r.TourId == tour.TourId)
                .ToListAsync();

            var firstLocation = await _context.Locations
                .Where(location => location.TourId == tour.TourId)
                .SelectMany(location => location.Stops)
                .OrderBy(stop => stop.Order)
                .Select(stop => stop.Location.Name)
                .FirstOrDefaultAsync();

            var lastLocation = await _context.Locations
                .Where(location => location.TourId == tour.TourId)
                .SelectMany(location => location.Stops)
                .OrderByDescending(stop => stop.Order)
                .Select(stop => stop.Location.Name)
                .FirstOrDefaultAsync();

            var createdperson= _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);


            var ratingsAverage = reviews.Any() ? reviews.Average(r => r.Rating) : (double?)null;
            var ratingsQuantity = reviews.Count;

            return new TourDTO
            {
                TourId = tour.TourId,
                TourDate=tour.TourDate,
                TourEndDate= tour.TourEndDate,
                StartTourLocation= tour.StartTourLocation,
                FirstLocation= firstLocation,
                LastLocation= lastLocation,
                Name = tour.Name,
                Duration = tour.Duration,
                MaxGroupSize = tour.MaxGroupSize,
                Difficulty = tour.Difficulty.ToString(),
                RatingsAverage = ratingsAverage,
                RatingsQuantity = ratingsQuantity,
                Price = tour.Price,
                Description = tour.Description,
                SecretTour = tour.SecretTour,
                CreateDate = tour.CreateDate,
                UpdateDate = tour.UpdateDate,
                Images = tour.Images?.Select(image => new ImageDTO
                {
                    FileName = image.FilePath,
                    FileDescription = image.FileDescription,

                }).ToList(),
                Locations = tour.Locations?.Select(location => new LocationDTO
                {
                    LocationId = location.LocationId,
                    Name = location.Name,
                    Address = location.Address,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    TourId = tour.TourId,
                    Stops = location.Stops?.Select(stop => new Stop
                    {
                        StopId = stop.StopId,
                        ArrivalTime = stop.ArrivalTime,
                        DepartureTime = stop.DepartureTime,
                        LocationId = location.LocationId,
                        Order = stop.Order
                    }).ToList()
                }).ToList(),
                CreatedBy=createdperson
            };
        }
    }
}
