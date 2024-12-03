using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodFlow.Migrations
{
    /// <inheritdoc />
    public partial class init002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Emp_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dept_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Emp_ID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_Dept_ID",
                        column: x => x.Dept_ID,
                        principalTable: "Departments",
                        principalColumn: "Dept_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Dept_ID",
                table: "Employees",
                column: "Dept_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
