using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JinToolkit.Services
{
    class LineNotify
    {
        public static string connectToken = "";
        public static double intervalMin = 5;

        private DateTime recordTime = DateTime.Now;

        private static async Task LineNotifyFn(Dictionary<string, string> formData)
        {
            string url = "https://notify-api.line.me/api/notify";

            using (var client = new HttpClient())
            {
                // 設定 Authorization Bearer token
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", connectToken);

                var content = new FormUrlEncodedContent(formData);


                try
                {
                    // 發送 POST 請求
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // 成功響應
                        string responseBody = await response.Content.ReadAsStringAsync();
                        //MessageBox.Show($"Response: {responseBody}");                   
                    }
                    else
                    {
                        // 處理錯誤響應
                        Console.WriteLine("【 LineNotify 】Error: " + response.StatusCode);
                    }
                }
                catch (HttpRequestException ex)
                {
                    // 處理請求異常
                    Console.WriteLine($"【 LineNotify 】Error: {ex.Message}");
                }
            }
        }

        public static async void send2LineNotify(string msg)
        {
            var formData = new Dictionary<string, string>
                {
                    { "message", msg },
                    //{ "something", "test123" }
                };

            await LineNotifyFn(formData);
        }
    }

    
}
