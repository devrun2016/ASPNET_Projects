using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodFlow.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Account_Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Account_ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Employee_DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employee_Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Employee_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Employee_Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_ID);
                    table.ForeignKey(
                        name: "FK_Employee_Account_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Account",
                        principalColumn: "Account_ID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_Users_Account_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Account",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Account_ID",
                table: "Employee",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Account_ID",
                table: "Users",
                column: "Account_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
