﻿using ToursDatabase.DatabaseContext;
using ToursDatabase.Domain.Entities;
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

        public async Task<Image> UploadImage(Image image)
        {
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
    }
}
