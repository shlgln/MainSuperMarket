using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.GoodCategories.Contracts
{
    public interface GoodCategoryService: Service
    {
        Task AddGoodCategory(string Title);
        Task<IList<GetGoodCategoryDto>> GetAllGategories();
        Task DeleteGoodCategory(int id);
        Task UpdateGoodCategory(int id, UpdateGoodCategoryDto dto);
    }
}
