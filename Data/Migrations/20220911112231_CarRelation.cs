using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentX.Migrations
{
    public partial class CarRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                    name: "Cars",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Daily_Rate = table.Column<int>(type: "int", nullable: false),
                        Available = table.Column<bool>(type: "bit", nullable: false),
                        LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        FineAmount = table.Column<int>(type: "int", nullable: false),
                        Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Cars", x => x.Id);
                    });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CarId",
                table: "Categories",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Cars_CarId",
                table: "Categories",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Cars_CarId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CarId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Categories");
        }
    }
}
