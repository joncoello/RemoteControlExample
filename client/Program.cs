using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {

                Console.WriteLine("enter command");
                var line = Console.ReadLine();

                if (line == "exit")
                {
                    break;
                }

                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8080");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new
                {
                    ActionName = line
                };

                var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                var json = JsonConvert.SerializeObject(content, Formatting.None, jsonSerializerSettings);

                var stringContent = new StringContent(json,
                                    Encoding.UTF8,
                                    "application/json");
                
                var response = client.PostAsync("api/action", stringContent).Result;

                response.EnsureSuccessStatusCode();


            } while (true);

        }
    }
}
