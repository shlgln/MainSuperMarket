using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.GoodEntries.Contracts
{
    public interface GoodEntryRepository: Repository
    {
        void AddGoodEntry(GoodEntry goodEntry);
        Task<IList<GetGoodEntryDto>> GetAllGoodEntry();
    }
}
