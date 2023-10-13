using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanRestaurant.Dtos.Orders
{
    public class OrderListDto
    {

        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
        

    }
}
