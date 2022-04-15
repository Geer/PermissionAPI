using System.ComponentModel.DataAnnotations;

namespace PermissionAPI.Dto
{
    public class PermissionCreateInput
    {
        [Required]
        public string EmployeeFirstName { get; set; }

        [Required]
        public string EmployeeLastName { get; set; }

        [Required]
        public int PermissionTypeId { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
