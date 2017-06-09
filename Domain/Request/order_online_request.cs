using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Request
{
    public class order_online_request
    {
        public string Pos_parent { get; set; }

        public string Pos_id { get; set; }

        public string Full_address { get; set; }

        public string Note { get; set; }

        public string Payment_method { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public booking_info Booking_info { get; set; }

        public List<order_online> Order_online { get; set; }

    }
   

}
