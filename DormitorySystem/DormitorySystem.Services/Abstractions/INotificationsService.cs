using System.Threading.Tasks;

namespace DormitorySystem.Services.Abstractions
{
    public interface INotificationsService
    {
        Task CheckForOutOfRangeSensorsAsync();
    }
}