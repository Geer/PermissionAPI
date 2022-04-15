using PermissionAPI.Dto;
using PermissionAPI.Model;

namespace PermissionAPI.Repository
{
    public interface IPermissionRepository : IDisposable
    {
        Task<PaginatedObject<Permission>> GetList(int? after, int? before, int size);

        Task<Permission> GetPermissionById(int id);

        void insert(Permission permission);
        
        void Delete(int id);
        
        void Update(Permission Permission);
        
    }
}
