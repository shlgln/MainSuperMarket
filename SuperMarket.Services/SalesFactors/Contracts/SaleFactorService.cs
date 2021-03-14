using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.SalesFactors.Contracts
{
    public interface SaleFactorService: Service
    {
        Task AddSaleFactor(AddSalesFactorDto dto);

        Task<IList<GetSalesFactorDto>> GetAllSaleFactors();
    }
}
