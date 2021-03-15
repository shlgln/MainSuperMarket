using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.Goods.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.EF.Goods
{
    public class EFGoodRepository : GoodRepository
    {
        private readonly EFDataContext _dataContext;

        public EFGoodRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddGood(Good good)
        {
             _dataContext.Goods.AddAsync(good);
        }

        public async Task<IList<GetGoodDto>> GetAllGoods()
        {
            return await  _dataContext.Goods.Select
                (_ => new GetGoodDto
                {
                    Code = _.Code,
                    CategoryId = _.CategoryId,
                    Title = _.Title,

                }).ToListAsync();
        }

        public async Task<Good> GetGoodByCode(string code)
        {
            return await _dataContext.Goods.FindAsync(code);
        }

        public async Task<Good> GetGoodById(int id)
        {
            return await _dataContext.Goods.FindAsync(id);
        }

        public bool IsGoodsExistsByCode(string code)
        {
            return _dataContext.Goods.Any(_ => _.Code == code);
        }

        public async Task<Good> ShowGoodInfo(int id)
        {
            return await _dataContext.Goods.FindAsync(id);
        }

        Task<IList<Good>> GoodRepository.GetAllGoods()
        {
            throw new System.NotImplementedException();
        }

    }
}
