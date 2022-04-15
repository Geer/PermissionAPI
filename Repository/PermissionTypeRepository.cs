using Microsoft.EntityFrameworkCore;
using PermissionAPI.DbModels;
using PermissionAPI.Model;

namespace PermissionAPI.Repository
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly AppDbContext Context;
        public PermissionTypeRepository(AppDbContext context)
        {
            this.Context = context;
        }
        public async Task<IEnumerable<PermissionType>> GetList()
            => await this.Context.PermissionTypes.ToListAsync();
    }
}
