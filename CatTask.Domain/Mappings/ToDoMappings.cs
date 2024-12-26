using AutoMapper;
using CatTask.Domain.DTO.TODos;
using CatTask.Domain.Entities;

namespace CatTask.Domain.Mappings;
public class ToDoMappings:Profile
{
    public ToDoMappings()
    {
        CreateMap<ToDoRequest,ToDo>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        CreateMap<ToDo, ToDoResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
    }
}
