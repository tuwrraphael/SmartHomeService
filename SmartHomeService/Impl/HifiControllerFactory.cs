using Microsoft.Extensions.Options;
using SmartHomeService.Models;
using SmartHomeService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeService.Impl
{
    public class HifiControllerFactory : IHifiControllerFactory

    {
        private IOptions<ParticleConfig> opts;

        public HifiControllerFactory(IOptions<ParticleConfig> opts)
        {
            this.opts = opts;
        }
        public IHifiController Get(HifiDevice device)
        {
            if(device.DeviceType != DeviceType.Particle)
            {
                throw new NotSupportedException();
            }
            return new ParticleHifiController(device, opts);
        }
    }
}
