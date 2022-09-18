using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentX.Migrations
{
    public partial class RemovingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Cars_CarId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CarId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
