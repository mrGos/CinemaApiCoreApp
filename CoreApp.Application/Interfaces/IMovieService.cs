using CoreApp.Application.ViewModels.Movie;
using CoreApp.Data.Entities;
using CoreApp.Data.Enums;
using CoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Application.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAllMovie(int statusType);
        PagedResult<Movie> GetMoviesByPaging(string keyword, int page, int pageSize, Status status);
        List<Movie> GetTopMovieByCondition(int top, int status);
        MovieViewModel GetMovieById(int id);
        MovieViewModel CreateOrEdit(MovieViewModel input);
    }
}
