using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinderProject.Infra.Data.Migrations
{
    public partial class AdvertisingAddedToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvertisingSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 22, 5, 13, 896, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 22, 5, 13, 899, DateTimeKind.Local).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 22, 5, 13, 899, DateTimeKind.Local).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 22, 5, 13, 899, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 22, 5, 13, 899, DateTimeKind.Local).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 22, 5, 13, 899, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 22, 5, 13, 899, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 22, 5, 13, 899, DateTimeKind.Local).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 22, 5, 13, 899, DateTimeKind.Local).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 22, 5, 13, 899, DateTimeKind.Local).AddTicks(6134));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisings");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 18, 13, 53, 494, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 18, 13, 53, 496, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 18, 13, 53, 497, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 18, 13, 53, 497, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 18, 13, 53, 497, DateTimeKind.Local).AddTicks(208));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 18, 13, 53, 497, DateTimeKind.Local).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 18, 13, 53, 497, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 18, 13, 53, 497, DateTimeKind.Local).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 18, 13, 53, 497, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 18, 13, 53, 497, DateTimeKind.Local).AddTicks(374));
        }
    }
}
