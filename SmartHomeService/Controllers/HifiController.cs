using Microsoft.AspNetCore.Mvc;
using SmartHomeService.Models;
using SmartHomeService.Services;
using System.Threading.Tasks;

namespace SmartHomeService.Controllers
{
    [Route("api/[controller]")]
    public class HifiController : Controller
    {
        private readonly IHifiRepository hifiRepository;
        private readonly IHifiControllerFactory hifiControllerFactory;

        public HifiController(IHifiRepository hifiRepository, IHifiControllerFactory hifiControllerFactory)
        {
            this.hifiRepository = hifiRepository;
            this.hifiControllerFactory = hifiControllerFactory;
        }

        [HttpGet("devices")]
        public async Task<HifiDevice[]> Get()
        {
            return await hifiRepository.GetAllAsync();
        }

        [HttpPut("{deviceId}/vol/inc/{ammount:int}")]
        public async Task<IActionResult> IncreaseVolume(string deviceId, int ammount)
        {
            var dev = await hifiRepository.GetByIdAsync(deviceId);
            if (null == dev)
            {
                return NotFound();
            }
            var ctrl = hifiControllerFactory.Get(dev);
            await ctrl.IncreaseVolumeAsync((uint)ammount);
            return Ok();
        }

        [HttpPut("{deviceId}/vol/dec/{ammount:int}")]
        public async Task<IActionResult> DecreaseVolume(string deviceId, uint ammount)
        {
            var dev = await hifiRepository.GetByIdAsync(deviceId);
            if (null == dev)
            {
                return NotFound();
            }
            var ctrl = hifiControllerFactory.Get(dev);
            await ctrl.DecreaseVolumeAsync(ammount);
            return Ok();
        }

        [HttpPut("{deviceId}/input")]
        public async Task<IActionResult> DecreaseVolume(string deviceId, InputType input)
        {
            var dev = await hifiRepository.GetByIdAsync(deviceId);
            if (null == dev)
            {
                return NotFound();
            }
            var ctrl = hifiControllerFactory.Get(dev);
            await ctrl.GoToInputAsync(input);
            return Ok();
        }
    }
}
