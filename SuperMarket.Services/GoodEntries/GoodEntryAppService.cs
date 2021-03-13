using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.GoodEntries.Contracts;
using SuperMarket.Services.GoodEntries.Exceptions;
using SuperMarket.Services.Goods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.GoodEntries
{
    public class GoodEntryAppService : GoodEntryService
    {
        private readonly GoodEntryRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly GoodRepository _goodRepository;

        public GoodEntryAppService(GoodEntryRepository repository, UnitOfWork unitOfWork, GoodRepository goodRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _goodRepository = goodRepository;
        }
        public void AddGoodEntry(AddGoodEntryDto dto)
        {
            var good = _goodRepository.GetGoodByCode(dto.GoodCode);

            if (good == null)
                throw new AddGoodEntryException();

            var goodEntry = new GoodEntry
            {
                GoodCount = dto.GoodCount,
                EntryDate = DateTime.Now,
                GoodCode = dto.GoodCode
            };
            good.Count += dto.GoodCount;
            _repository.AddGoodEntry(goodEntry);
            _unitOfWork.Complete();
        }

        public IList<GetGoodEntryDto> GetAllGoodEntry()
        {
            return _repository.GetAllGoodEntry();
        }
    }
}
