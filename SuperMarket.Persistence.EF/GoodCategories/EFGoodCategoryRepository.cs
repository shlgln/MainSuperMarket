using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.GoodCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.EF.GoodCategories
{
    public class EFGoodCategoryRepository : GoodCategoryRepository
    {

        private readonly EFDataContext _dataContext;
        public EFGoodCategoryRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddGoodCategory(GoodCategory goodCategory)
        {
             _dataContext.GoodCategories.AddAsync(goodCategory);
        }
        public bool GoodCaterotyDublicate(string Title)
        {
            return _dataContext.GoodCategories.Any(_ => _.Title == Title);
        }

        public async Task<IList<GetGoodCategoryDto>> GetAllGategories()
        {
            var query = from p in _dataContext.GoodCategories
                        select new GetGoodCategoryDto
                        {
                            Id = p.Id,
                            Title = p.Title,
                            goods = p.Goods.Select(m => m.Title).ToList(),
                        };
            return await query.ToListAsync();
        }
        public void DeleteGoodCategory(GoodCategory cat)
        {
            _dataContext.GoodCategories.Remove(cat);
        }
        public async Task<GoodCategory> GetCategory(int id)
        {
            return await _dataContext.GoodCategories.FindAsync(id);
        }
    }
}
