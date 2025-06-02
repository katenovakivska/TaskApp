using Application.Commands.TaskLists;
using AutoMapper;
using WebApi.Requests;

namespace WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTaskListRequest, CreateTaskListCommand>();
        }
    }
}
