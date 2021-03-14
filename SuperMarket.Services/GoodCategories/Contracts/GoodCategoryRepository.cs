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
        Task AddGoodCategory(GoodCategory goodCategory);
        Task<IList<GetGoodCategoryDto>> GetAllGategories();
        Task DeleteGoodCategory(int id);
        bool GoodCaterotyDublicate(string Title);
        Task<GoodCategory> GetCategory(int id);
    }
}
