using AutoMapper;
using CoreApp.Application.Implementations;
using CoreApp.Data.Entities;
using CoreApp.Infrastructure.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace CoreApp.Application.Test.Implementations
{
    public class ShowTimeServiceTest
    {
        private readonly Mock<IRepository<MovieTheater, int>> _mockMovieTheaterRepository;
        private readonly Mock<IRepository<ShowTime, int>> _mockShowTimeTheaterRepository;
        private IMapper _mapper;
        public ShowTimeServiceTest()
        {
            _mockMovieTheaterRepository = new Mock<IRepository<MovieTheater, int>>();
            _mockShowTimeTheaterRepository = new Mock<IRepository<ShowTime, int>>();
            _mapper = MapperFactory.Create();
        }

        [Fact]
        public void GetAllShowTimeByMovieTheater_ValidQuery_SuccessResult()
        {
            var showtimes = new List<ShowTime>
            {
                new ShowTime{Id=1,MovieTheaterId=1,Status=Data.Enums.Status.NowShowing,DateCreated=DateTime.Now,DateModified=DateTime.Now,DateShowing=DateTime.Now},
                new ShowTime{Id=2,MovieTheaterId=1,Status=Data.Enums.Status.NowShowing,DateCreated=DateTime.Now,DateModified=DateTime.Now,DateShowing=DateTime.Now},
                new ShowTime{Id=3,MovieTheaterId=1,Status=Data.Enums.Status.NowShowing,DateCreated=DateTime.Now,DateModified=DateTime.Now,DateShowing=DateTime.Now}
            };

            _mockMovieTheaterRepository.Setup(x => x.FindSingle(It.IsAny<Expression<Func<MovieTheater, bool>>>()))
                .Returns(new MovieTheater { Id = 1, MovieId = 1, TheaterId = 1 });

            _mockShowTimeTheaterRepository.Setup(x => x.FindAll(It.IsAny<Expression<Func<ShowTime, bool>>>()))
                .Returns(showtimes.AsQueryable());

            var showtimeService = new ShowTimeService(_mockMovieTheaterRepository.Object, _mockShowTimeTheaterRepository.Object, _mapper);

            var result = showtimeService.GetAllShowTimeByMovieTheater(1, 1);

            Assert.Equal(3, result.Count());
        }
    }
}
