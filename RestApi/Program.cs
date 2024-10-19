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
            // Step 1: Define the API URL and the bearer token
            var apiUrl = "https://api-sandbox.tamara.co/checkout"; // Replace with your actual API URL
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhY2NvdW50SWQiOiJkZTQzM2I2Yy03YjdkLTQ5M2MtOGIwNS1kMjVhNDA2YTRhYWEiLCJ0eXBlIjoibWVyY2hhbnQiLCJzYWx0IjoiMmE1ZjQyYWYwMzkwOGZkZmJmYmEzMzY2ZjlkOGE5NzMiLCJpYXQiOjE2NzU5Mzc0NDIsImlzcyI6IlRhbWFyYSJ9.Yf8fmJoCChAnE9TN4tOVDtI8dwfMQqAa9DsOpFZPYqa4GDUCaSpmh0BLkiOondzee3j33_50S2Ug6RQIqFuxnqmGxar_jOQUXf82pJgcOomhFLa7JH1B--sDMHQVQ7fBvkk8JSCKJaj3V3T1uJ__lamoVa4jSemPUVYoCVA-pZevWXQ10sRTotjfdLWFeO3e1VV7Zf2rHqlfiMI8WXiSL3bZEIvcG0oQNaOmZsabVtdspJYBgvV3RfF4CUfwL3yzAU3tix_iiG3_kL3_HZ58TULWlzm1ttM7q2p5rdUCQbVTPja__bSutHmPEWjglPf4ebHZgl2xpjINJ1-RHPMzgg"; // Replace with your actual bearer token

            // Step 2: Add the Bearer Token to the Authorization header
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Step 3: Create the dynamic data using a Dictionary
            var postData = new Dictionary<string, object>
        {
            { "order_reference_id", "JobOrd-2023/11/3861" },
            { "order_number", "JobOrd-2023/11/3861" },
            { "total_amount", new Dictionary<string, object> {
                { "amount", 100.55 },
                { "currency", "SAR" }
            }},
            { "description", "string" },
            { "country_code", "SA" },
            { "payment_type", "PAY_BY_INSTALMENTS" },
            { "instalments", null },
            { "locale", "en_US" },
            { "items", new List<Dictionary<string, object>> {
                new Dictionary<string, object> {
                    { "reference_id", "123456" },
                    { "type", "Digital" },
                    { "name", "Lego City 8601" },
                    { "sku", "SA-12436" },
                    { "image_url", "https://www.example.com/product.jpg" },
                    { "item_url", "https://www.example.com/product.html" },
                    { "quantity", 1 },
                    { "unit_price", new Dictionary<string, object> {
                        { "amount", "100.00" },
                        { "currency", "SAR" }
                    }},
                    { "discount_amount", new Dictionary<string, object> {
                        { "amount", "100.00" },
                        { "currency", "SAR" }
                    }},
                    { "tax_amount", new Dictionary<string, object> {
                        { "amount", "100.00" },
                        { "currency", "SAR" }
                    }},
                    { "total_amount", new Dictionary<string, object> {
                        { "amount", "100.00" },
                        { "currency", "SAR" }
                    }}
                }
            }},
            { "consumer", new Dictionary<string, object> {
                { "first_name", "Mona" },
                { "last_name", "Lisa" },
                { "phone_number", "502223333" },
                { "email", "user@example.com" }
            }},
            { "billing_address", new Dictionary<string, object> {
                { "first_name", "Mona" },
                { "last_name", "Lisa" },
                { "line1", "3764 Al Urubah Rd" },
                { "line2", "string" },
                { "region", "As Sulimaniyah" },
                { "postal_code", "12345" },
                { "city", "Riyadh" },
                { "country_code", "SA" },
                { "phone_number", "502223333" }
            }},
            { "shipping_address", new Dictionary<string, object> {
                { "first_name", "Mona" },
                { "last_name", "Lisa" },
                { "line1", "3764 Al Urubah Rd" },
                { "line2", "string" },
                { "region", "As Sulimaniyah" },
                { "postal_code", "12345" },
                { "city", "Riyadh" },
                { "country_code", "SA" },
                { "phone_number", "502223333" }
            }},
            { "discount", new Dictionary<string, object> {
                { "name", "Christmas 2020" },
                { "amount", new Dictionary<string, object> {
                    { "amount", "100.00" },
                    { "currency", "SAR" }
                }}
            }},
            { "tax_amount", new Dictionary<string, object> {
                { "amount", "100.00" },
                { "currency", "SAR" }
            }},
            { "shipping_amount", new Dictionary<string, object> {
                { "amount", "100.00" },
                { "currency", "SAR" }
            }},
            { "merchant_url", new Dictionary<string, object> {
                { "success", "https://example.com/checkout/success" },
                { "failure", "https://example.com/checkout/failure" },
                { "cancel", "https://example.com/checkout/cancel" },
                { "notification", "https://example.com/payments/tamarapay" }
            }},
            { "platform", "Magento" },
            { "is_mobile", false },
            { "risk_assessment", new Dictionary<string, object> {
                { "customer_age", 22 },
                { "customer_dob", "31-01-2000" },
                { "customer_gender", "Male" },
                { "customer_nationality", "SA" },
                { "is_premium_customer", true },
                { "is_existing_customer", true },
                { "is_guest_user", true },
                { "account_creation_date", "31-01-2019" },
                { "date_of_first_transaction", "31-01-2019" },
                { "is_card_on_file", true },
                { "is_COD_customer", true },
                { "has_delivered_order", true },
                { "is_phone_verified", true },
                { "is_fraudulent_customer", true },
                { "total_ltv", 501.5 },
                { "total_order_count", 12 },
                { "order_amount_last3months", 301.5 },
                { "order_count_last3months", 2 },
                { "last_order_date", "31-01-2021" },
                { "last_order_amount", 301.5 },
                { "reward_program_enrolled", true },
                { "reward_program_points", 300 }
            }},
            { "expires_in_minutes", 0 },
            { "additional_data", new Dictionary<string, object> {
                { "delivery_method", "home delivery" },
                { "pickup_store", "Store A" },
                { "store_code", "Store code A" },
                { "vendor_info", new List<Dictionary<string, object>> {
                    new Dictionary<string, object> {
                        { "vendor_amount", 0 },
                        { "merchant_settlement_amount", 0 },
                        { "vendor_reference_code", "string" }
                    }
                }}
            }}
        };

            // Step 4: Serialize the dictionary to JSON
            var jsonContent = JsonConvert.SerializeObject(postData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Step 5: Send the POST request with the content
            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                // Step 6: Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response: {responseData}");
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
