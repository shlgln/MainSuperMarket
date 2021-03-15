using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.SalesFactors.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.EF.SalesFactors
{
    public class EFSaleFactorRepository : SaleFactorRepository
    {
        private readonly EFDataContext _dataContext;
        public EFSaleFactorRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddSaleFactor(SaleFactors salesFactors)
        {
             _dataContext.SaleFactors.AddAsync(salesFactors);
        }

        public async Task<IList<GetSalesFactorDto>> GetAllSaleFactors()
        {
            var query = from s in _dataContext.SaleFactors
                        join g in _dataContext.Goods on s.GoodId equals g.Id
                        select new GetSalesFactorDto
                        {
                            Id = s.Id,
                            Title = g.Title,
                            GoodId = s.Id,
                            GoodCount = s.GoodCount,
                            SaleDate = s.SalesDate,
                            TotalAmount = s.GoodCount * g.Price
                        };
            return await query.ToListAsync();
        }
    }
}
