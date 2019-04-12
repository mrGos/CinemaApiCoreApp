using CoreApp.Application.Interfaces;
using CoreApp.Data.Entities;
using CoreApp.Data.Enums;
using CoreApp.Infrastructure.Interfaces;
using CoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoreApp.Application.Implementations
{
    public class MovieService : IMovieService
    {
        IRepository<Movie, int> _movieRepository;
        public MovieService(IRepository<Movie, int> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public List<Movie> GetAllMovie()
        {
            return _movieRepository.FindAll(x => x.Status == Status.NowShowing).ToList();
        }

        public PagedResult<Movie> GetMovieByPaging(string keyword, int page, int pageSize)
        {
            var query = _movieRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            var paginationSet = new PagedResult<Movie>()
            {
                Results = data.ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public List<Movie> GetTopMovieByCondition(int top, int status)
        {
            return _movieRepository.FindAll(x => (int)x.Status == (int)status)
                .OrderByDescending(x => x.DateCreated).Take(top).ToList();
        }
    }
}
