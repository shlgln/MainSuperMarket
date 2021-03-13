using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.GoodCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarket.Persistence.EF.GoodCategories
{
    class EFGoodCategoryRepository : GoodCategoryRepository
    {
        private readonly EFDataContext _dataContext;
        private readonly DbSet<GoodCategory> _set;
        public EFGoodCategoryRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
            _set = _dataContext.GoodCategories;
        }
        public void AddGoodCategory(GoodCategory goodCategory)
        {
            _dataContext.Add(goodCategory);
        }
        public bool GoodCaterotyDublicate(string Title)
        {
            return _dataContext.GoodCategories.Any(_ => _.Title == Title);
        }

        public IList<GetGoodCategoryDto> GetAllGategories()
        {
            var query = from p in _dataContext.GoodCategories
                        select new GetGoodCategoryDto
                        {
                            Id = p.Id,
                            Title = p.Title,
                            goods = p.Goods.Select(m => m.Title).ToList(),
                        };
            return query.ToList();
        }
        public void DeleteGoodCategory(int id)
        {
            var goodCategory = GetCategory(id);

            _dataContext.GoodCategories.Remove(goodCategory);
        }
        public GoodCategory GetCategory(int id)
        {
            return _dataContext.GoodCategories.Find(id);
        }
    }
}
