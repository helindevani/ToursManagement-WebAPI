using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToursDatabase.DTO;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewsController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviews()
        {
            var reviews = await _reviewRepository.GetAllReviewsAsync();
            return Ok(reviews);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReview(Guid id)
        {
            var review = await _reviewRepository.GetReviewByIdAsync(id);

            if (review == null)
            {
                return NotFound("Review not Found");
            }

            return review;
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(Guid id, ReviewDTO reviewDTO)
        {
            if (id != reviewDTO.ReviewId)
            {
                return BadRequest("Please Provide Valid Review");
            }

            var success = await _reviewRepository.UpdateReviewAsync(id, reviewDTO);

            if (!success)
            {
                return NotFound("Review not found");
            }

            return Ok("Update Data Successfully");
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<ReviewDTO>> PostReview(ReviewDTO reviewDTO)
        {
            var success = await _reviewRepository.CreateReviewAsync(reviewDTO);

            if (!success)
            {
                return BadRequest("Unable to create review");
            }

            return CreatedAtAction("GetReview", new { id = reviewDTO.ReviewId }, reviewDTO);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            var success = await _reviewRepository.DeleteReviewAsync(id);

            if (!success)
            {
                return NotFound("Review Was Not Found");
            }

            return Ok("Data Was Successfully deleted");
        }
    }
}
