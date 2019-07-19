using AutoMapper;
using CoreApp.Application.AutoMapper;
using CoreApp.Application.Implementations;
using CoreApp.Application.ViewModels.Movie;
using CoreApp.Data.Entities;
using CoreApp.Data.Enums;
using CoreApp.Infrastructure.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoreApp.Application.Test.Implementations
{
    public class MovieServiceTest
    {
        private readonly Mock<IRepository<Movie, int>> _mockMovieRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private IMapper _mapper;

        public MovieServiceTest()
        {
            _mockMovieRepository = new Mock<IRepository<Movie, int>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mapper = MapperFactory.Create();
        }

        [Fact]
        public void CreateOrEdit_ValidInput_SuccessResult()
        {
            //var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new DomainToViewModelMappingProfile()));
            //var mapper = mockMapper.CreateMapper();

            var movieService = new MovieService(_mockMovieRepository.Object, _mockUnitOfWork.Object, _mapper);

            var movieObject = new MovieViewModel()
            {
                Id = 1,
                Name = "",
                Status = Data.Enums.Status.NowShowing
            };

            var result = movieService.CreateOrEdit(movieObject);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllMovie_ValidQuery_ResultSuccess()
        {
            var movies = new List<Movie>
            {
                new Movie{Id=1,Name="",Status=Data.Enums.Status.NowShowing},
                new Movie{Id=2,Name="",Status=Data.Enums.Status.NowShowing},
                new Movie{Id=3,Name="",Status=Data.Enums.Status.NowShowing}
            };

            _mockMovieRepository.Setup(x => x.FindAll(It.IsAny<Expression<Func<Movie, bool>>>())).Returns(movies.AsQueryable());

            var movieService = new MovieService(_mockMovieRepository.Object, _mockUnitOfWork.Object, _mapper);

            var result = movieService.GetAllMovie((int)Data.Enums.Status.NowShowing);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetMovieById_ValidQuery_ResultSuccess()
        {

            _mockMovieRepository.Setup(x => x.FindById(It.IsAny<int>()))
                .Returns(new Movie { Id = 1, Name = "test 1", Status = Status.Active });

            var movieService = new MovieService(_mockMovieRepository.Object, _mockUnitOfWork.Object, _mapper);

            var result = movieService.GetMovieById(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetMoviesByPaging_ValidQuery_ResultSuccess()
        {
            var movies = new List<Movie>
            {
                new Movie{Id=1,Name="",Status=Data.Enums.Status.NowShowing},
                new Movie{Id=2,Name="",Status=Data.Enums.Status.NowShowing},
                new Movie{Id=3,Name="",Status=Data.Enums.Status.NowShowing}
            };
            _mockMovieRepository.Setup(x => x.FindAll((It.IsAny<Expression<Func<Movie, bool>>>())))
                .Returns(movies.AsQueryable());

            var movieService = new MovieService(_mockMovieRepository.Object, _mockUnitOfWork.Object, _mapper);
            var result = movieService.GetMoviesByPaging(string.Empty, 2, 1, Status.NowShowing);

            Assert.Equal(3, result.PageCount);
        }

        [Fact]
        public void SearchMovie_ValidQuery_ResultSuccess()
        {
            var movies = new List<Movie>
            {
                new Movie{Id=1,Name="",Status=Data.Enums.Status.NowShowing},
                new Movie{Id=2,Name="",Status=Data.Enums.Status.NowShowing},
                new Movie{Id=3,Name="",Status=Data.Enums.Status.NowShowing}
            };
            _mockMovieRepository.Setup(x => x.FindAll())
                .Returns(movies.AsQueryable());

            var movieService = new MovieService(_mockMovieRepository.Object, _mockUnitOfWork.Object, _mapper);
            var result = movieService.SearchMovie(string.Empty, 2, 1);

            Assert.Equal(3, result.PageCount);
        }

        [Fact]
        public void GetTopMovieByCondition_ValidQuery_ResultSuccess()
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "test 1", Status = Status.Active,DateCreated = DateTime.Now},
                new Movie {Id = 2, Name = "test 2", Status = Status.Active,DateCreated = DateTime.Now.AddDays(-1)},
                new Movie {Id = 3, Name = "test 2", Status = Status.Active,DateCreated = DateTime.Now.AddDays(-2)},
                new Movie {Id = 4, Name = "test 3", Status = Status.Active,DateCreated = DateTime.Now.AddDays(-3)},
                new Movie {Id = 5, Name = "test 4", Status = Status.Active,DateCreated = DateTime.Now.AddDays(-4)}
            };
            _mockMovieRepository.Setup(x => x.FindAll(It.IsAny<Expression<Func<Movie, bool>>>()))
                .Returns(movies.AsQueryable());

            var movieService = new MovieService(_mockMovieRepository.Object, _mockUnitOfWork.Object, _mapper);

            var result = movieService.GetTopMovieByCondition(2, (int)Status.Active);

            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
        }
    }
}
