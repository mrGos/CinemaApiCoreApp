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
                    Status = Status.NowShowing
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
                    Status = Status.NowShowing,
                    Website = "http://pandamovie.com",
                    Lat = 21.0435009,
                    Lng = 105.7894758
                });
            }
            if (_context.Functions.Count() == 0)
            {
                _context.Functions.AddRange(new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "System",ParentId = null,SortOrder = 1,Status = Status.NowShowing,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Role",ParentId = "SYSTEM",SortOrder = 1,Status = Status.NowShowing,URL = "/admin/role/index",IconCss = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Function",ParentId = "SYSTEM",SortOrder = 2,Status = Status.NowShowing,URL = "/admin/function/index",IconCss = "fa-home"  },
                    new Function() {Id = "USER", Name = "User",ParentId = "SYSTEM",SortOrder =3,Status = Status.NowShowing,URL = "/admin/user/index",IconCss = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Activity",ParentId = "SYSTEM",SortOrder = 4,Status = Status.NowShowing,URL = "/admin/activity/index",IconCss = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Error",ParentId = "SYSTEM",SortOrder = 5,Status = Status.NowShowing,URL = "/admin/error/index",IconCss = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Configuration",ParentId = "SYSTEM",SortOrder = 6,Status = Status.NowShowing,URL = "/admin/setting/index",IconCss = "fa-home"  },

                    new Function() {Id = "MOVIE",Name = "Movie Management",ParentId = null,SortOrder = 2,Status = Status.NowShowing,URL = "/",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "MOVIE_CATEGORY",Name = "Category",ParentId = "MOVIE",SortOrder =1,Status = Status.NowShowing,URL = "/admin/moviecategory/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "MOVIE_LIST",Name = "Movie",ParentId = "MOVIE",SortOrder = 2,Status = Status.NowShowing,URL = "/admin/movie/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "BILL",Name = "Bill",ParentId = "PRODUCT",SortOrder = 3,Status = Status.NowShowing,URL = "/admin/bill/index",IconCss = "fa-chevron-down"  },

                    new Function() {Id = "CONTENT",Name = "Content",ParentId = null,SortOrder = 3,Status = Status.NowShowing,URL = "/",IconCss = "fa-table"  },
                    new Function() {Id = "BLOG",Name = "Blog",ParentId = "CONTENT",SortOrder = 1,Status = Status.NowShowing,URL = "/admin/blog/index",IconCss = "fa-table"  },
                    new Function() {Id = "PAGE",Name = "Page",ParentId = "CONTENT",SortOrder = 2,Status = Status.NowShowing,URL = "/admin/page/index",IconCss = "fa-table"  },

                    new Function() {Id = "UTILITY",Name = "Utilities",ParentId = null,SortOrder = 4,Status = Status.NowShowing,URL = "/",IconCss = "fa-clone"  },
                    new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder = 1,Status = Status.NowShowing,URL = "/admin/footer/index",IconCss = "fa-clone"  },
                    new Function() {Id = "FEEDBACK",Name = "Feedback",ParentId = "UTILITY",SortOrder = 2,Status = Status.NowShowing,URL = "/admin/feedback/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ANNOUNCEMENT",Name = "Announcement",ParentId = "UTILITY",SortOrder = 3,Status = Status.NowShowing,URL = "/admin/announcement/index",IconCss = "fa-clone"  },
                    new Function() {Id = "CONTACT",Name = "Contact",ParentId = "UTILITY",SortOrder = 4,Status = Status.NowShowing,URL = "/admin/contact/index",IconCss = "fa-clone"  },
                    new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder = 5,Status = Status.NowShowing,URL = "/admin/slide/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ADVERTISMENT",Name = "Advertisment",ParentId = "UTILITY",SortOrder = 6,Status = Status.NowShowing,URL = "/admin/Advertisement/index",IconCss = "fa-clone"  },

                    new Function() {Id = "REPORT",Name = "Report",ParentId = null,SortOrder = 5,Status = Status.NowShowing,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "REVENUES",Name = "Revenue report",ParentId = "REPORT",SortOrder = 1,Status = Status.NowShowing,URL = "/admin/report/revenues",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "ACCESS",Name = "Visitor Report",ParentId = "REPORT",SortOrder = 2,Status = Status.NowShowing,URL = "/admin/report/visitor",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "READER",Name = "Reader Report",ParentId = "REPORT",SortOrder = 3,Status = Status.NowShowing,URL = "/admin/report/reader",IconCss = "fa-bar-chart-o"  },
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


            if (_context.Movies.Count() == 0)
            {
                List<Movie> lst = new List<Movie>()
                {
                            new Movie(){Name = "Qủy Đỏ - Hellboy",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/hellboy-15514188782877_370x490.jpg",Director="Neil Marshall",Cast="David Harbour, Penelope Mitchell, Ian McShane, Milla Jovovich",Category="Hành động, phiêu lưu, viễn tưởng",Format="2D/Digital",Nation="Mỹ",TimeSpan="100 phút",Rating="C18",IMDbPoints="6.8",ReleasedDate=new DateTime(2019,04,12),SeoAlias = "movie-hellboy",Status = Status.NowShowing, Description="Phần phim reboot của thương hiệu Hellboy sẽ mang Quỷ Đỏ vào cuộc hành trình đối đầu một nữ phù thủy cổ xưa, ngăn chặn ả hủy diệt thế giới."},
                            new Movie(){Name = "Shazam!",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/shazam-15517620005753_370x490.jpg",Director="David F. Sandberg",Cast="Zachary Levi, Asher Angel, Mark Strong",Category="Siêu anh hùng, Hành động, Hài hước",Format="2D/Digital",Nation="Mỹ",TimeSpan="100 phút",Rating="C13",IMDbPoints="7.7",ReleasedDate=new DateTime(2019,04,05),SeoAlias = "movie-shazam",Status = Status.NowShowing,Description="Câu chuyện bắt đầu khi cậu nhóc mồ côi rắc rối Billy Batson được phù thủy Shazam chọn trở thành siêu anh hùng kế vị trong cuộc chiến với phù thủy hắc ám Dr. Sivana. Chỉ cần hô to Shazam!, Billy sẽ ngay lập tức biến hình thành chàng siêu nhân dũng mãnh. Với sự giúp sức của anh bạn Freddy, Billy phải học cách sử dụng năng lực của mình để gánh vác trọng trách."},
                            new Movie(){Name = "Chị Mười Ba",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/03/chi-muoi-ba-15517814343647_370x490.jpg",Director="",Cast="Tiến Luật, Thu Trang",Category="Hành động",Format="2D/Digital",Nation="Việt Nam",TimeSpan="97 phút",Rating="C18",IMDbPoints="8.2",ReleasedDate=new DateTime(2019,03,29),SeoAlias = "movie-chimuoiba",Status = Status.NowShowing,Description="Sau thành công của webdrama Thập Tam Muội, \"hoa hậu hài\" Thu Trang tiến công màn ảnh rộng bằng phim điện ảnh Chị Mười Ba. Chị Mười Ba tiếp tục kể về nhóm xã hội đen An Cư Nghĩa Đoàn do chị đại Mười Ca (Thu Trang) và đại ca Đường Băng (Tiến Luật) làm thủ lĩnh. Cả hai phải đối đầu cùng đối thủ bí ẩn- đại ca Hắc Hổ. Hắn chính là kẻ bảo kê cho Bi Long (Khương Ngọc) quậy phá suốt bấy lâu nay."},
                            new Movie(){Name = "Oan Hồn Bóng Đêm - The Water Witch",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/123phim/2019/03/oan-hon-bong-dem-the-water-witch-c16-15534847299913.jpg",Director="Alexey Barykin",Cast="",Category="Kinh dị",Format="2D/Digital",Nation="Nga",TimeSpan="87 phút",Rating="C16",IMDbPoints="6",ReleasedDate=new DateTime(),SeoAlias = "movie-thewaterwitch",Status = Status.NowShowing,Description="Chuyện phim Oan Hồn Bóng Đêm (tựa gốc: The Water Witch) bắt đầu khi chứng kiến mẹ mình bị một sinh vật lạ lùng, có hình dạng gớm ghiếc bắt cóc và không được cảnh sát tin tưởng, hai anh em Alina và Ruslan quyết tâm tự mình tìm cách giải cứu mẹ. Nhưng cả hai đứa trẻ dũng cảm lại không biết rằng, chúng đang bị truy lùng bởi một linh hồn cổ xưa, với dã tâm độc ác có tên gọi là Phù Thủy Nước."},

                            new Movie(){Name = "Avengers:Endgame",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2018/12/avengers-4-15441948812386_370x490.jpg",Director="Anthony Russo, Joe Russo",Cast="Robert Downey Jr., Josh Brolin, Scarlett Johansson, Karen Gillan, Evangeline Lilly, Bradley Cooper, Chris Hemsworth, Anthony Russo",Category="Hành động",Format="2D/Digital",Nation="Mỹ",TimeSpan="100 phút",Rating="",IMDbPoints="0",ReleasedDate=new DateTime(2019,04,26),SeoAlias = "movie-avengerendgame",Status = Status.UpComming,Description="Sau cú búng tay hủy diệt nửa vũ trụ của Thanos, những siêu anh hùng sống sót trong cuộc chiến vẫn chưa từ bỏ hy vọng. Cùng với sự trở lại của Ant-Man, Hawkeye và sự xuất hiện của vị cứu tinh Captain Marvel, biệt đội Avengers sẽ thực hiện một kế hoạch bí ẩn để đảo ngược sự kiện, trả lại trật tự cho vũ trụ. Hồi kết của Cuộc chiến Vô cực là “siêu bom tấn” được mong đợi nhất năm sau, hứa hẹn viết nên cột mốc mới cho phòng vé thế giới."},
                            new Movie(){Name = "Thiên Linh Cái",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/02/thien-linh-cai-15512523407774_370x490.jpg",Director="",Cast="Thanh Tú, Đinh Y Nhung , Hoàng Yến Chibi, Nguyễn Thanh Tú",Category="Kinh dị",Format="2D/Digital",Nation="Việt Nam",TimeSpan="100 phút",Rating="C18",IMDbPoints="0",ReleasedDate=new DateTime(2019,04,19),SeoAlias = "movie-thienlinhcai",Status = Status.UpComming,Description="Dựa trên những vụ án hình sự có liên quan đến KUMANTHONG, phim điện ảnh THIÊN LINH CÁI là câu chuyện điển hình về những con người u mê, lầm đường lạc lối khi bị cuốn vào vào xoáy tội lỗi không lối thoát của thế giới bùa ngãi! Câu chuyện diễn ra tại một vùng quê nghèo lạc hậu của những năm 1990s. Tại nơi này, Thiên Linh Cái đã đến và mang theo những điều huyễn hoặc, huyền bí và đầy đau thương. "},
                            new Movie(){Name = "Godzilla: King of the Monsters",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2018/09/godzilla-king-of-the-monsters-15381106977444_220x310.jpg",Director="Michael Dougherty",Cast="Bradley Whitford, Kyle Chandler, Sally Hawkins, Vera Farmiga, Millie Bobby Brown, Michael Dougherty",Category="Hành động, Giả tưởng, Kinh dị, Khoa học viễn tưởng, Phiêu lưu",Format="2D/Digital",Nation="Mỹ",TimeSpan="100 phút",Rating="",IMDbPoints="0",ReleasedDate=new DateTime(2019,05,31),SeoAlias = "movie-godzillakom",Status = Status.UpComming,Description="Câu chuyện mới theo sau những nỗ lực của cơ quan động vật học Monarch khi các thành viên đối mặt với một lượng quái vật có kích thước thần thánh, bao gồm cả Godzilla, Vua ba đầu Ghidorah. Khi những siêu loài cổ đại này - được cho là những huyền thoại thuần túy — lại tăng lên, tất cả chúng đều tranh giành quyền tối cao, để lại sự tồn tại của nhân loại treo trong sự cân bằng."},
                            new Movie(){Name = "Pokemon: Thám tử Pikachu - Pokemon Detective Pikachu",DateCreated=DateTime.Now,Image="https://s3img.vcdn.vn/mobile/123phim/2019/02/pokemon-tham-tu-pikachu-pokemon-detective-pikachu-15512513604736_370x490.jpg",Director="Rob Letterman",Cast="Ryan Reynolds",Category="Hoạt hình, gia đình",Format="2D/3D Digital/IMAX",Nation="Mỹ",TimeSpan="100 phút",Rating="",IMDbPoints="0",ReleasedDate=new DateTime(2019,05,10),SeoAlias = "movie-detectivepikachu",Status = Status.UpComming,Description="Phim lấy bối cảnh thành phố Ryme, nơi con người và các Pokémon sống chung với nhau. Nhân vật chính của phim là Tim Goodman, một anh chàng có ước mơ làm Huấn luyện viên Pokémon nhưng đã phải từ bỏ đam mê sau khi cha anh – một cảnh sát mẫn cán - mất tích trong một vụ tai nạn ô tô. Một ngày, Tim bỗng nhiên phát hiện ra một chú Pikachu đi lạc vào nhà mình, nhưng ngạc nhiên hơn cả là anh nghe được nó nói gì thay vì những tiếng “Pika, Pika” quen thuộc. Cả hai cùng dấn thân vào cuộc điều tra những vụ mất tích bí ẩn trong thành phố, để rồi từ đó phát hiện ra những bí mật không ngờ tới đằng sau sự mất tích của cha Tim."},
                };
                _context.Movies.AddRange(lst);
            }

            if (_context.Theaters.Count() == 0)
            {
                //var bhd = new Theater() { Name = "BHD", Image = "https://s3img.vcdn.vn/123phim/2018/09/f32670fd0eb083c9c4c804f0f3a252ed.png" };
                //_context.Theaters.Add(bhd);
                //var galaxy = new Theater() { Name = "Galaxy", Image = "https://s3img.vcdn.vn/123phim/2018/09/e520781386bd5436e94d6e15e193a005.png" };
                //_context.Theaters.Add(galaxy);
                //List<Theater> lst = new List<Theater>()
                //{
                //    new Theater(){Name="BHD Star Cineplex - Bitexco",Image="https://s3img.vcdn.vn/123phim/2018/09/f32670fd0eb083c9c4c804f0f3a252ed.png"},
                //    new Theater(){Name="BHD Star Cineplex - Vincom Thảo Điền",Image="https://s3img.vcdn.vn/123phim/2018/09/f32670fd0eb083c9c4c804f0f3a252ed.png"},
                //    new Theater(){Name="BHD Star Cineplex - Phạm Hùng",Image="https://s3img.vcdn.vn/123phim/2018/09/f32670fd0eb083c9c4c804f0f3a252ed.png"},

                //    new Theater(){Name="GLX - Nguyễn Du",Image="https://s3img.vcdn.vn/123phim/2018/09/e520781386bd5436e94d6e15e193a005.png"},
                //    new Theater(){Name="GLX - Trung Chánh",Image="https://s3img.vcdn.vn/123phim/2018/09/e520781386bd5436e94d6e15e193a005.png"},
                //    new Theater(){Name="GLX - Quang Trung",Image="https://s3img.vcdn.vn/123phim/2018/09/e520781386bd5436e94d6e15e193a005.png" }
                //};
                //_context.Theaters.AddRange(lst);
            }
            if (_context.MovieTheaters.Count() == 0)
            {
                //List<MovieTheater> lst = new List<MovieTheater>();
                //foreach (var movie in _context.Movies.ToList())
                //{
                //    foreach (var theater in _context.Theaters.ToList())
                //    {
                //        MovieTheater newItem = new MovieTheater()
                //        {
                //            MovieId = movie.Id,
                //            TheaterId = theater.Id
                //        };
                //        lst.Add(newItem);
                //    }
                //}
                //_context.MovieTheaters.AddRange(lst);
            }
            if (_context.ShowTimes.Count() == 0)
            {
                //List<ShowTime> lst = new List<ShowTime>();

                //foreach (var movietheater in _context.MovieTheaters.ToList())
                //{
                //    lst.Add(new ShowTime() { MovieTheaterId = movietheater.Id, TimeShowing = "14:00" });
                //    lst.Add(new ShowTime() { MovieTheaterId = movietheater.Id, TimeShowing = "15:50" });
                //    lst.Add(new ShowTime() { MovieTheaterId = movietheater.Id, TimeShowing = "17:00" });
                //    lst.Add(new ShowTime() { MovieTheaterId = movietheater.Id, TimeShowing = "18:10" });
                //}

                //_context.ShowTimes.AddRange(lst);
            }


            if (!_context.SystemConfigs.Any(x => x.Id == "HomeTitle"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeTitle",
                    Name = "Home's title",
                    Value1 = " Movie home",
                    Status = Status.NowShowing
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaKeyword"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaKeyword",
                    Name = "Home Keyword",
                    Value1 = "movie, sales",
                    Status = Status.NowShowing
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaDescription"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaDescription",
                    Name = "Home Description",
                    Value1 = "Home ",
                    Status = Status.NowShowing
                });
            }
            await _context.SaveChangesAsync();

        }
    }
}
