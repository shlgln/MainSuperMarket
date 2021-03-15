using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.Goods.Contracts
{
    public interface GoodRepository
    {
        void AddGood(Good good);
        Task<IList<Good>> GetAllGoods();
        bool IsGoodsExistsByCode(string code);
        Task<Good> GetGoodByCode(string code);
        Task<Good> GetGoodById(int id);
        Task<Good> ShowGoodInfo(int id);
    }
}
