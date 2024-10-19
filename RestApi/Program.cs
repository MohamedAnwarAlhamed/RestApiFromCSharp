using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace RestApi
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task Main(string[] args)
        {
            var apiUrl = "https://jsonplaceholder.typicode.com/posts";

            try
            {
                HttpResponseMessage Response = await client.GetAsync(apiUrl);

                if (Response.IsSuccessStatusCode)
                {
                    string responseData = await Response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<dynamic>(responseData);

                    Console.WriteLine(data);


                }
                else
                {
                    Console.WriteLine($"Error: {Response.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }
    }

}
