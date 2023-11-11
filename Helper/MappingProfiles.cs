using AutoMapper;
using ToDoList_web_api.Dto;
using ToDoList_web_api.Models;
using ToDoList_web_api.Models.OnCreate;

namespace ToDoList_web_api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<ToDoListDto, ToDoList>().ReverseMap();
            CreateMap<ToDoListCreateModel,  ToDoList>().ReverseMap();
            CreateMap<ReviewCreateModel, Review>();
            CreateMap<ReviewDto, Review>().ReverseMap();
            CreateMap<ReviewerDto, Reviewer>().ReverseMap();
            CreateMap<ReviewerCreateModel, Reviewer>();
        }
    }
}
