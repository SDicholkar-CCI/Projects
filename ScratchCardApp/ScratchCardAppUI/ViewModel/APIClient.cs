using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ScratchCardAppUI.ViewModel
{
    public static class APIClient
    {
        public static HttpClient webApiClient = new HttpClient();

        static APIClient()
        {
            webApiClient.BaseAddress = new Uri("http://localhost:59412/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}