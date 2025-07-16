using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IImagesService
    {
        Task<Image> Upload(Image image);
    }
}
