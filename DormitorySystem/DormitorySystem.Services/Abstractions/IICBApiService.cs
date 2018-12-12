using System.Threading.Tasks;

namespace DormitorySystem.Services.Abstractions
{
    public interface IICBApiService
    {
        Task<int> CheckForNewSensor();

        Task<int> UpdateSensorsAsync();
    }
}
