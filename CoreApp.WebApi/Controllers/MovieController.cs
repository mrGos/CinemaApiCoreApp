using CoreApp.Application.Interfaces;
using CoreApp.Data.Entities;
using CoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.WebApi.Controllers
{
    public class MovieController : ApiController
    {
        IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [Route("getallmoviespaging")]
        public PagedResult<Movie> GetMovieByPaging(string keyword, int page, int size = 4)
        {
            return _movieService.GetMovieByPaging(keyword, page, size);
        }
        [HttpGet]
        [Route("getallmovies")]
        public List<Movie> GetAllMovie(int statusType)
        {
            return _movieService.GetAllMovie(statusType);
        }
        [HttpGet]
        [Route("getmoviesbycondition")]
        public List<Movie> GetTopMovieByCondition(int top, int statusType)
        {
            return _movieService.GetTopMovieByCondition(top, statusType);

        }
    }
}
