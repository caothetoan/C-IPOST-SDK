using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Response
{
    public class ipost_base_response
    {

        public bool is_next { get; set; }

        public error_response error { get; set; }

        public bool success => error == null;
    }
}
