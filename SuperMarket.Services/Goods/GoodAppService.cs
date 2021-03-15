using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.Goods.Contracts;
using SuperMarket.Services.Goods.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public  int AddGood(AddGoodDto dto)
        {
            if (IsGoodCode(dto.Code))
            {
                throw new GoodCodeCantBeDuplicateException();
            }

            var good = new Good
            {
                Title = dto.Title,
                Code = dto.Code,
                MinimumStack = dto.MinimumStack,
                WareHouseId = dto.WareHouseId,
                CategoryId = dto.CategoryId,
                Price = dto.Price
            };

             _repository.AddGood(good);
 
            _unitOfWork.Complete();
            return good.Id;

        }
        public bool IsGoodCode(string code)
        {
            return _repository.IsGoodsExistsByCode(code);
        }

        public async Task<Good> GetGoodByCode(string code)
        {
            return await _repository.GetGoodByCode(code);
        }

        public async Task<Good> GetGoodById(int id)
        {
            return await _repository.GetGoodById(id);
        }

        public bool IsGoodsExistsByCode(string code)
        {
            return _repository.IsGoodsExistsByCode(code);
        }

        public async Task EditGoodInfo(UpdateGoodDto dto, int id)
        {
            var good = await GetGoodById(id);
            if (good == null)
                throw new GoodNotFoundById();

            good.Title = dto.Title;
            good.WareHouseId = dto.WareHouseId;
            good.MinimumStack = dto.MinimumStack;
            good.Price = dto.Price;
            good.CategoryId = dto.CategoryId;

             _unitOfWork.Complete();
        }

        public async Task<Good> ShowGoodInfo(int id)
        {
            return await  _repository.ShowGoodInfo(id);
        }

        async Task<IList<Good>> GoodService.GetAllGoods()
        {
            return await _repository.GetAllGoods();
        }
    }
}
