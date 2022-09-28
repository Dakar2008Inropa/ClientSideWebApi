using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ClientSideWebApi.Utilities
{
    public static class WebClientHelper
    {
        public static string GetJson(string url)
        {
            try
            {
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                string json = client.DownloadString(url);
                return json;
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }
        public static string UploadJson(string url, string json, string method = null)
        {
            try
            {
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                client.Headers.Add("Content-Type", "application/json");
                string result;
                if (string.IsNullOrWhiteSpace(method))
                {
                    result = client.UploadString(url, json);
                }
                else
                {
                    result = client.UploadString(url, method, json);
                }
                return result;
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }
    }
}