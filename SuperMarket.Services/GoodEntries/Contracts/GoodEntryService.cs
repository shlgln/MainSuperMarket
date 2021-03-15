using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.GoodEntries.Contracts
{
    public interface GoodEntryService
    {
        Task AddGoodEntry(AddGoodEntryDto dto);
        Task<IList<GetGoodEntryDto>> GetAllGoodEntry();
    }
}
