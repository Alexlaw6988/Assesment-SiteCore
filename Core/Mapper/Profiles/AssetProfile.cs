using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Entities;
using Core.Models;

namespace Core.Mapper.Profiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetModel>()
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
