using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public void Add(AddGoodDto dto)
        {
            _service.AddGood(dto);
        }

        [HttpGet]
        public IList<GetGoodDto> Get()
        {
            return _service.GetAllGoods();
        }
    }

}
