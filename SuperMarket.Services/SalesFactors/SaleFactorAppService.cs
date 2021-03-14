using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.Goods.Contracts;
using SuperMarket.Services.SalesFactors.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.SalesFactors
{
    public class SaleFactorAppService : SaleFactorService
    {
        private readonly SaleFactorRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly GoodRepository _goodRepository;

        public SaleFactorAppService(SaleFactorRepository repository, UnitOfWork unitOfWork, GoodRepository goodRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _goodRepository = goodRepository;
        }
        public async Task AddSaleFactor(AddSalesFactorDto dto)
        {
            var good = await _goodRepository.GetGoodByCode(dto.GoodCode);

            if (good == null)
                throw new Exception();

            if (good.Count < dto.GoodCount)
                throw new Exception();

            var salesFactor = new SaleFactors
            {
                GoodCount = dto.GoodCount,
                SalesDate = DateTime.Now,
                GoodCode = dto.GoodCode
            };
            good.Count -= dto.GoodCount;

            await _repository.AddSaleFactor(salesFactor);

            await _unitOfWork.Complete();
        }
         
        public async Task<IList<GetSalesFactorDto>> GetAllSaleFactors()
        {
            return await _repository.GetAllSaleFactors();
        }
    }
}
