using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppAndroid1.Classess
{
    public class GetRooms
    {
        // Создается один раз для всего приложения.
        private static readonly HttpClient client;

        static GetRooms()
        {
            client = new HttpClient();
        }

        public async Task<string> Get(string uri)
        {
            //Task<string> result;

            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            await client.SendAsync(request);
            return await client.GetStringAsync(uri);

            //HttpResponseMessage response = await client.SendAsync(request);
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    HttpContent responseContent = response.Content;
            //    result = await responseContent.ReadAsStringAsync();
            //}

            //return result;
        }
    }
}
