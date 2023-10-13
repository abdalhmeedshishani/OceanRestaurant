using OceanKitchen.Utils.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanRestaurant.Dtos.Guests
{
    public class GuestListDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
    }
}
