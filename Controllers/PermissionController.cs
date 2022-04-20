using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PermissionAPI.Dto;
using PermissionAPI.Model;
using PermissionAPI.Repository;

namespace PermissionAPI.Controllers
{

    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository PermissionRepository;
        private readonly IMapper Mapper;

        public PermissionController(IPermissionRepository permissionRepository, IMapper mapper)
        {
            this.PermissionRepository = permissionRepository;
            this.Mapper = mapper;
        }


        // GET: api/<PermissionController>
        [HttpGet]
        [Route("api/permission")]
        public async Task<PaginatedObject<PermissionDto>> Get([FromQuery] PaginatorPatameersObject pagin)
        {
            var permissions = this.Mapper.Map<PaginatedObject<PermissionDto>>(await this.PermissionRepository.GetList(pagin.after, pagin.before, pagin.size));
            
            var paginatedPermissions = new PaginatedObject<PermissionDto>
            {
                After = permissions.Items.Select(p => p.Id).LastOrDefault(),
                Before = permissions.Items.Select(p => p.Id).FirstOrDefault(),
                TotalCount = permissions.TotalCount,
                Size = pagin.size,
                Page = pagin.page,
                Items = Mapper.Map<List<PermissionDto>>(permissions.Items)
            };

            return paginatedPermissions;
        }

        // GET api/<PermissionController>/5
        [HttpGet]
        [Route("api/permission/{id}")]
        public async Task<ActionResult<PermissionDto>> Get(int id)
        {
            var permission = this.Mapper.Map<PermissionDto>(await this.PermissionRepository.GetPermissionById(id));
            if (permission == null)
            {
                return this.NotFound();
            }

            return this.Ok(permission);
        }

        // POST api/<PermissionController>
        [HttpPost]
        [Route("api/permission")]
        public async Task<IActionResult> Post([FromBody] PermissionCreateInput permission)
        {
            if (permission == null)
            {
                return this.BadRequest();
            }
            try
            {
                var permissionData = this.Mapper.Map<Permission>(permission);
                this.PermissionRepository.insert(permissionData);
                return this.Ok();
            }
            catch (Exception e)
            {
                return this.Problem(e.Message);
            }
            
        }

        // PUT api/<PermissionController>/5
        [HttpPut]
        [Route("api/permission/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PermissionUpdateInput permission)
        {
            try
            {
                var permissionData = this.Mapper.Map<Permission>(permission);
                this.PermissionRepository.Update(permissionData);
                return this.Ok();
            }
            catch (Exception e)
            {
                return this.Problem(e.Message);
            }

        }

        // DELETE api/<PermissionController>/5
        [HttpDelete]
        [Route("api/permission/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                this.PermissionRepository.Delete(id);
                return this.Ok();
            }
            catch (Exception e)
            {
                return this.Problem(e.Message);             
            }
        }
    }
}
