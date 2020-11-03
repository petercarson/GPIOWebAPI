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

        // GET: api/Heating
        [HttpGet]
        public GPIO[] Get()
        {
            return GPIOArray.gpioArray;
        }

        // GET: api/Heating/5
        [HttpGet("{id}", Name = "Get")]
        public GPIO Get(int id)
        {
            return GPIOArray.gpioArray[id - 1];
        }

        // PUT: api/Heating/5
        [HttpPut("{id}")]
        public void Put(int id, int value)
        {
            GPIOArray.gpioArray[id - 1].Value = value;
        }

    }
}
