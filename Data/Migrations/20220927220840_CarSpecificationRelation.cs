using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentX.Data.Migrations
{
    public partial class CarSpecificationRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarSpecification",
                columns: table => new
                {
                    CarsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecificationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSpecification", x => new { x.CarsId, x.SpecificationsId });
                    table.ForeignKey(
                        name: "FK_CarSpecification_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarSpecification_Specification_SpecificationsId",
                        column: x => x.SpecificationsId,
                        principalTable: "Specification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("0defbea5-f8c9-47c5-801b-8d2269001dc0"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 19, 8, 40, 12, DateTimeKind.Local).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6c090713-ff4e-46f2-9e20-f3a49f5ac3bc"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 19, 8, 40, 12, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b55a6ed3-2837-4127-965f-b375af07c3e4"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 19, 8, 40, 12, DateTimeKind.Local).AddTicks(314));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c79dd509-55fc-4b14-86e2-73dd5f98dc26"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 19, 8, 40, 12, DateTimeKind.Local).AddTicks(377));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2089f4ab-9007-422e-9c9e-87b583423a4e"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 19, 8, 40, 12, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("381f85b0-9810-4331-a69d-d62733cc20ae"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 19, 8, 40, 12, DateTimeKind.Local).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8a435f5f-c880-47e5-85a3-0d0451907aa8"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 19, 8, 40, 12, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ef354c3c-1a03-4003-971a-1d2af188d6c2"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 19, 8, 40, 12, DateTimeKind.Local).AddTicks(645));

            migrationBuilder.CreateIndex(
                name: "IX_CarSpecification_SpecificationsId",
                table: "CarSpecification",
                column: "SpecificationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarSpecification");

            migrationBuilder.DropTable(
                name: "Specification");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("0defbea5-f8c9-47c5-801b-8d2269001dc0"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(5023));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6c090713-ff4e-46f2-9e20-f3a49f5ac3bc"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b55a6ed3-2837-4127-965f-b375af07c3e4"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c79dd509-55fc-4b14-86e2-73dd5f98dc26"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2089f4ab-9007-422e-9c9e-87b583423a4e"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(5197));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("381f85b0-9810-4331-a69d-d62733cc20ae"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8a435f5f-c880-47e5-85a3-0d0451907aa8"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ef354c3c-1a03-4003-971a-1d2af188d6c2"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(5153));
        }
    }
}
