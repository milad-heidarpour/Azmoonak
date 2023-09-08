using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azmoonak.Database.Migrations
{
    public partial class editcertificatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4fbb6b75-b043-45be-9b4b-4bd211f49a83"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36dd50a8-9718-4b51-ae2b-af7516e79379"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5289daf2-e41e-4f3b-a02d-30e88e77be49"));

            migrationBuilder.DropColumn(
                name: "CloseDateTime",
                table: "Certificates");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("ac715fe8-8d4a-41dc-93b0-1362db073ff1"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("f76f1f7d-5cb9-4a3a-a330-fdb7e1e9e994"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "IsActive", "LName", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("b97ae97e-a00e-46a5-8830-b6e2aa48e846"), "میلاد", true, "حیدرپور", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", new Guid("f76f1f7d-5cb9-4a3a-a330-fdb7e1e9e994") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ac715fe8-8d4a-41dc-93b0-1362db073ff1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b97ae97e-a00e-46a5-8830-b6e2aa48e846"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f76f1f7d-5cb9-4a3a-a330-fdb7e1e9e994"));

            migrationBuilder.AddColumn<string>(
                name: "CloseDateTime",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("4fbb6b75-b043-45be-9b4b-4bd211f49a83"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("5289daf2-e41e-4f3b-a02d-30e88e77be49"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "IsActive", "LName", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("36dd50a8-9718-4b51-ae2b-af7516e79379"), "میلاد", true, "حیدرپور", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", new Guid("5289daf2-e41e-4f3b-a02d-30e88e77be49") });
        }
    }
}
