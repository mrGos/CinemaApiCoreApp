using CoreApp.Application.Interfaces;
using CoreApp.Application.ViewModels.Movie;
using CoreApp.Data.Entities;
using CoreApp.Data.Enums;
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
        public PagedResult<Movie> GetMovieByPaging(string keyword, int page, int pageSize, Status status)
        {
            return _movieService.GetMoviesByPaging(keyword, page, pageSize, status);
        }
        [HttpGet]
        [Route("searchmovie")]
        public PagedResult<Movie> SearchMovie(string keyword, int page, int pageSize)
        {
            return _movieService.SearchMovie(keyword, page, pageSize);
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
        [HttpGet]
        [Route("getmoviebyid")]
        public MovieViewModel GetMovieById(int id)
        {
            return _movieService.GetMovieById(id);
        }
        [HttpPost]
        [Route("createoredit")]
        public MovieViewModel CreateOrEdit(MovieViewModel input)
        {
            return _movieService.CreateOrEdit(input);
        }

    }
}
