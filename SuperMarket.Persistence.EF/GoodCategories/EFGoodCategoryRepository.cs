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
        private readonly DbSet<GoodCategory> _set;
        public EFGoodCategoryRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
            _set = _dataContext.GoodCategories;
        }
        public async Task AddGoodCategory(GoodCategory goodCategory)
        {
            await _dataContext.AddAsync(goodCategory);
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
        public async Task DeleteGoodCategory(int id)
        {
            var goodCategory = await GetCategory(id);

             _dataContext.GoodCategories.Remove(goodCategory);
        }
        public async Task<GoodCategory> GetCategory(int id)
        {
            return await _dataContext.GoodCategories.FindAsync(id);
        }
    }
}
