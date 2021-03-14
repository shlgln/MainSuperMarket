using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Entities;
using SuperMarket.Services.Goods.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.RestApi.Controllers
{
    [Route("api/good")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        private readonly GoodService _service;

        public GoodController(GoodService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Add(AddGoodDto dto)
        {
            await _service.AddGood(dto);
        }

        [HttpGet]
        public async Task<IList<GetGoodDto>> Get()
        {
            var goods = await _service.GetAllGoods();
            return goods;
        }

        [HttpGet("{id}")]
        public Task<Good> GetGoodInfoById(int id)
        {
            var good =  _service.ShowGoodInfo(id);
            return good;
        }

        //[HttpGet("by-name/{name}")]
        //public IActionResult getbyname(string name)
        //{
        //    return Ok("Ok");
        //}

        [HttpPut]
        public async Task Edit(UpdateGoodDto dto, int id)
        {
             await _service.EditGoodInfo(dto, id);
        }
    }

}
