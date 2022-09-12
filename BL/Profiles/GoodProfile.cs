using AutoMapper;
using BL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    public class GoodProfile : Profile
    {
        public GoodProfile()
        {
            CreateMap<Good, GoodDto>();

            CreateMap<CreateGoodDto, Good>()
                .ForMember(x => x.CreatedAt, options => options.MapFrom(src => DateTime.Now))
                .ForMember(x => x.Title, options => options.MapFrom(src => src.Title))
                .ForMember(x => x.Price, options => options.MapFrom(src => src.Price));
        }
    }
}
