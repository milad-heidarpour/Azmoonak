using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azmoonak.Database.Migrations
{
    public partial class updatequestionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("86fadeb6-6ab3-46d6-a102-fd36a6ad1d00"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("37d6764e-4162-430a-92fb-9162788b8e61"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9b783937-b792-4461-ba4e-aaa340889cb9"));

            migrationBuilder.AddColumn<string>(
                name: "UserAn",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("565534ac-d97f-48be-ac46-6800c59ce4cb"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("78ffb31b-ce95-4c79-9850-3d3efcbaba15"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "IsActive", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("ef15c0bc-297e-41f0-b4aa-569453af877f"), 0, true, "09115523293", "99-21-64-DB-BF-B2-7F-38-0F-66-DF-8A-72-43-42-33", new Guid("565534ac-d97f-48be-ac46-6800c59ce4cb") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("78ffb31b-ce95-4c79-9850-3d3efcbaba15"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ef15c0bc-297e-41f0-b4aa-569453af877f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("565534ac-d97f-48be-ac46-6800c59ce4cb"));

            migrationBuilder.DropColumn(
                name: "UserAn",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("86fadeb6-6ab3-46d6-a102-fd36a6ad1d00"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("9b783937-b792-4461-ba4e-aaa340889cb9"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "IsActive", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("37d6764e-4162-430a-92fb-9162788b8e61"), 0, true, "09115523293", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("9b783937-b792-4461-ba4e-aaa340889cb9") });
        }
    }
}
