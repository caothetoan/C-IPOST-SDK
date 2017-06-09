using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Response
{
    public class ipost_pos
    {
        #region propertises
        public long Id { get; set; }

        public string Description { get; set; }

        public string Open_Time { get; set; }

        public string Phone_Number { get; set; }

        public decimal Estimate_Price { get; set; }

        public decimal Estimate_Price_Max { get; set; }

        public string Wifi_Password { get; set; }

        public bool Is_Car_Parking { get; set; }

        public bool Is_Visa { get; set; }

        public bool Is_Sticky { get; set; }

        public string Post_Name { get; set; }

        public decimal Pos_Longitude { get; set; }

        public decimal Pos_Latitude { get; set; }

        public string Pos_Radius_Detal { get; set; }

        public string Pos_Parent { get; set; }


        public int Pos_Master_Id { get; set; }

        public int District_Id { get; set; }

        public int City_Id { get; set; }

        public string Pos_Address { get; set; }

        public string Image_Path { get; set; }
        public string Image_Path_Thumb { get; set; }
        public string Wifi_Service_Path { get; set; }

        public bool Is_Order_Online { get; set; }

        public bool Is_Order { get; set; }

        public bool Is_Booking { get; set; }

        public bool Is_Order_Later { get; set; }

        public bool Is_Ahamove_Active { get; set; }

        public string More_Info { get; set; }

        public string Website_Url { get; set; }

        public int Workstation_Id { get; set; }


        public int Active { get; set; }

        public bool Is_Show_Item_Type { get; set; }

        public decimal Min_Order_Price { get; set; }

        public decimal Ship_Price { get; set; }

        public bool Is_Active_Event_ShareFb { get; set; }

        public int Event_ShareFb_Rate { get; set; }

        public int Order_Number_Server { get; set; }
        public int Order_Time_Average { get; set; }
        public int Order_Time_Min { get; set; }
        public int Order_Time_Max { get; set; }

        public string Phone_Manager { get; set; }

        public bool Is_Call_Center { get; set; }


        public bool Is_Pos_Mobile { get; set; }
        #endregion

    }
}
