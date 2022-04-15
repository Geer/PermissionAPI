using System.ComponentModel.DataAnnotations;

namespace PermissionAPI.Dto
{
    public class PermissionDto
    {
        public int Id { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public string PermissionTypeName { get; set; }

        public int PermissionTypeId { get; set; }

        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime Date { get; set; }
    }
}
