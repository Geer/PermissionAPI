using PermissionAPI.Model;

namespace PermissionAPI.Repository
{
    public interface IPermissionTypeRepository
    {
        Task<IEnumerable<PermissionType>> GetList();
    }
}
