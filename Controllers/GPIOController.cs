using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;

namespace GPIOWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPIOController : ControllerBase
    {

        // GET: api/GPIO
        [HttpGet]
        public GPIO[] Get()
        {
            return GPIOArray.gpioArray;
        }

        // GET: api/GPIO/5
        [HttpGet("{id}")]
        public GPIO Get(int id)
        {
            return GPIOArray.gpioArray[id - 1];
        }

        // GET: api/GPIO/5/on
        [HttpGet("{id}/on", Name = "GPIOGetOn")]
        public GPIO GPIOGetOn(int id)
        {
            GPIOArray.gpioArray[id - 1].Value = 1;
            return GPIOArray.gpioArray[id - 1];
        }

        // GET: api/GPIO/5/off
        [HttpGet("{id}/off", Name = "GPIOGetOff")]
        public GPIO GPIOGetOff(int id)
        {
            GPIOArray.gpioArray[id - 1].Value = 0;
            return GPIOArray.gpioArray[id - 1];
        }

    }
}
