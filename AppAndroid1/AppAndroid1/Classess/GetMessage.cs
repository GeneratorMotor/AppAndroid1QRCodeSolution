using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppAndroid1.Classess
{
    public class GetMessage
    {
        // Создается один раз для всего приложения.
        private static readonly HttpClient client;

        static GetMessage()
        {
            client = new HttpClient();
        }

        public async Task<string> Get(string uri)
        {
            // Переменная для хранения результата.
            string result= string.Empty;
           
                // Получим данные из Web api.
                using (HttpResponseMessage httpResponseMessage = await client.GetAsync(uri))
                {
                    // Прроверим получили ответ от сервера или нет.
                    if (httpResponseMessage.IsSuccessStatusCode == true)
                    {
                        result = await httpResponseMessage.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        // Выбросим исключение если произошла ошибка
                        httpResponseMessage.EnsureSuccessStatusCode();
                    }
                }
            
                return result;
        }



    }
}
