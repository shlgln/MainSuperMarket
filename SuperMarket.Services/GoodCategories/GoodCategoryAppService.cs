using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.GoodCategories.Contracts;
using SuperMarket.Services.GoodCategories.Exceptions;
using System;
using System.Collections.Generic;

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

        public void AddGoodCategory(string Title)
        {
            if (GoodCaterotyDublicate(Title))
            {
                throw new GoodCategoryTitleCantBeDuplicated();
            }

            var goodCategory = new GoodCategory
            {
                Title = Title
            };

            _repository.AddGoodCategory(goodCategory);
            _unitOfWork.Complete();
        }
        private bool GoodCaterotyDublicate(string Title)
        {
            return _repository.GoodCaterotyDublicate(Title);
        }

        public void DeleteGoodCategory(int id)
        {
            var goodCategory = GetCategory(id);
            if (goodCategory == null)
                throw new Exception();

            _repository.DeleteGoodCategory(id);
            _unitOfWork.Complete();
        }

        public IList<GetGoodCategoryDto> GetAllGategories()
        {
            return _repository.GetAllGategories();
        }

        public void UpdateGoodCategory(int id, UpdateGoodCategoryDto dto)
        {
            var category = GetCategory(id);
            if (category == null)
                throw new Exception();

            category.Title = dto.Title;

            _unitOfWork.Complete();
        }
        private GoodCategory GetCategory(int id)
        {
            return _repository.GetCategory(id);
        }
    }
}
