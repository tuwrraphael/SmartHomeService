using SmartHomeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeService.Services
{
    public interface IHifiControllerFactory
    {
        IHifiController Get(HifiDevice device);
    }
}
