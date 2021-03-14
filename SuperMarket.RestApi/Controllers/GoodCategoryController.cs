using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.GoodCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.RestApi.Controllers
{
    [Route("api/good-category")]
    [ApiController]
    public class GoodCategoryController : ControllerBase
    {
        private readonly GoodCategoryService _service;
        public GoodCategoryController(GoodCategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddGoodCategory(string title)
        {
            _service.AddGoodCategory(title);
        }

        [HttpGet]
        public IList<GetGoodCategoryDto> GetAllGategories()
        {
            return _service.GetAllGategories();
        }

        [HttpDelete]
        public void DeleteGoodCategory(int id)
        {
            _service.DeleteGoodCategory(id);
        }

        [HttpPut]
        public void EditGoodCategoryInfo(int id, UpdateGoodCategoryDto dto)
        {
            _service.UpdateGoodCategory(id, dto);
        }
    }
}
