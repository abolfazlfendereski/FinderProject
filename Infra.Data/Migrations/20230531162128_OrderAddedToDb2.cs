using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinderProject.Infra.Data.Migrations
{
    public partial class OrderAddedToDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Userid",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 51, 27, 452, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 51, 27, 455, DateTimeKind.Local).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 51, 27, 455, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 51, 27, 455, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 51, 27, 455, DateTimeKind.Local).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 51, 27, 455, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 51, 27, 455, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 51, 27, 455, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 51, 27, 455, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 51, 27, 455, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Userid",
                table: "Orders",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_Userid",
                table: "Orders",
                column: "Userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_Userid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Userid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 50, 14, 77, DateTimeKind.Local).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 50, 14, 80, DateTimeKind.Local).AddTicks(1131));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 50, 14, 80, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 50, 14, 80, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 50, 14, 80, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 50, 14, 80, DateTimeKind.Local).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 50, 14, 80, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 50, 14, 80, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 50, 14, 80, DateTimeKind.Local).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 31, 19, 50, 14, 80, DateTimeKind.Local).AddTicks(1644));
        }
    }
}
