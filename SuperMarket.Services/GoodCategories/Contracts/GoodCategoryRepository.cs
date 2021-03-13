using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.GoodCategories.Contracts
{
    public interface GoodCategoryRepository: Repository
    {
        void AddGoodCategory(GoodCategory goodCategory);
        IList<GetGoodCategoryDto> GetAllGategories();
        void DeleteGoodCategory(int id);
        bool GoodCaterotyDublicate(string Title);
        GoodCategory GetCategory(int id);
    }
}
