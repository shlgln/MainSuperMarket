using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.GoodEntries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.RestApi.Controllers
{
    [Route("api/good-entries")]
    [ApiController]
    public class GoodEntryController : ControllerBase
    {
        private readonly GoodEntryService _service;
        public GoodEntryController(GoodEntryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddGoodEntry(AddGoodEntryDto dto)
        {
            await _service.AddGoodEntry(dto);
        }

        [HttpGet]
        public async Task<IList<GetGoodEntryDto>> GetGoodEntries()
        {
            var goodEntries = await _service.GetAllGoodEntry();
            return goodEntries;
        }
    }
}
