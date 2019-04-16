using AutoMapper;
using CoreApp.Application.Interfaces;
using CoreApp.Application.ViewModels.Movie;
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
        IMapper _mapper;
        public MovieService(IRepository<Movie, int> movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public List<Movie> GetAllMovie(int statusType)
        {
            return _movieRepository.FindAll(x => (int)x.Status == (int)(statusType)).ToList();
        }

        public MovieViewModel GetMovieById(int id)
        {
            return _mapper.Map<Movie, MovieViewModel>(_movieRepository.FindById(id));
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
