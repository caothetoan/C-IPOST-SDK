using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Response
{
    public class ipost_item_type
    {
        public long Id { get; set; }

        public string Item_Type_Name { get; set; }
        public string Item_Type_Id { get; set; }

        public DateTime Last_Updated { get; set; }

        public int Active { get; set; }

        public long Pos_Id { get; set; }

        public bool Is_material { get; set; }

    }
}
