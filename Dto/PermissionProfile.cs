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
                .ForMember(dest => dest.PermissionTypeId, src => src.MapFrom(opt => opt.PermissionType.Id))
                .ForMember(dest => dest.DateStr, src => src.MapFrom(opt => opt.Date.ToString("dd/MM/yyyy")));

            CreateMap<PermissionCreateInput, Permission>();

            CreateMap<PermissionUpdateInput, Permission>();

            CreateMap<PaginatedObject<Permission>, PaginatedObject<PermissionDto>>();
        }
    }
}
