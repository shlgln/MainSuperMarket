using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.GoodCategories.Contracts
{
    public interface GoodCategoryService: Service
    {
        public void AddGoodCategory(string Title);
        public IList<GetGoodCategoryDto> GetAllGategories();
        public void DeleteGoodCategory(int id);
        public void UpdateGoodCategory(int id, UpdateGoodCategoryDto dto);
    }
}
