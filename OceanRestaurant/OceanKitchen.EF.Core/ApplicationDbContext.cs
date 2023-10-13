using Microsoft.EntityFrameworkCore;
using OceanRestaurant.Entites;

namespace OceanRestaurant.EF.Core
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Dish> Dishes  { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DishImage> dishImages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}