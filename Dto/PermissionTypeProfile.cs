using AutoMapper;
using PermissionAPI.Model;

namespace PermissionAPI.Dto
{
    public class PermissionTypeProfile : Profile
    {
        public PermissionTypeProfile()
        {
            CreateMap<PermissionType, PermissionTypeDto>();
        }
    }
}
