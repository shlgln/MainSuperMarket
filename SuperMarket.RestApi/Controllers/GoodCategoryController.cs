using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.GoodCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.RestApi.Controllers
{
    [Route("api/good-categories")]
    [ApiController]
    public class GoodCategoryController : ControllerBase
    {
        private readonly GoodCategoryService _service;
        public GoodCategoryController(GoodCategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddGoodCategory([FromBody]string title)
        {
            await _service.AddGoodCategory(title);
        }

        [HttpGet]
        public async Task<IList<GetGoodCategoryDto>> GetAllGategories()
        {
            var goodcategories = await _service.GetAllGategories();
            return goodcategories;
        }

        [HttpDelete]
        public async Task DeleteGoodCategory(int id)
        {
           await _service.DeleteGoodCategory(id);
        }

        [HttpPut]
        public async Task EditGoodCategoryInfo(int id, UpdateGoodCategoryDto dto)
        {
            await _service.UpdateGoodCategory(id, dto);
        }
    }
}
