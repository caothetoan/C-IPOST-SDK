using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLink.Plugins.IPOST.Domain.Response
{
    public enum error_code_ipost
    {
        EXCEPTION= 100,
        REQUEST_PARAM_EXCEPTION=300,
        REQUEST_TOO_MANY_EXCEPTION=301,
        APPLICATION_TOKEN_INVALID=1400,
        ACCESS_TOKEN_INVALID=1401,
        ACCOUNT_INVALID=1402,
        ACCOUNT_LOGIN_FAIL=1403,
        //order error
        TIME_IS_NOT_AVAIABLE=1502,
        REQUEST_LOCKED_BY_POS=1501
    }

    public static class ErrorCodeIpostDesc
    {
        public static string EXCEPTION = "Hệ thống chưa xử lý được";
    }
}
