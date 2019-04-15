using CoreApp.Application.ViewModels.Movie;
using CoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Application.Interfaces
{
    public interface IShowTimeService
    {
        List<ShowTimeViewModel> GetAllShowTimeByMovieTheater(int movieId, int theaterId);
    }
}
