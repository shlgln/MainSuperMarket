using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.SalesFactors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.RestApi.Controllers
{
    [Route("api/sale-factor")]
    [ApiController]
    public class SaleFactorController : ControllerBase
    {
        private readonly SaleFactorService _service;
        public SaleFactorController(SaleFactorService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddSaleFactor(AddSalesFactorDto dto)
        {
            _service.AddSaleFactor(dto);
        }

        [HttpGet]
        public IList<GetSalesFactorDto> GetSalesFactors()
        {
            return _service.GetAllSaleFactors();
        }
    }
}
