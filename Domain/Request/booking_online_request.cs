using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Request
{
    public class booking_online_request
    {
       
        public string Pos_id { get; set; }
        
        public booking_info Booking_info { get; set; }

        public List<order_online> Order_online { get; set; }

    }
     
}
