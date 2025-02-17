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

        /// <summary>
        /// 回應字串訊息
        /// </summary>
        public string ResponseMessage = "";
        
        private string _base_url = "";

        public HttpRequest(string Url) 
        {
            _base_url = Url;
        }

        /// <summary>
        /// 發起 POST 請求到指定路由
        /// </summary>
        /// <param name="route"> 路由地址。如果 useBaseUrl 為 true，須提供完整網址。</param>
        /// <param name="dataMsg"> 欲傳送物件 </param>
        /// <param name="useBaseUrl">(可選)是否使用baseUrl。</param>
        /// <returns> POST 回應內容字串 </returns>
        /// <remarks>
        /// 使用範例如下：
        /// <code>
        /// int responseBody = await HTTPJson.PostResponse(route, dataMsg);
        /// string request_message = HTTPJson.RequestMessage;
        /// </code>
        /// </remarks>
        public async Task<int> PostRequest(string route, object dataMsg, bool useBaseUrl = true)
        {
            string RequestUrl = useBaseUrl ? _base_url + route : route;      // 請求網址

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

                    int response_code = (int)response.StatusCode;

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseMessage = $"Error when POST request：{response_code} {response.StatusCode} ({response.Content})";
                    }
                    else
                    {
                        ResponseMessage = await response.Content.ReadAsStringAsync();       // 回應內容字串
                    }
                    return response_code;
                }
                catch (Exception ex)
                {
                    ResponseMessage = $"無法連接至伺服器 ({ex.Message})。";
                    return 500;
                }
            } 
        }

        /// <summary>
        /// 發起 GET 請求到指定路由
        /// </summary>
        /// <param name="route">路由地址。如果 useBaseUrl 為 true，須提供完整網址。</param>
        /// <param name="useBaseUrl">(可選)是否使用baseUrl。</param>
        /// <returns>(string) GET 回應內容，若錯誤回傳 HTTP 狀態碼 </returns>
        /// <remarks>
        /// 使用範例如下：
        /// <code>
        /// int responseBody = await HTTPJson.GetResponse(route);
        /// string request_message = HTTPJson.RequestMessage;
        /// </code>
        /// </remarks>
        public async Task<int> GetResponse(string route, bool useBaseUrl = true)
        {
            string RequestUrl = useBaseUrl ? _base_url + route : route;      // 請求網址

            // 建立 HttpClient 實例
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.Timeout = TimeSpan.FromSeconds(10);          // 10秒超時

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(RequestUrl);     // 等待回應

                    int response_code = (int)response.StatusCode;

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseMessage = $"Error when get request：{response_code} {response.StatusCode} ({response.Content})";
                    }
                    else
                    {
                        ResponseMessage = await response.Content.ReadAsStringAsync();       // 回應內容字串
                    }

                    return response_code;
                }
                catch (Exception ex)
                {
                    ResponseMessage = $"無法連接至伺服器 ({ex.Message})。";
                    return 500;
                }
            }
        }
    }
}


