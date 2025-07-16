using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public class ImagesService : IImagesService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationsDbContext _context;

        public ImagesService(IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor,
            ApplicationsDbContext context)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<Image> Upload(Image image)
        {
            //var localFilePath = Path.Combine(_env.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");

            //// Upload Image to Local Path
            //using var stream = new FileStream(localFilePath, FileMode.Create);
            //await image.File.CopyToAsync(stream);

            //// https://localhost:1234/images/image.jpg

            //var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            //image.FilePath = urlFilePath;

            // Add Image to the Images table
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();

            return image;
        }
    }
}
