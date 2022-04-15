using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionAPI.Migrations
{
    public partial class fill_permission_types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
                
                IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'PermissionType')
                BEGIN
				    IF NOT EXISTS (SELECT 1 FROM [dbo].[PermissionType] WHERE [Name] = 'Enfermedad')
				    BEGIN
					    INSERT INTO [dbo].[PermissionType] ([Name]) VALUES ('Enfermedad')
				    END
					
					IF NOT EXISTS (SELECT 1 FROM [dbo].[PermissionType] WHERE [Name] = 'Diligencias')
					BEGIN
						INSERT INTO [dbo].[PermissionType] ([Name]) VALUES ('Diligencias')
					END
					
					IF NOT EXISTS (SELECT 1 FROM [dbo].[PermissionType] WHERE [Name] = 'Otros')
					BEGIN
						INSERT INTO [dbo].[PermissionType] ([Name]) VALUES ('Otros')
					END
                END

            ");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
                
                IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'PermissionType')
                BEGIN
				    IF EXISTS (SELECT 1 FROM [dbo].[PermissionType] WHERE [Name] = 'Enfermedad')
				    BEGIN
					    DELETE FROM [dbo].[PermissionType] WHERE [Name] = 'Enfermedad'
				    END
					
					IF EXISTS (SELECT 1 FROM [dbo].[PermissionType] WHERE [Name] = 'Diligencias')
					BEGIN
						DELETE FROM [dbo].[PermissionType] WHERE [Name] = 'Diligencias'
					END
					
					IF EXISTS (SELECT 1 FROM [dbo].[PermissionType] WHERE [Name] = 'Otros')
					BEGIN
						DELETE FROM [dbo].[PermissionType] WHERE [Name] = 'Otros'
					END
                END

            ");
		}
    }
}
