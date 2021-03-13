using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.Goods.Contracts;
using SuperMarket.Services.Goods.Exceptions;
using System.Collections.Generic;

namespace SuperMarket.Services.Goods
{
    public class GoodAppService : GoodService
    {
        private readonly GoodRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public GoodAppService(GoodRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void AddGood(AddGoodDto dto)
        {
            if (IsGoodCode(dto.Code))
            {
                throw new GoodCodeCantBeDuplicateException();
            }

            var good = new Good
            {
                Title = dto.Title,
                Code = dto.Code,
                Count = 0,
                CategoryId = dto.CategoryId,
                Price = dto.Price
            };

            _repository.AddGood(good);

            _unitOfWork.Complete();

        }
        public bool IsGoodCode(string code)
        {
            return _repository.IsGoodsExistsByCode(code);
        }
    
        public Good GetGoodByCode(string code)
        {
            return _repository.GetGoodByCode(code);
        }

        public Good GetGoodById(int id)
        {
            return _repository.GetGoodById(id);
        }

        public bool IsGoodsExistsByCode(string code)
        {
            return _repository.IsGoodsExistsByCode(code);
        }

        List<GetGoodDto> GoodService.GetAllGoods()
        {
            return _repository.GetAllGoods();
        }
    }
}
