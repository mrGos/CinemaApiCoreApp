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
using System.Threading.Tasks;

namespace CoreApp.Application.Implementations
{
    public class MovieService : IMovieService
    {
        IRepository<Movie, int> _movieRepository;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public MovieService(IRepository<Movie, int> movieRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public MovieViewModel CreateOrEdit(MovieViewModel input)
        {
            var obj = _mapper.Map<Movie>(input);

            if (input.Id == 0)
            {
                _movieRepository.Add(obj);
            }
            else
            {
                _movieRepository.Update(obj);
            }
            _unitOfWork.Commit();
            return input;
        }

        public List<Movie> GetAllMovie(int statusType)
        {
            return _movieRepository.FindAll(x => (int)x.Status == (int)(statusType)).ToList();
        }

        public MovieViewModel GetMovieById(int id)
        {
            return _mapper.Map<Movie, MovieViewModel>(_movieRepository.FindById(id));
        }

        public PagedResult<Movie> GetMoviesByPaging(string keyword = "", int page = 1, int pageSize = 3, Status status = Status.InActive)
        {
            var query = _movieRepository.FindAll(x => x.Status == status);
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
