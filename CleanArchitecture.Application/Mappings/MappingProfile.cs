using AutoMapper;
using CleanArchitecture.Application.Features.Streamers.Commands;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, GetVideosListQueryResponse>();
            CreateMap<CreateEmployeeTypeCommandRequest, Streamer>();
            CreateMap<UpdateEmployeeTypeCommandRequest, Streamer>();

        }
    }
}
