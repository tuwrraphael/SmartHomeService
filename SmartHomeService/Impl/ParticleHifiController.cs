using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SmartHomeService.Models;
using SmartHomeService.Services;

namespace SmartHomeService.Impl
{
    internal class ParticleHifiController : IHifiController
    {
        private HifiDevice device;
        private ParticleConfig options;

        public ParticleHifiController(HifiDevice device, IOptions<ParticleConfig> opts)
        {
            this.device = device;
            options = opts.Value;
        }

        private async Task InvokeAsync(string command, string parameter)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", options.AccessToken);
            var result = await client.PostAsync($"https://api.particle.io/v1/devices/{device.CloudDeviceId}/{command}?arg={parameter}",
                new StringContent($"{{\"arg\": \"{parameter}\"}}", Encoding.UTF8, "application/json"));
            if (HttpStatusCode.OK != result.StatusCode)
            {
                throw new DeviceNotReachableException();
            }
        }

        public async Task DecreaseVolumeAsync(uint ammount)
        {
            await InvokeAsync("control", $"d{ammount}");
        }

        public async Task GoToInputAsync(InputType input)
        {
            switch (input)
            {
                case InputType.Video:
                    await InvokeAsync("control", $"v");
                    break;
                case InputType.CD:
                    await InvokeAsync("control", $"c");
                    break;
                default: break;
            }

        }

        public async Task IncreaseVolumeAsync(uint ammount)
        {
            await InvokeAsync("control", $"i{ammount}");
        }
    }
}