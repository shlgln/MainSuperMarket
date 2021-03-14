using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.GoodEntries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.RestApi.Controllers
{
    [Route("api/good-entry")]
    [ApiController]
    public class GoodEntryController : ControllerBase
    {
        private readonly GoodEntryService _service;
        public GoodEntryController(GoodEntryService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddGoodEntry(AddGoodEntryDto dto)
        {
            _service.AddGoodEntry(dto);
        }

    }
}
