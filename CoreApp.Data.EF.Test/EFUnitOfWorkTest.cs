using CoreApp.Data.Entities;
using CoreApp.Data.Enums;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CoreApp.Data.EF.Test
{
    public class EFUnitOfWorkTest
    {
        public EFUnitOfWorkTest()
        {
            _context = ContextFactory.Create();
        }

        private readonly AppDbContext _context;

        [Fact]
        public void Commit_Should_Success_When_Save_Data()
        {
            EFRepository<Function, string> efRepository = new EFRepository<Function, string>(_context);
            EFUnitOfWork unitOfWork = new EFUnitOfWork(_context);
            efRepository.Add(new Function()
            {
                Id = "USER",
                Name = "Test",
                Status = Status.Active,
                SortOrder = 1
            });
            unitOfWork.Commit();

            List<Function> functions = efRepository.FindAll().ToList();
            Assert.Single(functions);
        }
    }
}