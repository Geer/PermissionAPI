using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionAPI.Model
{
    [Table(nameof(PermissionType), Schema = "dbo")]
    public class PermissionType
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public virtual string Name { get; set; }
    }
}
