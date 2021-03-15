using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.GoodCategories.Contracts
{
    public interface GoodCategoryRepository: Repository
    {
        void AddGoodCategory(GoodCategory goodCategory);
        Task<IList<GetGoodCategoryDto>> GetAllGategories();
        void DeleteGoodCategory(GoodCategory goodCategory);
        bool GoodCaterotyDublicate(string Title);
        Task<GoodCategory> GetCategory(int id);
    }
}
