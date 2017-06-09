using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Request
{
    public class order_online
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public string Item_Name { get; set; }

        public string Item_Id { get; set; }

        public string Item_Type_Id { get; set; }

        public string Note { get; set; }

    }
}
