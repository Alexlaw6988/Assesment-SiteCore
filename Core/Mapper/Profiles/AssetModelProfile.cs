using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Entities;
using Core.Models;

namespace Core.Mapper.Profiles
{
    public class AssetModelProfile : Profile
    {
        public AssetModelProfile()
        {
            CreateMap<AssetModel,Asset>()
                .ForMember(x=>x.Id,opt => opt.MapFrom(m => 0))
                .ForMember(x => x.AssetId, opt => opt.MapFrom(m => m.AssetId))
                .ForMember(x => x.FileName, opt => opt.MapFrom(m => m.FileName))
                .ForMember(x => x.MimeType, opt => opt.MapFrom(m => m.MimeType))
                .ForMember(x => x.Country, opt => opt.MapFrom(m => m.Country))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(m => m.CreatedBy))
                .ForMember(x => x.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(x => x.Email, opt => opt.MapFrom(m => m.Email));
        }
    }
}
