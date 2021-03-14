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
        private readonly DbSet<Good> _set;

        public EFGoodRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
            _set = _dataContext.Goods;
        }

        public async Task AddGood(Good good)
        {
            await _dataContext.AddAsync(good);
        }

        public async Task<IList<GetGoodDto>> GetAllGoods()
        {
            return await  _dataContext.Goods.Select
                (_ => new GetGoodDto
                {
                    Code = _.Code,
                    CategoryId = _.CategoryId,
                    Title = _.Title,
                    Status = _.Status,

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
    }
}
