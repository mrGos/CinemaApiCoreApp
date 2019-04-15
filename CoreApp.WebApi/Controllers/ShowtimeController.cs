using CoreApp.Application.Interfaces;
using CoreApp.Application.ViewModels.Movie;
using CoreApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.WebApi.Controllers
{
    public class ShowtimeController : ApiController
    {
        IShowTimeService _showtimeService;
        public ShowtimeController(IShowTimeService showtimeService)
        {
            _showtimeService = showtimeService;
        }

        [HttpGet]
        [Route("getallshowtimesbymovietheater")]
        public List<ShowTimeViewModel> GetAllMovie(int movieId, int theaterId)
        {
            return _showtimeService.GetAllShowTimeByMovieTheater(movieId, theaterId);
        }
    }
}
