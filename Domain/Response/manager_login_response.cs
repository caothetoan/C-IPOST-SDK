using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Response
{
    public class manager_login_response: ipost_base_response
    {
        public manager_login_data_response data { get; set; }
        
    }

    public class manager_login_data_response
    {
        public long id { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string pos_parent { get; set; }

        public string source { get; set; }

        public bool active { get; set; }

        public int type { get; set; }

        public int max_pos_create { get; set; }


        public string pos_id_list { get; set; }

        public string call_center_ext { get; set; }

        public DateTime updated_at { get; set; }

        public string token { get; set; }

        public DateTime token_expired_date { get; set; }

        public int callcenter_short { get; set; }
    }
}
