using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperMarket.Services.Goods.Contracts
{
    public interface GoodService: Service
    {
        Task AddGood(AddGoodDto dto);
        Task<IList<GetGoodDto>> GetAllGoods();
        bool IsGoodsExistsByCode(string code);
        Task<Good> GetGoodByCode(string code);
        Task<Good> GetGoodById(int id);
        Task EditGoodInfo(UpdateGoodDto dto, int id);
        Task<Good> ShowGoodInfo(int id);
    }
}
