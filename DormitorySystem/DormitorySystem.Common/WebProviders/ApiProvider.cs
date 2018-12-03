using System.Net;
using DormitorySystem.Common.Abstractions;

namespace DormitorySystem.Common.WebProvider
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
