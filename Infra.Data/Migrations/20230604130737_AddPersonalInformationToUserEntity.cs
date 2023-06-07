using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinderProject.Infra.Data.Migrations
{
    public partial class AddPersonalInformationToUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_UserId",
                table: "PersonalInformation");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 16, 37, 36, 354, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 16, 37, 36, 356, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 16, 37, 36, 356, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 16, 37, 36, 356, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 16, 37, 36, 356, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 16, 37, 36, 356, DateTimeKind.Local).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 16, 37, 36, 356, DateTimeKind.Local).AddTicks(8407));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 16, 37, 36, 356, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 16, 37, 36, 356, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 16, 37, 36, 356, DateTimeKind.Local).AddTicks(8507));

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_UserId",
                table: "PersonalInformation",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_UserId",
                table: "PersonalInformation");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 15, 30, 35, 645, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 15, 30, 35, 648, DateTimeKind.Local).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 15, 30, 35, 648, DateTimeKind.Local).AddTicks(5697));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 15, 30, 35, 648, DateTimeKind.Local).AddTicks(5745));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 15, 30, 35, 648, DateTimeKind.Local).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 15, 30, 35, 648, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 15, 30, 35, 648, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 15, 30, 35, 648, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 15, 30, 35, 648, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 15, 30, 35, 648, DateTimeKind.Local).AddTicks(6076));

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_UserId",
                table: "PersonalInformation",
                column: "UserId");
        }
    }
}
