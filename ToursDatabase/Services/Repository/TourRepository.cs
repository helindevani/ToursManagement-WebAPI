using Microsoft.EntityFrameworkCore;
using ToursDatabase.DatabaseContext;
using ToursDatabase.Domain.Entities;
using ToursDatabase.DTO;
using ToursDatabase.Enums;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Services.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationDbContext _context;

        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TourDTO>> GetToursAsync()
        {
            var tours = await _context.Tours
                .Include(i=>i.Images)
                .Include(t => t.Locations)
                .ToListAsync();


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

            var tour = new Tour
            {
                TourId = tourDTO.TourId,
                Name = tourDTO.Name,
                StartingLatitude = tourDTO.StartingLatitude,
                StartingLongitude = tourDTO.StartingLongitude,
                StartLocationAddress = tourDTO.StartLocationAddress,
                StartLocationDescription = tourDTO.StartLocationDescription,
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
                    CreateDate = location.CreateDate,
                    UpdateDate = location.UpdateDate
                }).ToList()
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

            existingTour.Name = tourDTO.Name;
            existingTour.StartingLatitude = tourDTO.StartingLatitude;
            existingTour.StartingLongitude = tourDTO.StartingLongitude;
            existingTour.StartLocationAddress = tourDTO.StartLocationAddress;
            existingTour.StartLocationDescription = tourDTO.StartLocationDescription;
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

            var ratingsAverage = reviews.Any() ? reviews.Average(r => r.Rating) : (double?)null;
            var ratingsQuantity = reviews.Count;

            return new TourDTO
            {
                TourId = tour.TourId,
                Name = tour.Name,
                StartingLatitude = tour.StartingLatitude,
                StartingLongitude = tour.StartingLongitude,
                StartLocationAddress = tour.StartLocationAddress,
                StartLocationDescription = tour.StartLocationDescription,
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
                }).ToList(),
            };
        }
    }
}
