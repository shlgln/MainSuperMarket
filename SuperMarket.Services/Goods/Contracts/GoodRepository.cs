using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.Goods.Contracts
{
    public interface GoodRepository:Repository
    {
        void AddGood(Good good);
        Task<IList<GetGoodDto>> GetAllGoods();
        bool IsGoodsExistsByCode(string code);
        Task<Good> GetGoodByCode(string code);
        Task<Good> GetGoodById(int id);
        Task<Good> ShowGoodInfo(int id);
    }
}
