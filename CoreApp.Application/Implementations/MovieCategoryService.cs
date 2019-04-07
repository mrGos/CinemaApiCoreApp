using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Application.Interfaces;
using CoreApp.Application.ViewModels.Movie;
using CoreApp.Data.Entities;
using CoreApp.Data.Enums;
using CoreApp.Infrastructure.Interfaces;
using CoreApp.Application.ViewModels.MovieCategory;

namespace CoreApp.Application.Implementation
{
    public class MovieCategoryService : IMovieCategoryService
    {
        private IRepository<MovieCategory, int> _movieCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public MovieCategoryService(IRepository<MovieCategory, int> movieCategoryRepository,
            IUnitOfWork unitOfWork)
        {
            _movieCategoryRepository = movieCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public MovieCategoryViewModel Add(MovieCategoryViewModel movieCategoryVm)
        {
            var movieCategory = Mapper.Map<MovieCategoryViewModel, MovieCategory>(movieCategoryVm);
            _movieCategoryRepository.Add(movieCategory);
            return movieCategoryVm;
        }

        public void Delete(int id)
        {
            _movieCategoryRepository.Remove(id);
        }

        public List<MovieCategoryViewModel> GetAll()
        {
            return _movieCategoryRepository.FindAll().OrderBy(x => x.ParentId)
                 .ProjectTo<MovieCategoryViewModel>().ToList();
        }

        public List<MovieCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _movieCategoryRepository.FindAll(x => x.Name.Contains(keyword)
                || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId).ProjectTo<MovieCategoryViewModel>().ToList();
            else
                return _movieCategoryRepository.FindAll().OrderBy(x => x.ParentId)
                    .ProjectTo<MovieCategoryViewModel>()
                    .ToList();
        }

        public List<MovieCategoryViewModel> GetAllByParentId(int parentId)
        {
            return _movieCategoryRepository.FindAll(x => x.Status == Status.Active
            && x.ParentId == parentId)
             .ProjectTo<MovieCategoryViewModel>()
             .ToList();
        }

        public MovieCategoryViewModel GetById(int id)
        {
            return Mapper.Map<MovieCategory, MovieCategoryViewModel>(_movieCategoryRepository.FindById(id));
        }

        public List<MovieCategoryViewModel> GetHomeCategories(int top)
        {
            var query = _movieCategoryRepository
                .FindAll(x => x.HomeFlag == true, c => c.Movies)
                  .OrderBy(x => x.HomeOrder)
                  .Take(top).ProjectTo<MovieCategoryViewModel>();

            var categories = query.ToList();
            foreach (var category in categories)
            {
                //category.movies = _movieRepository
                //    .FindAll(x => x.HotFlag == true && x.CategoryId == category.Id)
                //    .OrderByDescending(x => x.DateCreated)
                //    .Take(5)
                //    .ProjectTo<movieViewModel>().ToList();
            }
            return categories;
        }

        public void ReOrder(int sourceId, int targetId)
        {
            var source = _movieCategoryRepository.FindById(sourceId);
            var target = _movieCategoryRepository.FindById(targetId);
            int tempOrder = source.SortOrder;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _movieCategoryRepository.Update(source);
            _movieCategoryRepository.Update(target);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(MovieCategoryViewModel movieCategoryVm)
        {
            var movieCategory = Mapper.Map<MovieCategoryViewModel, MovieCategory>(movieCategoryVm);
            _movieCategoryRepository.Update(movieCategory);
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            var sourceCategory = _movieCategoryRepository.FindById(sourceId);
            sourceCategory.ParentId = targetId;
            _movieCategoryRepository.Update(sourceCategory);

            //Get all sibling
            var sibling = _movieCategoryRepository.FindAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _movieCategoryRepository.Update(child);
            }
        }
    }
}