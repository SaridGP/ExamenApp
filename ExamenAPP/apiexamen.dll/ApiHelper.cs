using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace apiexamen.dll
{
    public static class ApiHelper
    {
        public static HttpClient HttpClient { get; set; }

        public static void InitializeClient()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://localhost:44331/api/Examenes/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
