using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermissionAPI.Dto;
using PermissionAPI.Repository;

namespace PermissionAPI.Controllers
{
    
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeRepository permissionTypeRepository;
        private readonly IMapper Mapper;

        public PermissionTypeController(IPermissionTypeRepository permissionTypeRepository, IMapper mapper)
        {
            this.permissionTypeRepository = permissionTypeRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        [Route("api/permissiontypes")]
        public async Task<IEnumerable<PermissionTypeDto>> Get()
            => this.Mapper.Map<List<PermissionTypeDto>>(await this.permissionTypeRepository.GetList());
    }
}
