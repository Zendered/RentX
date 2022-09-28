using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentX.Data.Migrations
{
    public partial class DatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DriverLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Available", "Brand", "CategoryId", "Created_At", "Daily_Rate", "Description", "FineAmount", "LicensePlate", "Name" },
                values: new object[,]
                {
                    { new Guid("0defbea5-f8c9-47c5-801b-8d2269001dc0"), true, "Hyundai", new Guid("8a435f5f-c880-47e5-85a3-0d0451907aa8"), new DateTime(2022, 9, 27, 17, 54, 7, 441, DateTimeKind.Local).AddTicks(2127), 120, "O HB20 Sedan impressiona com o seu \r\n                        exterior esportivo e elegante. Progresso que se pode sentir.", 80, "ABC 123D", "HB20" },
                    { new Guid("6c090713-ff4e-46f2-9e20-f3a49f5ac3bc"), true, "Toyota", new Guid("2089f4ab-9007-422e-9c9e-87b583423a4e"), new DateTime(2022, 9, 27, 17, 54, 7, 441, DateTimeKind.Local).AddTicks(2105), 200, "O Corolla gli Sedan impressiona com o seu \r\n                        exterior esportivo e elegante. Progresso que se pode sentir.", 140, "ABC 123C", "Corolla" },
                    { new Guid("b55a6ed3-2837-4127-965f-b375af07c3e4"), true, "Audi", new Guid("ef354c3c-1a03-4003-971a-1d2af188d6c2"), new DateTime(2022, 9, 27, 17, 54, 7, 441, DateTimeKind.Local).AddTicks(2023), 140, "O Audi A3 Sedan impressiona com o seu \r\n                        exterior esportivo e elegante. Progresso que se pode sentir.", 100, "ABC 123A", "Audi A3" },
                    { new Guid("c79dd509-55fc-4b14-86e2-73dd5f98dc26"), true, "Nissan", new Guid("381f85b0-9810-4331-a69d-d62733cc20ae"), new DateTime(2022, 9, 27, 17, 54, 7, 441, DateTimeKind.Local).AddTicks(2081), 100, "O Nissan Versa Sedan impressiona com o seu \r\n                        exterior esportivo e elegante. Progresso que se pode sentir.", 40, "ABC 123B", "Versa" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created_At", "Description", "Name" },
                values: new object[] { new Guid("a8f7702b-ab6f-47be-bb75-d3b65eed93f4"), new DateTime(2022, 9, 27, 17, 54, 7, 441, DateTimeKind.Local).AddTicks(2261), "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
