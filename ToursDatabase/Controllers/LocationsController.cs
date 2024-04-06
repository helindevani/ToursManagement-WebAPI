using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToursDatabase.DTO;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationsController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetLocations()
        {
            var locations = await _locationRepository.GetAllLocationsAsync();
            return Ok(locations);
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> GetLocation(Guid id)
        {
            var location = await _locationRepository.GetLocationByIdAsync(id);

            if (location == null)
            {
                return NotFound("Location Not Found");
            }

            return location;
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(Guid id, LocationDTO locationDTO)
        {
            if (id != locationDTO.LocationId)
            {
                return BadRequest("Invalid Location ID");
            }

            var success = await _locationRepository.UpdateLocationAsync(id, locationDTO);

            if (!success)
            {
                return NotFound("Location not found");
            }

            return Ok("Successfully updated location");
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<ActionResult<LocationDTO>> PostLocation(LocationDTO locationDTO)
        {
            var success = await _locationRepository.CreateLocationAsync(locationDTO);

            if (!success)
            {
                return BadRequest("Unable to create location");
            }

            return CreatedAtAction("GetLocation", new { id = locationDTO.LocationId }, locationDTO);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {
            var success = await _locationRepository.DeleteLocationAsync(id);

            if (!success)
            {
                return NotFound("Location not found");
            }

            return Ok("Location successfully deleted");
        }
    }
}
