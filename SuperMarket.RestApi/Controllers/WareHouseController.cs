using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.WareHouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.RestApi.Controllers
{
    [Route("api/ware-houses")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
        private readonly WareHouseAppService _service;

        public WareHouseController(WareHouseAppService service)
        {
            _service = service;
        }

    }
}
