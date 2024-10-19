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
            // Step 1: Define the API URL you want to call
            var apiUrl = "https://api-sandbox.tamara.co/checkout/payment-types?country=SA&currency=SAR&order_value=600&phone=966503334444"; // Replace with your API URL

            // Step 2: Define the Bearer Token
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhY2NvdW50SWQiOiJkZTQzM2I2Yy03YjdkLTQ5M2MtOGIwNS1kMjVhNDA2YTRhYWEiLCJ0eXBlIjoibWVyY2hhbnQiLCJzYWx0IjoiMmE1ZjQyYWYwMzkwOGZkZmJmYmEzMzY2ZjlkOGE5NzMiLCJpYXQiOjE2NzU5Mzc0NDIsImlzcyI6IlRhbWFyYSJ9.Yf8fmJoCChAnE9TN4tOVDtI8dwfMQqAa9DsOpFZPYqa4GDUCaSpmh0BLkiOondzee3j33_50S2Ug6RQIqFuxnqmGxar_jOQUXf82pJgcOomhFLa7JH1B--sDMHQVQ7fBvkk8JSCKJaj3V3T1uJ__lamoVa4jSemPUVYoCVA-pZevWXQ10sRTotjfdLWFeO3e1VV7Zf2rHqlfiMI8WXiSL3bZEIvcG0oQNaOmZsabVtdspJYBgvV3RfF4CUfwL3yzAU3tix_iiG3_kL3_HZ58TULWlzm1ttM7q2p5rdUCQbVTPja__bSutHmPEWjglPf4ebHZgl2xpjINJ1-RHPMzgg"; // Replace with your actual token

            // Step 3: Add the Authorization header with the Bearer token
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Step 4: Send a GET request
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Step 5: Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Step 6: Read the response content as a string
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Step 7: Deserialize the JSON into a C# object (if applicable)
                    var data = JsonConvert.DeserializeObject<dynamic>(responseData);

                    // Step 8: Use the data
                    Console.WriteLine($"API Data: {data}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        Console.ReadLine();
        }
        
    }

}
