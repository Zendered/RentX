using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentX.Data.Migrations
{
    public partial class SpecificationEntitie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSpecification_Specification_SpecificationsId",
                table: "CarSpecification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specification",
                table: "Specification");

            migrationBuilder.RenameTable(
                name: "Specification",
                newName: "Specifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specifications",
                table: "Specifications",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("0defbea5-f8c9-47c5-801b-8d2269001dc0"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6c090713-ff4e-46f2-9e20-f3a49f5ac3bc"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b55a6ed3-2837-4127-965f-b375af07c3e4"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c79dd509-55fc-4b14-86e2-73dd5f98dc26"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2089f4ab-9007-422e-9c9e-87b583423a4e"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("381f85b0-9810-4331-a69d-d62733cc20ae"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8a435f5f-c880-47e5-85a3-0d0451907aa8"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ef354c3c-1a03-4003-971a-1d2af188d6c2"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.AddForeignKey(
                name: "FK_CarSpecification_Specifications_SpecificationsId",
                table: "CarSpecification",
                column: "SpecificationsId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSpecification_Specifications_SpecificationsId",
                table: "CarSpecification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specifications",
                table: "Specifications");

            migrationBuilder.RenameTable(
                name: "Specifications",
                newName: "Specification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specification",
                table: "Specification",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CarSpecification_Specification_SpecificationsId",
                table: "CarSpecification",
                column: "SpecificationsId",
                principalTable: "Specification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
