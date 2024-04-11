using Microsoft.EntityFrameworkCore;
using ToursDatabase.DatabaseContext;
using ToursDatabase.Domain.Entities;
using ToursDatabase.DTO;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Services.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync()
        {
            var reviews = await _context.Reviews.Include(r => r.Tour).ToListAsync();

            var reviewDTOs = reviews.Select(review => new ReviewDTO
            {
                ReviewId = review.ReviewId,
                ReviewDetail = review.ReviewDetail,
                Rating = review.Rating,
                TourId = review.TourId,
                CreateDate = review.CreateDate,
                UpdateDate = review.UpdateDate,
            });

            return reviewDTOs;
        }

        public async Task<ReviewDTO> GetReviewByIdAsync(Guid id)
        {
            var review = await _context.Reviews
                .Include(t => t.Tour)
                .Include(l => l.Tour.Locations)
                .FirstOrDefaultAsync(i => i.ReviewId == id);

            if (review == null)
            {
                return null;
            }

            var reviewDTO = new ReviewDTO
            {
                ReviewId = review.ReviewId,
                ReviewDetail = review.ReviewDetail,
                Rating = review.Rating,
                TourId = review.TourId,
                Tour = new TourDTO
                {
                    TourId = review.Tour.TourId,
                    Name = review.Tour.Name,
                    Duration = review.Tour.Duration,
                    MaxGroupSize = review.Tour.MaxGroupSize,
                    Difficulty = review.Tour.Difficulty.ToString(),
                    RatingsAverage = review.Tour.RatingsAverage,
                    RatingsQuantity = review.Tour.RatingsQuantity,
                    Price = review.Tour.Price,
                    Description = review.Tour.Description,
                    SecretTour = review.Tour.SecretTour,
                    CreateDate = review.Tour.CreateDate,
                    UpdateDate = review.Tour.UpdateDate,
                    Locations = review.Tour.Locations?.Select(location => new LocationDTO
                    {
                        LocationId = location.LocationId,
                        Name = location.Name,
                        Address = location.Address,
                        Latitude = location.Latitude,
                        Longitude = location.Longitude,
                        TourId = location.TourId,
                        CreateDate = location.CreateDate,
                        UpdateDate = location.UpdateDate,
                    }).ToList()
                },
                CreateDate = review.CreateDate,
                UpdateDate = review.UpdateDate,
            };

            return reviewDTO;
        }

        public async Task<bool> UpdateReviewAsync(Guid id, ReviewDTO reviewDTO)
        {
            var existingReview = await _context.Reviews.FindAsync(id);

            if (existingReview == null)
            {
                return false;
            }

            existingReview.ReviewDetail = reviewDTO.ReviewDetail;
            existingReview.Rating = reviewDTO.Rating;
            existingReview.TourId = reviewDTO.TourId;
            existingReview.UpdateDate = reviewDTO.UpdateDate;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateReviewAsync(ReviewDTO reviewDTO)
        {
            var review = new Review
            {
                ReviewId = reviewDTO.ReviewId,
                ReviewDetail = reviewDTO.ReviewDetail,
                Rating = reviewDTO.Rating,
                TourId = reviewDTO.TourId,
                CreateDate = reviewDTO.CreateDate,
                UpdateDate = reviewDTO.UpdateDate,
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteReviewAsync(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
