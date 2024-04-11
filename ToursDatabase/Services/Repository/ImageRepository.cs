using ToursDatabase.DatabaseContext;
using ToursDatabase.Domain.Entities;
using ToursDatabase.DTO;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Services.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDbContext _DbContext;

        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor, ApplicationDbContext DbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
            _DbContext = DbContext;
        }

        public async Task<Image> UploadImage(ImageUploadRequest uploadRequest)
        {
            var image = new Image
            {
                File = uploadRequest.File,
                FileDescription = uploadRequest.FileDescription,
                FileExtension = Path.GetExtension(uploadRequest.File.FileName),
                FileSizeInBytes = uploadRequest.File.Length,
                FileName = uploadRequest.File.FileName,
                TourId = uploadRequest.TourId
            };
            string uniqueString = Guid.NewGuid().ToString() + image.File.FileName;

            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", uniqueString);

            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlFilePath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.PathBase}/Images/{uniqueString}";

            image.FilePath = urlFilePath;

            await _DbContext.Images.AddAsync(image);
            await _DbContext.SaveChangesAsync();

            return image;
        }

        public async Task<bool> ValidateBySignature(IFormFile file)
        {
            Dictionary<string, List<byte[]>> _fileSignature = new Dictionary<string, List<byte[]>>
            {
                {".jpg", new List<byte[]>
                {
                     new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                     new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                     new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
                }
                },

                {".png", new List<byte[]>
                {
                    new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }
                }
                },

                {".jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 }
                }
                }
            };

            foreach (string exts in _fileSignature.Keys)
            {
                using (var reader = new BinaryReader(file.OpenReadStream()))
                {
                    var signatures = _fileSignature[exts];
                    var readerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

                    if (signatures.Any(signature => readerBytes.Take(signature.Length).SequenceEqual(signature)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
