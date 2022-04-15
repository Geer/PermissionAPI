using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionAPI.Migrations
{
    public partial class fix_typo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeFirsName",
                schema: "dbo",
                table: "Permission",
                newName: "EmployeeFirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeFirstName",
                schema: "dbo",
                table: "Permission",
                newName: "EmployeeFirsName");
        }
    }
}
