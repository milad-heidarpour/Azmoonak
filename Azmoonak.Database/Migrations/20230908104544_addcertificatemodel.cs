using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azmoonak.Database.Migrations
{
    public partial class addcertificatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    FinalScore = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswer = table.Column<int>(type: "int", nullable: false),
                    FalseAnswer = table.Column<int>(type: "int", nullable: false),
                    NoAnswer = table.Column<int>(type: "int", nullable: false),
                    OpenDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CloseDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_GroupId",
                table: "Certificates",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_UserId",
                table: "Certificates",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

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
    }
}
