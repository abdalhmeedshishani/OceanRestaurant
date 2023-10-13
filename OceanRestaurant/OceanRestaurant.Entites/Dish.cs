namespace OceanRestaurant.Entites
{
    public class Dish
    {
        public Dish()
        {
            Orders = new List<Order>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public string? ImageName { get; set; }

        public List<Order> Orders { get; set; }

    }
}


