namespace MaquetteForAnaqsup.API.Services
{
    public interface IUploadFilesService
    {
        Task Upload(IFormFile formFile);
    }
}
