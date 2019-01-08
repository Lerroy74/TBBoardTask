using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TBBoardTask.Entities;
using TBBoardTask.Infrastructure.Extensions;
using TBBoardTask.Models;

namespace TBBoardTask.Logic.AutoMapperProfiles
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Quote, QuoteViewModel>()
                .ForMember(x => x.Id, z => z.MapFrom(q => q.Id))
                .ForMember(x => x.Author, z => z.MapFrom(q => q.Author))
                .ForMember(x => x.Text, z => z.MapFrom(q => q.Text))
                .ForMember(x => x.Category, z => z.MapFrom(q => q.Category != null ?  q.Category.MapTo<CategoryViewModel>() : null))
                .ForMember(x => x.CreatedAt, z => z.MapFrom(q => q.CreatedAt));
        }
    }
}
