using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.Goods.Contracts;
using SuperMarket.Services.SalesFactors.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.SalesFactors
{
    public class SaleFactorAppService : SaleFactorService
    {
        private readonly SaleFactorRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly GoodRepository _goodRepository;

        public SaleFactorAppService(SaleFactorRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Add(AddSalesFactorDto dto)
        {
            var good = _goodRepository.GetGoodByCode(dto.GoodCode);

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

            _repository.Add(salesFactor);

            _unitOfWork.Complete();
        }
         
        public IList<GetSalesFactorDto> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
