﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using ShiftItUptApp.Models;

namespace ShiftItUptApp.Services
{
    public class ShiftItUptWebAPIProxy
    {
        #region without tunnel
        /*
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "localhost";
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
            DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5110/api/" : $"http://{serverIP}:5110/api/";
        private static string ImageBaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
            DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5110" : $"http://{serverIP}:5110";
        */
        #endregion

        #region with tunnel
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "nb6s286v-5099.euw.devtunnels.ms";
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = "https://7553shcv-5099.euw.devtunnels.ms/api/";
        private static string ImageBaseAddress = "https://nb6s286v-5099.euw.devtunnels.ms/";
        #endregion

        public ShiftItUptWebAPIProxy()
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            this.client = new HttpClient(handler);
            this.baseUrl = BaseAddress;
        }

        public string GetImagesBaseAddress()
        {
            return ShiftItUptWebAPIProxy.ImageBaseAddress;
        }

        public string GetDefaultProfilePhotoUrl()
        {
            return $"{ShiftItUptWebAPIProxy.ImageBaseAddress}/profileImages/default.png";
        }
        //public async Task<Worker?> LoginAsync(LoginDto userInfo)
        //{
        //    //Set URI to the specific function API
        //    string url = $"{this.baseUrl}login";
        //    try
        //    {
        //        //Call the server API
        //        string json = JsonSerializer.Serialize(userInfo);
        //        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await client.PostAsync(url, content);
        //        //Check status
        //        if (response.IsSuccessStatusCode)
        //        {
        //            //Extract the content as string
        //            string resContent = await response.Content.ReadAsStringAsync();
        //            //Desrialize result
        //            JsonSerializerOptions options = new JsonSerializerOptions
        //            {
        //                PropertyNameCaseInsensitive = true
        //            };
        //            Worker? result = JsonSerializer.Deserialize<Worker>(resContent, options);
        //            return result;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}