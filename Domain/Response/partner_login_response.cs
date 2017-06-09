using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLink.Data.Constants;

namespace FoodLink.Plugins.IPOST.Domain.Response
{
    public class partner_login_response : ipost_base_response
    {
        public partner_login_data_response data { get; set; }
    }

    public class partner_login_data_response
    {
        public long Id { get; set; }

        public string Member_Name { get; set; }

        public string email { get; set; }

        public string Phone_Number { get; set; }

        /// <summary>
        /// Token có giá trị 15 phút
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime token_expired_date { get; set; }
        
    }
}
