using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azmoonak.Database.Migrations
{
    public partial class updateUserRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("2e2ca732-ef77-463a-8bf9-14ebf450d625"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("93fc2361-96fc-42e1-bf13-a4fc0a26ef6b"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "FName", "IsActive", "LName", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("ab486201-6aea-403b-b336-f6a13491820a"), 0, "میلاد", true, "حیدرپور", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", new Guid("93fc2361-96fc-42e1-bf13-a4fc0a26ef6b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2e2ca732-ef77-463a-8bf9-14ebf450d625"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ab486201-6aea-403b-b336-f6a13491820a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("93fc2361-96fc-42e1-bf13-a4fc0a26ef6b"));

            migrationBuilder.DropColumn(
                name: "FName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LName",
                table: "Users");

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
    }
}
