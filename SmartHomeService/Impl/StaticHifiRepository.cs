using Microsoft.Extensions.Options;
using SmartHomeService.Models;
using SmartHomeService.Services;
using System.Threading.Tasks;

namespace SmartHomeService.Impl
{
    public class StaticHifiRepository : IHifiRepository
    {
        private ParticleConfig options;

        public StaticHifiRepository(IOptions<ParticleConfig> opts)
        {
            options = opts.Value;
        }

        private HifiDevice Get() {
            return new HifiDevice { DeviceId = "1", CloudDeviceId = options.StereoDeviceId, DeviceType = DeviceType.Particle, Name = "Stereo", SupportedInputs = new[] { InputType.CD, InputType.Video } };
        }

        public async Task<HifiDevice[]> GetAllAsync()
        {
            return new[] { Get() };
        }

        public async Task<HifiDevice> GetByIdAsync(string deviceId)
        {
            var dev = Get();
            if (deviceId == dev.DeviceId)
            {
                return dev;
            }
            return null;
        }
    }
}
