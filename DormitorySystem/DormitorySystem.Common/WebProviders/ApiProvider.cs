using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DormitorySystem.Common.Abstractions;

namespace DormitorySystem.Common.WebProvider
{
    public class ApiProvider : IApiProvider
    {
        private readonly HttpClient httpClient;
        private KeyValuePair<bool, string> result;

        public ApiProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<KeyValuePair<bool, string>> ReturnResponseAsync(string url, string header)
        {
            string[] headerKeyValue = header.Split(':');

            if (headerKeyValue.Length != 2)
            {
                throw new Exception("ops");
            }

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add(headerKeyValue[0], headerKeyValue[1]);
            HttpResponseMessage response;

            try
            {
                response = await httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
                return result;
            }

            if (response.IsSuccessStatusCode)
            {
                this.result = new KeyValuePair<bool, string>
                    (response.IsSuccessStatusCode,
                    await response.Content.ReadAsStringAsync());
            }
            else
            {
                this.result = new KeyValuePair<bool, string>
                    (response.IsSuccessStatusCode,
                    response.StatusCode.ToString());
            }

            return result;
        }
    }
}
