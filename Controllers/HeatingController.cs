using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPIOWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeatingController : ControllerBase
    {
        // GET: api/Heating
        [HttpGet]
        public Heating[] Get()
        {
            return HeatingArray.heatingArray;
        }

        // GET: api/Heating/5
        [HttpGet("{id}")]
        public Heating Get(int id)
        {
            return HeatingArray.heatingArray[id - 1];
        }

        // GET: api/Heating/5/on
        [HttpGet("{id}/on", Name = "HeatingGetOn")]
        public Heating HeatingGetOn(int id)
        {
            HeatingArray.heatingArray[id - 1].Enabled = true;
            return HeatingArray.heatingArray[id - 1];
        }

        // GET: api/Heating/5/off
        [HttpGet("{id}/off", Name = "HeatingGetOff")]
        public Heating HeatingGetOff(int id)
        {
            HeatingArray.heatingArray[id - 1].Enabled = false;
            return HeatingArray.heatingArray[id - 1];
        }
    }
}
