using AutoMapper.QueryableExtensions;
using CoreApp.Application.Interfaces;
using CoreApp.Application.ViewModels.Movie;
using CoreApp.Data.Entities;
using CoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreApp.Application.Implementations
{
    public class ShowTimeService : IShowTimeService
    {
        IRepository<MovieTheater, int> _movietheaterRepository;
        IRepository<ShowTime, int> _showtimeRepository;
        public ShowTimeService(IRepository<MovieTheater, int> movietheaterRepository, IRepository<ShowTime, int> showtimeRepository)
        {
            _movietheaterRepository = movietheaterRepository;
            _showtimeRepository = showtimeRepository;
        }
        public List<ShowTimeViewModel> GetAllShowTimeByMovieTheater(int movieId, int theaterId)
        {
            List<ShowTimeViewModel> showtimeList = new List<ShowTimeViewModel>();
            MovieTheater movietheaterItem = _movietheaterRepository.FindSingle(x => x.MovieId == movieId && x.TheaterId == theaterId && x.Movie.Status == Data.Enums.Status.NowShowing);
            if (movietheaterItem != null)
            {
                return _showtimeRepository.FindAll(x => x.MovieTheaterId == movietheaterItem.Id).OrderBy(x => x.TimeShowing).ProjectTo<ShowTimeViewModel>().ToList();
            }
            return showtimeList;
        }
    }
}
