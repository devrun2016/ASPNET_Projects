using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate11 : Migration
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
                    User_Account = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Account_ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Customer_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Customer_Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                    table.ForeignKey(
                        name: "FK_Customers_Account_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Account",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Account_ID",
                table: "Customers",
                column: "Account_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
