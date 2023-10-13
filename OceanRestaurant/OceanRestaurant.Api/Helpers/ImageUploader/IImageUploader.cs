using Microsoft.AspNetCore.Mvc;

namespace OceanRestaurant.Api.Helpers.ImageUploader
{
    public interface IImageUploader
    {
        public List<string> Upload(IFormFile[] files);
    }
}
