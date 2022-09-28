using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentX.Data.Migrations
{
    public partial class CarCategoryDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a8f7702b-ab6f-47be-bb75-d3b65eed93f4"));

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created_At", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2089f4ab-9007-422e-9c9e-87b583423a4e"), new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(5197), "Carro para momentos mais radicais", "suv" },
                    { new Guid("381f85b0-9810-4331-a69d-d62733cc20ae"), new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(5176), "Carro para momentos mais radicais", "suv" },
                    { new Guid("8a435f5f-c880-47e5-85a3-0d0451907aa8"), new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(5218), "perfeito para a familia", "esportivo" },
                    { new Guid("ef354c3c-1a03-4003-971a-1d2af188d6c2"), new DateTime(2022, 9, 27, 18, 25, 24, 547, DateTimeKind.Local).AddTicks(5153), "4 portas, teto solar", "esportivo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2089f4ab-9007-422e-9c9e-87b583423a4e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("381f85b0-9810-4331-a69d-d62733cc20ae"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8a435f5f-c880-47e5-85a3-0d0451907aa8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ef354c3c-1a03-4003-971a-1d2af188d6c2"));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("0defbea5-f8c9-47c5-801b-8d2269001dc0"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 17, 54, 7, 441, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6c090713-ff4e-46f2-9e20-f3a49f5ac3bc"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 17, 54, 7, 441, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b55a6ed3-2837-4127-965f-b375af07c3e4"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 17, 54, 7, 441, DateTimeKind.Local).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c79dd509-55fc-4b14-86e2-73dd5f98dc26"),
                column: "Created_At",
                value: new DateTime(2022, 9, 27, 17, 54, 7, 441, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created_At", "Description", "Name" },
                values: new object[] { new Guid("a8f7702b-ab6f-47be-bb75-d3b65eed93f4"), new DateTime(2022, 9, 27, 17, 54, 7, 441, DateTimeKind.Local).AddTicks(2261), "", "" });
        }
    }
}
