using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.GoodCategories.Contracts;
using SuperMarket.Services.GoodCategories.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperMarket.Services.GoodCategories
{
    public class GoodCategoryAppService : GoodCategoryService
    {
        private readonly GoodCategoryRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public GoodCategoryAppService(GoodCategoryRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddGoodCategory(string Title)
        {
            if (GoodCaterotyDublicate(Title))
            {
                throw new GoodCategoryTitleCantBeDuplicated();
            }

            var goodCategory = new GoodCategory
            {
                Title = Title
            };

            await _repository.AddGoodCategory(goodCategory);
            await _unitOfWork.Complete();
        }
        private bool GoodCaterotyDublicate(string Title)
        {
            return _repository.GoodCaterotyDublicate(Title);
        }

        public async Task DeleteGoodCategory(int id)
        {
            var goodCategory = GetCategory(id);
            if (goodCategory == null)
                throw new Exception();

            await _repository.DeleteGoodCategory(id);
            await _unitOfWork.Complete();
        }

        public async Task<IList<GetGoodCategoryDto>> GetAllGategories()
        {
            return await _repository.GetAllGategories();
        }

        public async Task UpdateGoodCategory(int id, UpdateGoodCategoryDto dto)
        {
            var category = await GetCategory(id);
            if (category == null)
                throw new Exception();

            category.Title = dto.Title;

           await _unitOfWork.Complete();
        }
        private async Task<GoodCategory> GetCategory(int id)
        {
            return await _repository.GetCategory(id);
        }
    }
}
