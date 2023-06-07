using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinderProject.Infra.Data.Migrations
{
    public partial class AddSocialMediaNameToSocialMediaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SocialMediaName",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 19, 19, 19, 44, 197, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 19, 19, 19, 44, 200, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 19, 19, 19, 44, 200, DateTimeKind.Local).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 19, 19, 19, 44, 200, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 19, 19, 19, 44, 200, DateTimeKind.Local).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 19, 19, 19, 44, 200, DateTimeKind.Local).AddTicks(6082));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 19, 19, 19, 44, 200, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 19, 19, 19, 44, 200, DateTimeKind.Local).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 19, 19, 19, 44, 200, DateTimeKind.Local).AddTicks(6171));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 19, 19, 19, 44, 200, DateTimeKind.Local).AddTicks(6204));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialMediaName",
                table: "SocialMedias");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 15, 17, 1, 17, 446, DateTimeKind.Local).AddTicks(2727));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 15, 17, 1, 17, 451, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 15, 17, 1, 17, 451, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 15, 17, 1, 17, 451, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 15, 17, 1, 17, 451, DateTimeKind.Local).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 15, 17, 1, 17, 451, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 15, 17, 1, 17, 451, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 15, 17, 1, 17, 451, DateTimeKind.Local).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 15, 17, 1, 17, 451, DateTimeKind.Local).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "InsertTime",
                value: new DateTime(2023, 5, 15, 17, 1, 17, 451, DateTimeKind.Local).AddTicks(5120));
        }
    }
}
