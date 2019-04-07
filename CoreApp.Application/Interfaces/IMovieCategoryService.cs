using System;
using System.Collections.Generic;
using System.Text;
using CoreApp.Application.ViewModels.Movie;
using CoreApp.Application.ViewModels.MovieCategory;

namespace CoreApp.Application.Interfaces
{
    public interface IMovieCategoryService
    {
        MovieCategoryViewModel Add(MovieCategoryViewModel productCategoryVm);

        void Update(MovieCategoryViewModel productCategoryVm);

        void Delete(int id);

        List<MovieCategoryViewModel> GetAll();

        List<MovieCategoryViewModel> GetAll(string keyword);

        List<MovieCategoryViewModel> GetAllByParentId(int parentId);

        MovieCategoryViewModel GetById(int id);

        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOrder(int sourceId, int targetId);

        List<MovieCategoryViewModel> GetHomeCategories(int top);




        void Save();
    }
}
