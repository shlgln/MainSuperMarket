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

        public EFGoodEntryRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddGoodEntry(GoodEntry goodEntry)
        {
             _dataContext.goodEntries.AddAsync(goodEntry);
        }

        public async Task<IList<GetGoodEntryDto>> GetAllGoodEntry()
        {
            var query = from a in _dataContext.goodEntries
                        join p in _dataContext.Goods on a.GoodId equals p.Id
                        join c in _dataContext.GoodCategories on p.CategoryId equals c.Id
                        select new GetGoodEntryDto
                        {
                            Id = a.Id,
                            GoodTitle = p.Title,
                            CategoryTitle = c.Title,
                            GoodId = p.Id,
                            TotalAmount = p.Price * a.GoodCount
                        };

            return await query.ToListAsync();
        }

    }
}
