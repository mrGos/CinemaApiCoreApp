using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Data.EF.Test
{
    public class ContextFactory
    {
        public static AppDbContext Create()
        {
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new AppDbContext(options);
            return context;
        }
    }
}
