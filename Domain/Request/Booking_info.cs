using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Request
{

    public class booking_info
    {
        public int Number_People { get; set; }

        public int Minute { get; set; }

        public int Hour { get; set; }

        public string Book_Date { get; set; }
    }
}
