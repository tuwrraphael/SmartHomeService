using SmartHomeService.Models;
using System.Threading.Tasks;

namespace SmartHomeService.Services
{
    public interface IHifiController
    {
        Task DecreaseVolumeAsync(uint ammount);
        Task IncreaseVolumeAsync(uint ammount);
        Task GoToInputAsync(InputType input);
    }
}