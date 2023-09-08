using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azmoonak.Database.Migrations
{
    public partial class inttodoublefinallscore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "FinalScore",
                table: "Certificates",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("2ad90754-f396-4949-a9a1-907c523ed7b1"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("32f2d53f-1ab2-4fc4-bdeb-ef6718204148"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "IsActive", "LName", "Mobile", "Password", "RoleId" },
                values: new object[] { new Guid("8c79591c-cc73-4e99-a94c-24bd42e5deeb"), "میلاد", true, "حیدرپور", "09030826556", "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93", new Guid("32f2d53f-1ab2-4fc4-bdeb-ef6718204148") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2ad90754-f396-4949-a9a1-907c523ed7b1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c79591c-cc73-4e99-a94c-24bd42e5deeb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("32f2d53f-1ab2-4fc4-bdeb-ef6718204148"));

            migrationBuilder.AlterColumn<int>(
                name: "FinalScore",
                table: "Certificates",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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
    }
}
