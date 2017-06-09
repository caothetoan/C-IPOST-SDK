using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Response
{
    public class ipost_item
    {
        public long Id { get; set; }

        public long Pos_Id { get; set; }

        public string Item_Name { get; set; }

        public string Item_Id { get; set; }

        public string Item_Type_Id { get; set; }

        public string Item_Master_Id { get; set; }

        public string Item_Type_Master_Id { get; set; }

        public string Item_Image_Path { get; set; }

        public string Item_Image_Path_Thumb { get; set; }

        public string Fb_Image_Path_Thumb { get; set; }

        public DateTime Last_Updated { get; set; }

        public string Description { get; set; }

        public string Description_Fb { get; set; }

        public decimal Ots_Price { get; set; }

        public decimal Ta_Price { get; set; }

        public long Point { get; set; }

        public bool Is_Gift { get; set; }

        public int Allow_Take_Away { get; set; }

        public int Show_On_Web { get; set; }

        public int Show_Price_On_Web { get; set; }

        public int Special_Type { get; set; }

        public int Active { get; set; }

        public bool Is_Eat_With { get; set; }

        public int Require_Eat_With { get; set; }

        public int Sort { get; set; }

    }
}
