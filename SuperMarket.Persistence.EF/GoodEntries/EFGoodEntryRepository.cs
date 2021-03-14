using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.GoodEntries.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.EF.GoodEntries
{
    public class EFGoodEntryRepository : GoodEntryRepository
    {
        private readonly EFDataContext _dataContext;
        private readonly DbSet<GoodEntry> _set;

        public EFGoodEntryRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
            _set = _dataContext.goodEntries;
        }
        public async Task AddGoodEntry(GoodEntry goodEntry)
        {
            await _dataContext.AddAsync(goodEntry);
        }

        public async Task<IList<GetGoodEntryDto>> GetAllGoodEntry()
        {
            var query = from a in _dataContext.goodEntries
                        join p in _dataContext.Goods on a.GoodCode equals p.Code
                        join c in _dataContext.GoodCategories on p.CategoryId equals c.Id
                        select new GetGoodEntryDto
                        {
                            Id = a.Id,
                            GoodTitle = p.Title,
                            CategoryTitle = c.Title,
                            GoodCode = p.Code
                        };

            return await query.ToListAsync();
        }
    }
}
