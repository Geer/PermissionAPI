using AutoMapper;
using PermissionAPI.Model;

namespace PermissionAPI.Dto
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, PermissionDto>()
                .ForMember(dest => dest.PermissionTypeName, src => src.MapFrom(opt => opt.PermissionType.Name))
                .ForMember(dest => dest.PermissionTypeId, src => src.MapFrom(opt => opt.PermissionType.Id));

            CreateMap<PermissionCreateInput, Permission>();

            CreateMap<PermissionUpdateInput, Permission>();

            CreateMap<PaginatedObject<Permission>, PaginatedObject<PermissionDto>>();
        }
    }
}
