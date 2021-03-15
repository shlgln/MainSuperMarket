using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.SalesFactors.Contracts
{
    public interface SaleFactorRepository: Repository
    {
        void AddSaleFactor(SaleFactors salesFactors);

        Task<IList<GetSalesFactorDto>> GetAllSaleFactors();
    }
}
