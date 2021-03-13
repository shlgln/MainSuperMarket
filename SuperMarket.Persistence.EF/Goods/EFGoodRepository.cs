using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.Goods.Contracts;
using System.Collections.Generic;
using System.Linq;

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

        public void AddGood(Good good)
        {
            _dataContext.Add(good);
        }

        public List<GetGoodDto> GetAllGoods()
        {
            return _dataContext.Goods.Select
                (_ => new GetGoodDto
                {
                    Code = _.Code,
                    CategoryId = _.CategoryId,
                    Title = _.Title,
                    Status = _.Status,

                }).ToList();
        }

        public Good GetGoodByCode(string code)
        {
            return _dataContext.Goods.Find(code);
        }

        public Good GetGoodById(int id)
        {
            return _dataContext.Goods.Find(id);
        }

        public bool IsGoodsExistsByCode(string code)
        {
            return _dataContext.Goods.Any(_ => _.Code == code);
        }
    }
}
