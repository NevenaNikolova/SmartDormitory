using System.Collections.Generic;

namespace Utilities.WebProvider
{
    public interface IApiProvider
    {
        string ReturnRespons(string url, string headerKey, string headerValue);
    }
}