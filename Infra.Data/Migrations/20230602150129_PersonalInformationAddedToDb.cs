using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinderProject.Infra.Data.Migrations
{
    public partial class PersonalInformationAddedToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CommentProducts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInformation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 2, 18, 31, 29, 81, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 2, 18, 31, 29, 84, DateTimeKind.Local).AddTicks(735));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 2, 18, 31, 29, 84, DateTimeKind.Local).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 2, 18, 31, 29, 84, DateTimeKind.Local).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 2, 18, 31, 29, 84, DateTimeKind.Local).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 2, 18, 31, 29, 84, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 2, 18, 31, 29, 84, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 2, 18, 31, 29, 84, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 2, 18, 31, 29, 84, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 2, 18, 31, 29, 84, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.CreateIndex(
                name: "IX_CommentProducts_UserId",
                table: "CommentProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_UserId",
                table: "PersonalInformation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentProducts_AspNetUsers_UserId",
                table: "CommentProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentProducts_AspNetUsers_UserId",
                table: "CommentProducts");

            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_CommentProducts_UserId",
                table: "CommentProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommentProducts");

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
        }
    }
}
