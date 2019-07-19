using AutoMapper;
using CoreApp.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Application.Test
{
    public class MapperFactory
    {
        public static IMapper Create()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new DomainToViewModelMappingProfile()));
            var mapper = mockMapper.CreateMapper();

            return mapper;
        }
    }
}
