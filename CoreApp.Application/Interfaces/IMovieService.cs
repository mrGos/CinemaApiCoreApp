using CoreApp.Data.Entities;
using CoreApp.Data.Enums;
using CoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CoreApp.Application.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAllMovie(int statusType);
        PagedResult<Movie> GetMovieByPaging(string keyword, int page, int pageSize);
        List<Movie> GetTopMovieByCondition(int top, int status);
    }
}
