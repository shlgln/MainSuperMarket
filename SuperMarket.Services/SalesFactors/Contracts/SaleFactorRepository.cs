using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.SalesFactors.Contracts
{
    public interface SaleFactorRepository: Repository
    {
        public void Add(SaleFactors salesFactors);

        public IList<GetSalesFactorDto> GetAll();
    }
}
