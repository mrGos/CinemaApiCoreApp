using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CoreApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using CoreApp.Data.EF.Extensions;
using CoreApp.Data.EF.Configurations;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CoreApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CoreApp.Data.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Language> Languages { set; get; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Function> Functions { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Announcement> Announcements { set; get; }
        public DbSet<AnnouncementUser> AnnouncementUsers { set; get; }

        public DbSet<Blog> Bills { set; get; }
        public DbSet<BillDetail> BillDetails { set; get; }
        public DbSet<Blog> Blogs { set; get; }
        public DbSet<BlogTag> BlogTags { set; get; }

        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Movie> Movies { set; get; }

        public DbSet<MovieImage> MovieImages { set; get; }

        public DbSet<Theater> Theaters { set; get; }
        public DbSet<MovieTheater> MovieTheaters { set; get; }
        public DbSet<ShowTime> ShowTimes { set; get; }

        public DbSet<MovieTag> MovieTags { set; get; }


        public DbSet<Slide> Slides { set; get; }

        public DbSet<Tag> Tags { set; get; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<AdvertisementPage> AdvertisementPages { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementPosition> AdvertisementPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity Config

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims")
                .HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
                .HasKey(x => new { x.RoleId, x.UserId });

            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")
               .HasKey(x => new { x.UserId });

            #endregion Identity Config

            builder.AddConfiguration(new TagConfiguration());
            builder.AddConfiguration(new BlogTagConfiguration());
            builder.AddConfiguration(new ContactDetailConfiguration());
            builder.AddConfiguration(new FooterConfiguration());
            builder.AddConfiguration(new PageConfiguration());
            builder.AddConfiguration(new FunctionConfiguration());
            builder.AddConfiguration(new MovieTagConfiguration());
            builder.AddConfiguration(new SystemConfigConfiguration());
            builder.AddConfiguration(new AdvertistmentPositionConfiguration());
            builder.AddConfiguration(new AdvertistmentPageConfiguration());
            builder.AddConfiguration(new AnnouncementConfiguration());

            //base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    }
                    changedOrAddedItem.DateModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
