using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionAPI.Model
{
    [Table(nameof(Permission), Schema = "dbo")]
    public class Permission
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string EmployeeFirstName { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string EmployeeLastName { get; set; }

        [Required]
        public virtual int PermissionTypeId { get; set; }

        [Required]
        public virtual DateTime Date { get; set; }

        [ForeignKey(nameof(PermissionTypeId))]
        public virtual PermissionType PermissionType { get; set; }
    }
}
