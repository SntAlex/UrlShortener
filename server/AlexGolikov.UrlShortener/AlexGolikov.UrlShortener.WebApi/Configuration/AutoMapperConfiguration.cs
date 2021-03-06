using AlexGolikov.UrlShortener.Domain.Models.Dtos;
using AlexGolikov.UrlShortener.Domain.Models.Entities;
using AlexGolikov.UrlShortener.WebApi.Models;
using AutoMapper;

namespace AlexGolikov.UrlShortener.WebApi.Configuration
{
    public class OriginalUrlProfile : Profile
    {
        public OriginalUrlProfile()
        {
            CreateMap<OriginalUrl, OriginalUrlDto>()
                .ReverseMap();
            CreateMap<OriginalUrlDto, OriginalUrlRequestModel>()
                .ReverseMap();
        }
    }

    public class ShortUrlProfile : Profile
    {
        public ShortUrlProfile()
        {
            CreateMap<ShortUrl, ShortUrlDto>()
                .ReverseMap();
            CreateMap<ShortUrlRequestModel, ShortUrlDto>()
                .ForMember(dest => dest.Url,
                    opt => opt.MapFrom(src => src.ShortUrlPath));
        }
    }
}
