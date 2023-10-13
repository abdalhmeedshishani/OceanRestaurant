using OceanKitchen.Utils.Enum;
using OceanRestaurant.Dtos.Uploaders;

namespace OceanRestaurant.Dtos.Guests
{
    public class GuestDto
    {

        public GuestDto()
        {
            Images = new List<UploaderImageDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; } 
        public List<UploaderImageDto> Images { get; set; }


    }
}
