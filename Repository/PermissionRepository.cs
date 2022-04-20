using Microsoft.EntityFrameworkCore;
using PermissionAPI.DbModels;
using PermissionAPI.Dto;
using PermissionAPI.Model;

namespace PermissionAPI.Repository
{
    public class PermissionRepository : IPermissionRepository, IDisposable
    {
        private AppDbContext Context;

        public PermissionRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Delete(int id)
        {
            var permission = this.Context.Permissions
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (permission != null)
            {
                this.Context.Remove(permission);
                this.Context.SaveChanges();
            }
        }

        public async Task<PaginatedObject<Permission>> GetList(int? after, int? before, int size)
        {
            var count = await this.Context.Permissions.CountAsync();

            var permissions = await this.Context.Permissions
                .Include(p => p.PermissionType)
                .OrderBy(p => p.Id)
                .ToListAsync();

            if (after.HasValue && after.Value > 0)
            {
                permissions = permissions.Where(p => p.Id > after.Value).Take(size).ToList();
            }
            else if (before.HasValue && before.Value>0)
            {
                permissions = permissions.Where(p => p.Id < before.Value).TakeLast(size).ToList();
            }
            else
            {
                permissions = permissions.Take(size).ToList();
            }


            var ret = new PaginatedObject<Permission>
            {
                TotalCount = count,
                Items = permissions
            };

            return ret;

        }

        public async Task<Permission> GetPermissionById(int id)
            => await this.Context.Permissions
                .Include(p => p.PermissionType)
                .Where(p => p.Id == id).FirstOrDefaultAsync();

        public Permission insert(Permission permission)
        {
            this.Context.Permissions.Add(permission);
            this.Context.SaveChanges();
            return permission;
        }

        public void Update(Permission permission)
        {
            this.Context.Entry(permission).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
