using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToursDatabase.Domain.Entities;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class TourBookingsController : ControllerBase
    {
        private readonly ITourBookingRepository _tourBookingRepository;

        public TourBookingsController(ITourBookingRepository tourBookingRepository)
        {
            _tourBookingRepository = tourBookingRepository;
        }

        // GET: api/TourBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourBooking>>> GetTourBookings([FromQuery] string nameFilter = null)
        {
            var tourBookings = await _tourBookingRepository.GetAllTourBookings();

            if (!string.IsNullOrEmpty(nameFilter))
            {
                tourBookings = tourBookings.Where(booking => booking.CustomerName.Contains(nameFilter, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(tourBookings);
        }

        // GET: api/TourBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourBooking>> GetTourBooking(Guid id)
        {
            var tourBooking = await _tourBookingRepository.GetTourBooking(id);

            if (tourBooking == null)
            {
                return NotFound(" your tourBooking Not Found");
            }

            return tourBooking;
        }

        // PUT: api/TourBookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourBooking(Guid id, TourBooking tourBooking)
        {
            if (id != tourBooking.BookingID)
            {
                return BadRequest("Booking Id Is Not Founded");
            }

            await _tourBookingRepository.UpdateTourBooking(tourBooking);

            return Ok("Your Booking Details Updated Successfully");
        }

        // POST: api/TourBookings
        [HttpPost]
        public async Task<ActionResult<TourBooking>> PostTourBooking(TourBooking tourBooking)
        {
            var createdTourBooking = await _tourBookingRepository.CreateTourBooking(tourBooking);
            return CreatedAtAction(nameof(GetTourBooking), new { id = createdTourBooking.BookingID }, createdTourBooking);
        }

        // DELETE: api/TourBookings/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTourBooking(Guid id)
        {
            await _tourBookingRepository.DeleteTourBooking(id);
            return Ok("Booking Deleted Successfully");
        }
    }
}
