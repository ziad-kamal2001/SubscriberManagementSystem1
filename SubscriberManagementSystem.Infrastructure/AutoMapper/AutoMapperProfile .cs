using AutoMapper;
using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Infrastructure.Services.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //  CreateMap<, >().ReverseMap()
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, MyProfileDto>().ReverseMap();
        }
    }
}