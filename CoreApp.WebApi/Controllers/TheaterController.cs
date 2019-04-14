using CoreApp.Application.Interfaces;
using CoreApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.WebApi.Controllers
{
    public class TheaterController : ApiController
    {
        ITheaterService _theaterService;
        public TheaterController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        [HttpGet]
        [Route("getalltheaters")]
        public List<Theater> GetAllTheater()
        {
            return _theaterService.GetAllTheater();
        }
    }
}
