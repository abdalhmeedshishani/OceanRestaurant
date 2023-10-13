using OceanKitchen.Utils.Enum;
using System.ComponentModel.DataAnnotations.Schema;
namespace OceanRestaurant.Entites
{
    public class Guest
    {

        public Guest()
        {
            Orders = new List<Order>();
            Images = new List<GuestImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public List<Order> Orders { get; set; }
        public List<GuestImage> Images { get; set; }


        [NotMapped]
        public int Age
        {
            get
            {

                return DateTime.Now.Year - DOB.Year;

            }
        }



    }
}
