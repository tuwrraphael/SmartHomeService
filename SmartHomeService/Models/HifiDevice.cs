using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeService.Models
{
    public class HifiDevice
    {
        public string DeviceId { get; set; }
        [JsonIgnore]
        public string CloudDeviceId { get; set; }
        public string Name { get; set; }
        public DeviceType DeviceType { get; set; }
        public InputType[] SupportedInputs {get; set;}
}
}
