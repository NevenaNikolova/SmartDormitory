using System.Threading.Tasks;

namespace DormitorySystem.Services.Abstractions
{
    public interface IHubService
    {
        Task Notify(string userId, string name);

        Task NotifyToAll(string message);
    }
}