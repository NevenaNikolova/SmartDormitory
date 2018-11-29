using System.Net;
using Utilities.Abstractions;

namespace Utilities.WebProvider
{
    public class ApiProvider : IApiProvider
    {
        public string ReturnResponse(string url, string header)
        {
            var client = new WebClient();
            client.Headers.Add(header);
            return client.DownloadString(url);
        }
    }
}
