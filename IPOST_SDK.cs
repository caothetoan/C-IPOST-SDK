using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLink.Core.Helpers;
using FoodLink.Data.Entity.Settings;
using FoodLink.Plugins.IPOST.Domain.Request;
using FoodLink.Plugins.IPOST.Domain.Response;
using Newtonsoft.Json;

namespace FoodLink.Plugins.IPOST
{
    public class IPOST_SDK
    {
        private static string _acceptType = "application/x-www-form-urlencoded"; // "text/html; encoding='utf-8'";// 
        private static string _token = "";
        #region Request helper

        /// <summary>
        /// Get base URL of  API
        /// </summary>
        /// <param name="apiUrlBase">Is sandbox (testing environment) used</param>
        /// <returns>URL</returns>
        private static string GetBaseUrl(string apiUrlBase)
        {
            return string.IsNullOrEmpty(apiUrlBase)
                ? string.Format("http://foodbooktest.ipos.com.vn/ipos/ws")
                : string.Format("{0}/ipos/ws", apiUrlBase);
        }


        private static T Request<T>(string url,

            Dictionary<string, string> parameters,
            string access_token,
            string token,
            out string errors)
        {
            var response = WebRequestHelper.Request(url, out errors, parameters, _acceptType,
                access_token,
                token,
                "GET");

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<T>(response);
            }
            //else
            //{
            //    throw new Exception("Response is not valid.");
            //}
            return default(T);
        }
        private static T Post<T>(string url,

            Dictionary<string, string> parameters,
            string access_token,
            string token,
            out string errors)
        {
            var response = WebRequestHelper.Request(url, out errors, parameters, _acceptType,
                access_token,
                token,
                "POST");

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<T>(response);
            }
            //else
            //{
            //    throw new Exception("Response is not valid.");
            //}
            return default(T);
        }
        #endregion

        /// <summary>
        /// Lấy token key quản lý thương hiệu
        /// </summary>
        /// <param name="ipostSettings"></param>
        /// <param name="manager_login_request"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static manager_login_response GetPosToken(IPOSTSettings ipostSettings,
            manager_login_request manager_login_request, out string errors)
        {
            var url = string.Format("{0}/auth/manager_login", GetBaseUrl(ipostSettings.ApiUrl));

            var parameters = new Dictionary<string, string>();

            parameters.Add(ipost_parameters.pos_parent, ipostSettings.Pos_parent);
            parameters.Add(ipost_parameters.username, manager_login_request.username);
            parameters.Add(ipost_parameters.password, manager_login_request.password);

            manager_login_response manager_login_response = Post<manager_login_response>(url, parameters, ipostSettings.Access_token, "", out errors);

            if (manager_login_response?.data != null)
                ipostSettings.Pos_token = manager_login_response.data.token;
            return manager_login_response;
        }

        /// <summary>
        /// dữ liệu login user
        /// </summary>
        /// <param name="ipostSettings"></param>
        /// <param name="manager_login_request"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static partner_login_response GetUserToken(IPOSTSettings ipostSettings,
            manager_login_request manager_login_request, out string errors)
        {
            var url = string.Format("{0}/auth/partner_login", GetBaseUrl(ipostSettings.ApiUrl));

            var parameters = new Dictionary<string, string>();

            parameters.Add("msisdn", manager_login_request.msisdn);
            parameters.Add(ipost_parameters.username, manager_login_request.username);
            parameters.Add("email", manager_login_request.email);

            partner_login_response partner_login_response = Post<partner_login_response>(url, parameters, ipostSettings.Access_token, "", out errors);
            if (partner_login_response?.data != null)
                ipostSettings.User_token = partner_login_response.data.Token;

            return partner_login_response;
        }
        //Tích hợp luồng gọi đồ /đặt chỗ online

        /// <summary>
        /// lấy dữ liệu thuộc chuỗi nhà hàng
        /// trả về thông tin các điểm bán hàng, món category, món ăn
        /// </summary>
        /// <param name="ipostSettings"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static pos_all_data_response GetAllData(IPOSTSettings ipostSettings,
            out string errors)
        {
            var url = string.Format("{0}/ipcc/get_all_data", GetBaseUrl(ipostSettings.ApiUrl));

            return Request<pos_all_data_response>(url, null, ipostSettings.Access_token, ipostSettings.Pos_token, out errors);
        }


        /// <summary>
        /// Gọi đồ online
        /// </summary>
        /// <param name="ipostSettings"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static order_online_response OrderOnline(IPOSTSettings ipostSettings,
           order_online_request order_online_request,
           out string errors)
        {
            var url = string.Format("{0}/partner/order_online", GetBaseUrl(ipostSettings.ApiUrl));
            var parameters = new Dictionary<string, string>();

            parameters.Add(ipost_parameters.pos_parent, order_online_request.Pos_parent);
            parameters.Add(ipost_parameters.pos_id, order_online_request.Pos_id);
            parameters.Add("full_address", order_online_request.Full_address);
            parameters.Add("note", order_online_request.Note);
            parameters.Add("longitude", order_online_request.Longitude.ToString());
            parameters.Add("latitude", order_online_request.Latitude.ToString());
            parameters.Add("payment_method", order_online_request.Payment_method);

            parameters.Add(ipost_parameters.booking_info, JsonSerialize.SerializeObject(order_online_request.Booking_info));
            parameters.Add(ipost_parameters.orders, JsonSerialize.SerializeObject(order_online_request.Order_online));

            return Post<order_online_response>(url, parameters, ipostSettings.Access_token, ipostSettings.User_token, out errors);
        }

        /// <summary>
        /// Đặt bàn trước
        /// </summary>
        /// <param name="ipostSettings"></param>
        /// <param name="token"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static booking_online_response BookingOnline(IPOSTSettings ipostSettings,
           booking_online_request order_online_request,
           out string errors)
        {
            var url = string.Format("{0}/partner/booking_online", GetBaseUrl(ipostSettings.ApiUrl));
            var parameters = new Dictionary<string, string>();


            parameters.Add(ipost_parameters.pos_id, order_online_request.Pos_id);
            parameters.Add(ipost_parameters.booking_info, JsonSerialize.SerializeObject(order_online_request.Booking_info));
            if (order_online_request.Order_online != null)
                parameters.Add(ipost_parameters.orders, JsonSerialize.SerializeObject(order_online_request.Order_online));

            return Post<booking_online_response>(url, parameters, ipostSettings.Access_token, ipostSettings.User_token, out errors);
        }
    }
}
