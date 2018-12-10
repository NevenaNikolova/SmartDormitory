using System.Collections.Generic;
using System.Threading.Tasks;

namespace DormitorySystem.Common.Abstractions
{
    public interface IApiProvider
    {
        Task<KeyValuePair<bool, string>> ReturnResponseAsync(string url, string header);
    }
}