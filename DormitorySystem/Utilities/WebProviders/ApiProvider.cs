using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Utilities.WebProvider
{
    public class ApiProvider : IApiProvider
    {
        public string ReturnRespons(string url, string header)
        {
            var client = new WebClient();
            client.Headers.Add(header);
            return client.DownloadString(url);
        }
    }
}
