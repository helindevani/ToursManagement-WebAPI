using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToursDatabase.DatabaseContext;
using ToursDatabase.Domain.Entities;
using ToursDatabase.DTO;
using ToursDatabase.Enums;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ITourRepository _tourRepository;

        public ToursController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourDTO>>> GetTours([FromQuery] int? minRating = null, [FromQuery] int? maxRating = null, [FromQuery] string difficultyLevel = null, [FromQuery] string sortBy = null)
        {
            var tours = await _tourRepository.GetToursAsync();

            if (minRating.HasValue)
            {
                tours = tours.Where(t => t.RatingsAverage >= minRating.Value);
            }
            if (maxRating.HasValue)
            {
                tours = tours.Where(t => t.RatingsAverage <= maxRating.Value);
            }
            if (!string.IsNullOrEmpty(difficultyLevel))
            {
                tours = tours.Where(t => t.Difficulty.Equals(difficultyLevel, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "LowToHigh":
                        tours = tours.OrderBy(t => t.Price);
                        break;
                    case "HighToLow":
                        tours = tours.OrderByDescending(t => t.Price);
                        break;
                    default:
                        break;
                }
            }
            return Ok(tours);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourDTO>> GetTour(Guid id)
        {
            var tour = await _tourRepository.GetTourByIdAsync(id);
            if (tour == null)
            {
                return NotFound("Tours Details Not Found");
            }
            return Ok(tour);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(Guid id, TourDTO tourDTO)
        {
            var result = await _tourRepository.UpdateTourAsync(id, tourDTO);
            if (!result)
            {
                return BadRequest("Failed to update tour.");
            }
            return Ok("Data will be updated successfully.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<TourDTO>> PostTour(TourDTO tourDTO)
        {
            var tour = await _tourRepository.AddTourAsync(tourDTO);
            return CreatedAtAction("GetTour", new { id = tour.TourId }, tour);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(Guid id)
        {
            var result = await _tourRepository.DeleteTourAsync(id);
            if (!result)
            {
                return NotFound("Tour not found.");
            }
            return Ok("Tour will be successfully deleted.");
        }

    }
}
