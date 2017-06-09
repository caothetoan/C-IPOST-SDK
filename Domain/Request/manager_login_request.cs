using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Request
{
    public class manager_login_request
    {
        public string  username { get; set; }

        public string password { get; set; }

        /// <summary>
        /// Số điện thoại có 84
        /// </summary>
        public string msisdn { get; set; }

        public string email { get; set; }
    }
}
