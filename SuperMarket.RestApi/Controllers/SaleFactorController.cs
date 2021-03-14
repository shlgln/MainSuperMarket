using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.SalesFactors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.RestApi.Controllers
{
    [Route("api/sale-factors")]
    [ApiController]
    public class SaleFactorController : ControllerBase
    {
        private readonly SaleFactorService _service;
        public SaleFactorController(SaleFactorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddSaleFactor(AddSalesFactorDto dto)
        {
            await _service.AddSaleFactor(dto);
        }

        [HttpGet]
        public async Task<IList<GetSalesFactorDto>>  GetSalesFactors()
        {
            var salefactors = await _service.GetAllSaleFactors();
            return salefactors;
        }
    }
}
