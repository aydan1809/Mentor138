using AutoMapper;
using Mentor138.DTOs.SchoolDtos;
using Mentor138.DTOs.StudentDtos;
using Mentor138.Entities;

namespace Mentor138.Mappers;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<Student, StudentGetDto>()
            .ForMember(dest => dest.StudentName1, options => options.MapFrom(src => src.School.SchoolName))
            .ReverseMap();
        CreateMap<School, SchoolGetDto>().ReverseMap();
        //CreateMap<SchoolGetDto,School>();
    }
}
