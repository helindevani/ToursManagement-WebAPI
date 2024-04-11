using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToursDatabase.ServiceContracts.Repository;
using ToursDatabase.DTO;
using ToursDatabase.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ToursDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequest uploadRequest)
        {
            if (!await _imageRepository.ValidateBySignature(uploadRequest.File))
            {
                ModelState.AddModelError("file", "Extension file are not allowed. Please, upload other one");
                return BadRequest(ModelState);
            }

            if (uploadRequest.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "Please upload a file smaller than 10MG");
                return BadRequest(ModelState);
            }

            await _imageRepository.UploadImage(uploadRequest);

            return Ok("Image Upload Successfully");
        }
    }
}
