using OceanKitchen.Utils.Enum;
using OceanRestaurant.Dtos.Orders;
using OceanRestaurant.Dtos.Uploaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OceanRestaurant.Dtos.Guests
{
    public class GuestDetailsDto
    {

        public GuestDetailsDto()
        {
            Images = new List<UploaderImageDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public List<UploaderImageDto> Images { get; set; }


    }
}
