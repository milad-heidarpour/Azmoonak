using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azmoonak.Database.Migrations
{
    public partial class chertopert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Code",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("33c7947f-4b9f-415f-88c9-6b93cc819e8b"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("96fb1d9b-87c0-499a-9a9a-5509c6fcd077"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "IsActive", "LName", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("de775be7-78df-4ba4-a019-4b06aeaf5531"), "میلاد", true, "حیدرپور", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", new Guid("96fb1d9b-87c0-499a-9a9a-5509c6fcd077") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("33c7947f-4b9f-415f-88c9-6b93cc819e8b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("de775be7-78df-4ba4-a019-4b06aeaf5531"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("96fb1d9b-87c0-499a-9a9a-5509c6fcd077"));

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Users",
                type: "int",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);

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
    }
}
