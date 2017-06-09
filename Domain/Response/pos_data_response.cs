using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLink.Data.Constants;

namespace FoodLink.Plugins.IPOST.Domain.Response
{
    public class pos_all_data_response : ipost_base_response
    {
        public pos_data_response data { get; set; }

    }

    public class pos_data_response
    {
        public List<ipost_pos> list_pos { get; set; }

        public List<ipost_item_type> list_item_type { get; set; }

        public List<ipost_item> list_item { get; set; }
    }

}
