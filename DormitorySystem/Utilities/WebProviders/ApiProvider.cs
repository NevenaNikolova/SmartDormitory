using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Utilities.WebProvider
{
    public class ApiProvider : IApiProvider
    {
        public string ReturnRespons(string url, string headerKey, string headerValue)
        {
            var client = new WebClient();
            client.Headers.Add(headerKey, headerValue);
            return client.DownloadString(url);
        }
    }
}
