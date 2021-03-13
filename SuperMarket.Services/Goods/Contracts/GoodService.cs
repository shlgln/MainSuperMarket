using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System.Collections.Generic;

namespace SuperMarket.Services.Goods.Contracts
{
    public interface GoodService: Service
    {
        void AddGood(AddGoodDto dto);
        List<GetGoodDto> GetAllGoods();
        bool IsGoodsExistsByCode(string code);
        Good GetGoodByCode(string code);
        Good GetGoodById(int id);
    }
}
