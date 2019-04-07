using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreApp.Data.Entities;
using CoreApp.Data.Enums;
using CoreApp.Utilities.Constants;

namespace CoreApp.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    Balance = 0,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Status = Status.Active
                }, "123456$");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            if (!_context.Contacts.Any())
            {
                _context.Contacts.Add(new Contact()
                {
                    Id = CommonConstants.DefaultContactId,
                    Address = "Dĩ An, Bình Dương, HCM",
                    Email = "pandamovie@gmail.com",
                    Name = "Panda Movie",
                    Phone = "0942 324 543",
                    Status = Status.Active,
                    Website = "http://pandamovie.com",
                    Lat = 21.0435009,
                    Lng = 105.7894758
                });
            }
            if (_context.Functions.Count() == 0)
            {
                _context.Functions.AddRange(new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "System",ParentId = null,SortOrder = 1,Status = Status.Active,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Role",ParentId = "SYSTEM",SortOrder = 1,Status = Status.Active,URL = "/admin/role/index",IconCss = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Function",ParentId = "SYSTEM",SortOrder = 2,Status = Status.Active,URL = "/admin/function/index",IconCss = "fa-home"  },
                    new Function() {Id = "USER", Name = "User",ParentId = "SYSTEM",SortOrder =3,Status = Status.Active,URL = "/admin/user/index",IconCss = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Activity",ParentId = "SYSTEM",SortOrder = 4,Status = Status.Active,URL = "/admin/activity/index",IconCss = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Error",ParentId = "SYSTEM",SortOrder = 5,Status = Status.Active,URL = "/admin/error/index",IconCss = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Configuration",ParentId = "SYSTEM",SortOrder = 6,Status = Status.Active,URL = "/admin/setting/index",IconCss = "fa-home"  },

                    new Function() {Id = "MOVIE",Name = "Movie Management",ParentId = null,SortOrder = 2,Status = Status.Active,URL = "/",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "MOVIE_CATEGORY",Name = "Category",ParentId = "MOVIE",SortOrder =1,Status = Status.Active,URL = "/admin/moviecategory/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "MOVIE_LIST",Name = "Movie",ParentId = "MOVIE",SortOrder = 2,Status = Status.Active,URL = "/admin/movie/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "BILL",Name = "Bill",ParentId = "PRODUCT",SortOrder = 3,Status = Status.Active,URL = "/admin/bill/index",IconCss = "fa-chevron-down"  },

                    new Function() {Id = "CONTENT",Name = "Content",ParentId = null,SortOrder = 3,Status = Status.Active,URL = "/",IconCss = "fa-table"  },
                    new Function() {Id = "BLOG",Name = "Blog",ParentId = "CONTENT",SortOrder = 1,Status = Status.Active,URL = "/admin/blog/index",IconCss = "fa-table"  },
                    new Function() {Id = "PAGE",Name = "Page",ParentId = "CONTENT",SortOrder = 2,Status = Status.Active,URL = "/admin/page/index",IconCss = "fa-table"  },

                    new Function() {Id = "UTILITY",Name = "Utilities",ParentId = null,SortOrder = 4,Status = Status.Active,URL = "/",IconCss = "fa-clone"  },
                    new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder = 1,Status = Status.Active,URL = "/admin/footer/index",IconCss = "fa-clone"  },
                    new Function() {Id = "FEEDBACK",Name = "Feedback",ParentId = "UTILITY",SortOrder = 2,Status = Status.Active,URL = "/admin/feedback/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ANNOUNCEMENT",Name = "Announcement",ParentId = "UTILITY",SortOrder = 3,Status = Status.Active,URL = "/admin/announcement/index",IconCss = "fa-clone"  },
                    new Function() {Id = "CONTACT",Name = "Contact",ParentId = "UTILITY",SortOrder = 4,Status = Status.Active,URL = "/admin/contact/index",IconCss = "fa-clone"  },
                    new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder = 5,Status = Status.Active,URL = "/admin/slide/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ADVERTISMENT",Name = "Advertisment",ParentId = "UTILITY",SortOrder = 6,Status = Status.Active,URL = "/admin/Advertisement/index",IconCss = "fa-clone"  },

                    new Function() {Id = "REPORT",Name = "Report",ParentId = null,SortOrder = 5,Status = Status.Active,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "REVENUES",Name = "Revenue report",ParentId = "REPORT",SortOrder = 1,Status = Status.Active,URL = "/admin/report/revenues",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "ACCESS",Name = "Visitor Report",ParentId = "REPORT",SortOrder = 2,Status = Status.Active,URL = "/admin/report/visitor",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "READER",Name = "Reader Report",ParentId = "REPORT",SortOrder = 3,Status = Status.Active,URL = "/admin/report/reader",IconCss = "fa-bar-chart-o"  },
                });
            }

            if (_context.Footers.Count(x => x.Id == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "Footer";
                _context.Footers.Add(new Footer()
                {
                    Id = CommonConstants.DefaultFooterId,
                    Content = content
                });
            }


            if (_context.AdvertisementPages.Count() == 0)
            {
                List<AdvertisementPage> pages = new List<AdvertisementPage>()
                {
                    new AdvertisementPage() {Id="home", Name="Home",AdvertisementPositions = new List<AdvertisementPosition>(){
                        new AdvertisementPosition(){Id="home-left",Name="Bên trái"}
                    } },
                    new AdvertisementPage() {Id="movie-cate", Name="Movie category" ,
                        AdvertisementPositions = new List<AdvertisementPosition>(){
                        new AdvertisementPosition(){Id="movie-cate-left",Name="Bên trái"}
                    }},
                    new AdvertisementPage() {Id="movie-detail", Name="Product detail",
                        AdvertisementPositions = new List<AdvertisementPosition>(){
                        new AdvertisementPosition(){Id="movie-detail-left",Name="Bên trái"}
                    } },

                };
                _context.AdvertisementPages.AddRange(pages);
            }


            if (_context.Slides.Count() == 0)
            {
                List<Slide> slides = new List<Slide>()
                {
                    new Slide() {Name="Slide 1",Image="https://s3img.vcdn.vn/123phim/2019/03/chung-nhan-hoan-hao-15537433196714.jpg",Url="#",DisplayOrder = 0,GroupAlias = "top",Status = true },
                    new Slide() {Name="Slide 2",Image="https://s3img.vcdn.vn/123phim/2019/03/cong-vien-ky-dieu-15531418335137.jpg",Url="#",DisplayOrder = 1,GroupAlias = "top",Status = true },
                    new Slide() {Name="Slide 3",Image="https://s3img.vcdn.vn/123phim/2019/02/hai-phuong-sneakshow-15508021265617.jpg",Url="#",DisplayOrder = 2,GroupAlias = "top",Status = true },

                    new Slide() {Name="Slide 1",Image="https://s3img.vcdn.vn/123phim/2019/03/chung-nhan-hoan-hao-15537433196714.jpg",Url="#",DisplayOrder = 1,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 2",Image="https://s3img.vcdn.vn/123phim/2019/03/cong-vien-ky-dieu-15531418335137.jpg",Url="#",DisplayOrder = 2,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 3",Image="https://s3img.vcdn.vn/123phim/2019/02/hai-phuong-sneakshow-15508021265617.jpg",Url="#",DisplayOrder = 3,GroupAlias = "brand",Status = true },

                };
                _context.Slides.AddRange(slides);
            }


            if (_context.MovieCategories.Count() == 0)
            {
                List<MovieCategory> listProductCategory = new List<MovieCategory>()
                {
                    new MovieCategory() { Name="Sắp chiếu",SeoAlias="upcoming",ParentId = null,Status=Status.Active,SortOrder=1,
                        Movies = new List<Movie>()
                        {
                            new Movie(){Name = "Movie 1",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",SeoAlias = "movie-1",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Movie(){Name = "Movie 2",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",SeoAlias = "movie-2",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Movie(){Name = "Movie 3",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",SeoAlias = "movie-3",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Movie(){Name = "Movie 4",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",SeoAlias = "movie-4",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Movie(){Name = "Movie 5",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",SeoAlias = "movie-5",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }
                    },
                    new MovieCategory() {Name="Đang chiếu",SeoAlias="now-showing",ParentId = null,Status=Status.Active ,SortOrder=2,
                        Movies = new List<Movie>()
                        {
                            new Movie(){Name = "Movie 6",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",SeoAlias = "movie-6",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Movie(){Name = "Movie 7",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",SeoAlias = "movie-7",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Movie(){Name = "Movie 8",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",SeoAlias = "movie-8",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Movie(){Name = "Movie 9",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",SeoAlias = "movie-9",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Movie(){Name = "Movie 10",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",SeoAlias = "movie-10",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }},

                };
                _context.MovieCategories.AddRange(listProductCategory);
            }

            if (!_context.SystemConfigs.Any(x => x.Id == "HomeTitle"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeTitle",
                    Name = "Home's title",
                    Value1 = " Movie home",
                    Status = Status.Active
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaKeyword"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaKeyword",
                    Name = "Home Keyword",
                    Value1 = "movie, sales",
                    Status = Status.Active
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaDescription"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaDescription",
                    Name = "Home Description",
                    Value1 = "Home ",
                    Status = Status.Active
                });
            }
            await _context.SaveChangesAsync();

        }
    }
}
