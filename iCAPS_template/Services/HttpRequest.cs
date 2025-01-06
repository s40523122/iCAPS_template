using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iCAPS
{
    public class HttpRequest
    {
        public static string baseUrl = "";

        //public HttpRequest(string Url) 
        //{
        //    baseUrl = Url;
        //}

        /// <summary>
        /// 發起 POST 請求到指定路由
        /// </summary>
        /// <param name="route"> 路由地址 </param>
        /// <param name="dataMsg"> 欲傳送物件 </param>
        /// <param name="useBaseUrl">(可選)是否使用baseUrl</param>
        /// <returns> POST 回應內容字串 </returns>
        /// <remarks>
        /// 使用範例如下：
        /// <code>
        /// string responseBody = await HTTPJson.PostResponse(route, dataMsg);
        /// </code>
        /// 嘗試解析回傳內容是否為 int ，以判定是否得到正確回應。
        /// <code>
        /// if(int.TryParse(responseBody, out int number))
        /// </code>
        /// </remarks>
        public static async Task<String> PostRequest(string route, object dataMsg, bool useBaseUrl = true)
        {
            string RequestUrl = route;      // 請求網址

            if (useBaseUrl)
            {
                if (baseUrl == "")
                {
                    MsgBox.Show("尚未指定 HttpRequest.baseUrl !");
                    return "尚未指定 HttpRequest.baseUrl !";
                }
                RequestUrl = baseUrl + route;
            }

            // 製作請求內容
            string innerJson = JsonConvert.SerializeObject(dataMsg);
            var content = new StringContent(innerJson, Encoding.UTF8, "application/json");

            // 建立 HttpClient 實例
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.Timeout = TimeSpan.FromSeconds(10);          // 10秒超時

                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(RequestUrl, content);     // 等待回應

                    if (response.IsSuccessStatusCode)
                    {
                        //MessageBox.Show("POST 請求成功！");
                        Console.WriteLine("POST request success！");
                        
                    }
                    else
                    {
                        //MessageBox.Show($"發送 POST 請求時發生錯誤：{response.StatusCode}");
                        int status = (int)response.StatusCode;
                        Console.WriteLine($"Error when POST request：{status} {response.StatusCode}");
                        //return status.ToString();
                    }
                    string responseBody = await response.Content.ReadAsStringAsync();       // 回應內容字串
                    return responseBody;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("[Error]");
                    Debug.WriteLine(ex.Message);
                    //return "500";
                    return "無法連接至伺服器。" ;
                }
            } 
        }

        /// <summary>
        /// 發起 GET 請求到指定路由
        /// </summary>
        /// <param name="route">路由地址</param>
        /// <param name="useBaseUrl">是否使用baseUrl</param>
        /// <returns>(string) GET 回應內容，若錯誤回傳 HTTP 狀態碼 </returns>
        /// <remarks>
        /// 使用範例如下：
        /// <code>
        /// string responseBody = await HTTPJson.PostResponse(route, dataMsg);
        /// </code>
        /// 嘗試解析回傳內容是否為 int ，以判定是否得到正確回應。
        /// <code>
        /// if(int.TryParse(responseBody, out int number))
        /// </code>
        /// </remarks>
        public static async Task<String> GetResponse(string route, bool useBaseUrl = true)
        {
            string RequestUrl = route;      // 請求網址

            if (useBaseUrl)
            {
                if (baseUrl == "")
                {
                    MsgBox.Show("尚未指定 HttpRequest.baseUrl !");
                    return "尚未指定 HttpRequest.baseUrl !";
                }
                RequestUrl = baseUrl + route;
            }

            // 建立 HttpClient 實例
            using (var httpClient = new HttpClient())
            {


                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.Timeout = TimeSpan.FromSeconds(10);          // 10秒超時

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(RequestUrl);     // 等待回應

                    if (response.IsSuccessStatusCode)
                    {
                        //MessageBox.Show("GET 請求成功！");
                        Console.WriteLine("GET request success！");
                    }
                    else
                    {
                        int status = (int)response.StatusCode;
                        //MessageBox.Show($"發送 GET 請求時發生錯誤：{response.StatusCode}");
                        Console.WriteLine($"Error when get request：{status} {response.StatusCode}");
                    }
                    string responseBody = await response.Content.ReadAsStringAsync();       // 回應內容字串
                    return responseBody;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("[Error]");
                    Debug.WriteLine(ex.Message);
                    //return "500";
                    return "無法連接至伺服器。" ;
                }
            }
        }
    }
}


