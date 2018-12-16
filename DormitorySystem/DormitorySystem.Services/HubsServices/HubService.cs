using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.HubsServices.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DormitorySystem.Services.HubsServices
{
    public class HubService : IHubService
    {
        private readonly IHubContext<NotifyHub> hubContext;

        public HubService(IHubContext<NotifyHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task Notify(string userId, string name)
        {
            await hubContext.Clients.User(userId).SendAsync("Notify", name);
        }

        public async Task NotifyToAll(string message)
        {
            await hubContext.Clients.All.SendAsync("Offline", message);
        }
    }
}
