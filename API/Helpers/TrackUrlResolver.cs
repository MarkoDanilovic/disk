using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class TrackUrlResolver : IValueResolver<Track, TrackToReturnDto, string>
{
    private readonly IConfiguration _config;

    public TrackUrlResolver(IConfiguration config)
    {
        _config = config;
    }

    public string Resolve(Track source, TrackToReturnDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
        {
            return _config["ApiUrl"] + source.PictureUrl;
        }

        return null;
    }
}