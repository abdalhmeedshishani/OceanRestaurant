using OceanKitchen.Utils.Enum;
namespace OceanRestaurant.Entites
{
    public class Order
    {
        public Order()
        {
            Dishes = new List<Dish>();
        }

        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
        public CookingMethod CookingMethod { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        public List<Dish> Dishes { get; set; }


    }
}
