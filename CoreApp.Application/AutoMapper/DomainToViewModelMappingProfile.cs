using AutoMapper;
using CoreApp.Application.ViewModels.Blog;
using CoreApp.Application.ViewModels.Common;
using CoreApp.Application.ViewModels.Movie;
using CoreApp.Application.ViewModels.MovieCategory;
using CoreApp.Application.ViewModels.System;
using CoreApp.Data.Entities;

namespace CoreApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<MovieCategory, MovieCategoryViewModel>();
            CreateMap<Movie, MovieViewModel>();
            CreateMap<Announcement, AnnouncementViewModel>().MaxDepth(2);

            CreateMap<Function, FunctionViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<Bill, BillViewModel>();
            CreateMap<BillDetail, BillDetailViewModel>();

            CreateMap<MovieImage, MovieImageViewModel>().MaxDepth(2);


            CreateMap<Blog, BlogViewModel>().MaxDepth(2);
            CreateMap<BlogTag, BlogTagViewModel>().MaxDepth(2);
            CreateMap<Slide, SlideViewModel>().MaxDepth(2);
            CreateMap<SystemConfig, SystemConfigViewModel>().MaxDepth(2);
            CreateMap<Footer, FooterViewModel>().MaxDepth(2);

            CreateMap<Feedback, FeedbackViewModel>().MaxDepth(2);
            CreateMap<Contact, ContactViewModel>().MaxDepth(2);
            CreateMap<Page, PageViewModel>().MaxDepth(2);
        }
    }
}