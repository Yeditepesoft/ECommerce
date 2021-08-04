using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)"),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Convert(Date,GetDate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Convert(Date,GetDate())"),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "space(0)"),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)"),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Convert(Date,GetDate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Convert(Date,GetDate())"),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "space(0)"),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    Gsm = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)"),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSuperVisor = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserGroupId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Convert(Date,GetDate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Convert(Date,GetDate())"),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "space(0)"),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "CreatedUser", "Description" },
                values: new object[,]
                {
                    { 1, "Migration", "Kadın" },
                    { 2, "Migration", "Erkek" },
                    { 3, "Migration", "Belirtilmedi" }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "CreatedUser", "Description" },
                values: new object[,]
                {
                    { 1, "Migration", "Son Kullanıcı" },
                    { 2, "Migration", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedUser", "Email", "FirstName", "GenderId", "Gsm", "IsSuperVisor", "LastName", "PasswordHash", "PasswordSalt", "UserGroupId" },
                values: new object[] { 1, "Migration", "abdikurt@gmail.com", "Abdi", 2, "5423269293", true, "KURT", new byte[] { 105, 154, 184, 33, 193, 194, 130, 236, 164, 22, 188, 128, 204, 16, 74, 67, 119, 35, 157, 84, 199, 170, 213, 158, 164, 64, 49, 151, 219, 185, 245, 74, 78, 69, 209, 66, 201, 71, 175, 133, 183, 2, 139, 39, 212, 233, 57, 246, 175, 235, 249, 143, 40, 91, 95, 99, 206, 71, 179, 82, 104, 235, 249, 87 }, new byte[] { 16, 93, 94, 109, 89, 36, 51, 253, 190, 147, 212, 218, 129, 181, 2, 83, 245, 120, 124, 238, 119, 159, 26, 13, 178, 61, 59, 250, 146, 63, 55, 117, 185, 158, 22, 141, 77, 46, 51, 5, 250, 38, 127, 253, 64, 246, 65, 205, 198, 119, 212, 14, 152, 119, 52, 42, 46, 155, 250, 105, 254, 139, 214, 58, 210, 241, 195, 94, 46, 245, 111, 135, 93, 83, 199, 21, 49, 221, 98, 234, 162, 123, 166, 126, 20, 9, 43, 46, 135, 30, 42, 176, 40, 241, 217, 115, 122, 139, 24, 217, 31, 220, 187, 41, 90, 39, 232, 245, 222, 168, 221, 218, 112, 226, 160, 208, 219, 48, 1, 181, 161, 105, 237, 197, 76, 38, 95, 16 }, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Description",
                table: "Genders",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_Description",
                table: "UserGroups",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FirstName_LastName",
                table: "Users",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Gsm",
                table: "Users",
                column: "Gsm");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGroupId",
                table: "Users",
                column: "UserGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
