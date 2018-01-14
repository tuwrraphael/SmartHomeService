using SmartHomeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeService.Services
{
    public interface IHifiRepository
    {
       Task<HifiDevice[]> GetAllAsync();

        Task<HifiDevice> GetByIdAsync(string deviceId);
    }
}
