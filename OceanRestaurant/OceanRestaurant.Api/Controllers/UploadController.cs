using Microsoft.AspNetCore.Mvc;
using OceanRestaurant.Api.Helpers.ImageUploader;
using OceanRestaurant.Dtos.Uploaders;
using System.Net.Http.Headers;

namespace OceanRestaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IImageUploader _fileUploader;

        public UploadController(IImageUploader fileUploader)
        {
            _fileUploader = fileUploader;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload(IFormFile[] files)
        {
            if (files.Length > 0)
            {
                var imagesNames = _fileUploader.Upload(files);

                var guestImages = GetVillaImages(imagesNames);

                return Ok(guestImages);
            }
            else
            {
                return BadRequest();
            }
        }

        private List<UploaderImageDto> GetVillaImages(List<string> imagesNames)
        {
            var imagesNamesDtos = new List<UploaderImageDto>();

            foreach (var imageNames in imagesNames)
            {
                var guestImage = new UploaderImageDto();
                guestImage.Id = 0;
                guestImage.Name = imageNames;

                imagesNamesDtos.Add(guestImage);
            }

            return imagesNamesDtos;
        }
    }
}
