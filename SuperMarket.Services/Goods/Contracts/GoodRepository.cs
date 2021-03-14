using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.Goods.Contracts
{
    public interface GoodRepository:Repository
    {
        void AddGood(Good good);
        List<GetGoodDto> GetAllGoods();
        bool IsGoodsExistsByCode(string code);
        Good GetGoodByCode(string code);
        Good GetGoodById(int id);
        Good ShowGoodInfo(int id);
    }
}
