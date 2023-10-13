
using OceanKitchen.Utils.Enum;

namespace OceanRestaurant.Dtos.Orders
{
    public class OrderDto
    {
        public OrderDto()
        {
            DishIds = new List<int>();      
        }

        public int Id { get; set; }
        public string Notes { get; set; }
        public CookingMethod CookingMethod { get; set; }

        public int GuestId { get; set; }

        public List<int> DishIds { get; set; }
    }
}
