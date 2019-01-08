using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TBBoardTask.Entities;
using TBBoardTask.Models;

namespace TBBoardTask.Logic.AutoMapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(c => c.Id))
                .ForMember(x => x.Name, z => z.MapFrom(c => c.Name));
        }
    }
}
