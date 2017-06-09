using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FoodLink.Core.Helpers
{
    /// <summary>
    /// Make a HTTP WebRequest to an URI Helper
    /// </summary>
    public class WebRequestHelper
    {
        public static string Request(string url,
            out string errors,
            Dictionary<string, string> formBody = null,
            string contentType = "application/x-www-form-urlencoded",
            string access_token = "",
            string token = "",
            string method = "POST")
        {
            var errorBuilder = new StringBuilder();
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                if (!string.IsNullOrEmpty(access_token))
                    request.Headers.Add("access_token", access_token);

                if (!string.IsNullOrEmpty(token))
                    request.Headers.Add("token", token);

                var encoding = new UTF8Encoding();
                if (formBody != null)
                {
                    // Post 
                    string formData = formBody.Aggregate(string.Empty, (current, keyValuePair) => current + string.Format("&{0}={1}", keyValuePair.Key, keyValuePair.Value));
                    formData = formData.TrimStart('&');
                    byte[] data = encoding.GetBytes(formData);
                    request.ContentType = contentType;
                    request.ContentLength = data.Length;
                    Stream writer = request.GetRequestStream();
                    writer.Write(data, 0, data.Length);
                    writer.Close();
                }

                var response = (HttpWebResponse)request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var stringResponse = reader.ReadToEnd();
                    errors = errorBuilder.ToString();
                    return stringResponse;
                }
            }
            catch (Exception ex)
            {
                errorBuilder.AppendLine(ex.Message);
            }
            errors = errorBuilder.ToString();

            return string.Empty;

        }
        /// <summary>
        /// Make request to endpoint
        /// </summary>
        /// <param name="parameters">Request body</param>
        /// <param name="apiKey">The API key</param>
        /// <param name="method">Request method</param>
        /// <param name="acceptType">Request accept type</param>
        /// <param name="url">URL endpoint</param>
        /// <param name="errors">Errors</param>
        /// <returns>Response from  API or null if an error occurred</returns>
        public static HttpWebResponse Request(string url, string parameters, string apiKey, string method, string acceptType,
             out string errors)
        {
            var errorBuilder = new StringBuilder();
            try
            {
                //var authorization = Convert.ToBase64String(Encoding.Default.GetBytes(apiKey));

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.Accept = acceptType;
                //request.Headers.Add(HttpRequestHeader.Authorization, string.Format("Basic {0}", authorization));
                //request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US");

                if (method == "POST")
                {
                    var postData = Encoding.Default.GetBytes(parameters);
                    request.ContentLength = postData.Length;
                    request.ContentType = acceptType;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(postData, 0, postData.Length);
                    }
                }

                var response = (HttpWebResponse)request.GetResponse();
                errors = errorBuilder.ToString();

                return response;
            }
            catch (WebException ex)
            {
                try
                {
                    //var response = (HttpWebResponse)ex.Response;
                    //using (var streamReader = new StreamReader(response.GetResponseStream()))
                    //{
                    //    var serializerResponse = new XmlSerializer(typeof(messages));
                    //    var errorMessages = (messages)serializerResponse.Deserialize(streamReader);
                    //    if (errorMessages != null)
                    //        errorMessages.message.ToList().ForEach(error => errorBuilder.AppendLine(string.Format("Canada Post error {0}: {1}", error.code, error.description)));
                    //}
                }
                catch (Exception e)
                {
                    errorBuilder.AppendLine(e.Message);
                }
            }
            catch (Exception e)
            {
                errorBuilder.AppendLine(e.Message);
            }

            errors = errorBuilder.ToString();

            return null;
        }

    }
}
