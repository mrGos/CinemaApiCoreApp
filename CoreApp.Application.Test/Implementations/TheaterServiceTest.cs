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
    public class TheaterServiceTest
    {
        private readonly Mock<IRepository<Theater, int>> _mockTheaterRepository;
        private IMapper _mapper;
        public TheaterServiceTest()
        {
            _mockTheaterRepository = new Mock<IRepository<Theater, int>>();
            _mapper = MapperFactory.Create();
        }
        [Fact]
        public void GetAllTheater_ValidQuery_SuccessResult()
        {
            var theaters = new List<Theater>
            {
                new Theater{Id=1,Name="",Status=Data.Enums.Status.NowShowing},
                new Theater{Id=2,Name="",Status=Data.Enums.Status.NowShowing},
                new Theater{Id=3,Name="",Status=Data.Enums.Status.NowShowing}
            };

            _mockTheaterRepository.Setup(x => x.FindAll(It.IsAny<Expression<Func<Theater, bool>>>())).Returns(theaters.AsQueryable());

            var theaterService = new TheaterService(_mockTheaterRepository.Object);

            var result = theaterService.GetAllTheater();
            Assert.Equal(3, result.Count);
        }
        [Fact]
        public void GetAllTheaterChild_ValidQuery_SuccessResult()
        {
            var theaters = new List<Theater>
            {
                new Theater{Id=1,Name="",Status=Data.Enums.Status.NowShowing,ParentId=1},
                new Theater{Id=2,Name="",Status=Data.Enums.Status.NowShowing,ParentId=1},
                new Theater{Id=3,Name="",Status=Data.Enums.Status.NowShowing,ParentId=1}
            };

            _mockTheaterRepository.Setup(x => x.FindAll(It.IsAny<Expression<Func<Theater, bool>>>())).Returns(theaters.AsQueryable());

            var theaterService = new TheaterService(_mockTheaterRepository.Object);

            var result = theaterService.GetAllTheaterChild(1);
            Assert.Equal(3, result.Count());
        }
    }
}
