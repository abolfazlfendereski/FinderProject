using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinderProject.Infra.Data.Migrations
{
    public partial class AddFavoriteToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_HotelFeatures_HotelFeatureId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Products_ProductId",
                table: "Awards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Awards",
                table: "Awards");

            migrationBuilder.RenameTable(
                name: "Awards",
                newName: "awards");

            migrationBuilder.RenameIndex(
                name: "IX_Awards_ProductId",
                table: "awards",
                newName: "IX_awards_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Awards_HotelFeatureId",
                table: "awards",
                newName: "IX_awards_HotelFeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_awards",
                table: "awards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorites_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 23, 52, 30, 899, DateTimeKind.Local).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 23, 52, 30, 902, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 23, 52, 30, 902, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 23, 52, 30, 902, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 23, 52, 30, 902, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 23, 52, 30, 902, DateTimeKind.Local).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 23, 52, 30, 902, DateTimeKind.Local).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 23, 52, 30, 902, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 23, 52, 30, 902, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 23, 52, 30, 902, DateTimeKind.Local).AddTicks(1848));

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ProductId",
                table: "Favorites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_awards_HotelFeatures_HotelFeatureId",
                table: "awards",
                column: "HotelFeatureId",
                principalTable: "HotelFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_awards_Products_ProductId",
                table: "awards",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_awards_HotelFeatures_HotelFeatureId",
                table: "awards");

            migrationBuilder.DropForeignKey(
                name: "FK_awards_Products_ProductId",
                table: "awards");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_awards",
                table: "awards");

            migrationBuilder.RenameTable(
                name: "awards",
                newName: "Awards");

            migrationBuilder.RenameIndex(
                name: "IX_awards_ProductId",
                table: "Awards",
                newName: "IX_Awards_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_awards_HotelFeatureId",
                table: "Awards",
                newName: "IX_Awards_HotelFeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Awards",
                table: "Awards",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_HotelFeatures_HotelFeatureId",
                table: "Awards",
                column: "HotelFeatureId",
                principalTable: "HotelFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Products_ProductId",
                table: "Awards",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
