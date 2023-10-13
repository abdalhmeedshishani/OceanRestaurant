using OceanKitchen.Utils.Enum;
using OceanRestaurant.Dtos.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanRestaurant.Dtos.Orders
{
    public class OrderDetailsDto
    {
        public OrderDetailsDto()
        {
            Dishes = new List<DishDto>();
        }

        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
        public CookingMethod CookingMethod { get; set; }
        public string GuestName { get; set; }
        public List<DishDto> Dishes { get; set; }
    }
}
