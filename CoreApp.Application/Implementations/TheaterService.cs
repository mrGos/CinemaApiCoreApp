using CoreApp.Application.Interfaces;
using CoreApp.Data.Entities;
using CoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreApp.Application.Implementations
{
    public class TheaterService : ITheaterService
    {
        IRepository<Theater, int> _theaterRepository;
        public TheaterService(IRepository<Theater, int> theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }
        public List<Theater> GetAllTheater()
        {
            return _theaterRepository.FindAll(x => x.ParentId == null).ToList();
        }
    }
}
