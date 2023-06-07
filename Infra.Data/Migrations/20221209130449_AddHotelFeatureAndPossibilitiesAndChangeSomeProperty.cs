using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinderProject.Infra.Data.Migrations
{
    public partial class AddHotelFeatureAndPossibilitiesAndChangeSomeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Products_ProductId",
                table: "Awards");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropColumn(
                name: "Excellencelocation",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "star",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Awards");

            migrationBuilder.AddColumn<string>(
                name: "DisPlayName",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Awards",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "HotelFeatureId",
                table: "Awards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AddressInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HotelFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numberRoom = table.Column<byte>(type: "tinyint", nullable: false),
                    star = table.Column<byte>(type: "tinyint", nullable: false),
                    DisPlayNameF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valueF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeatures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Possibilities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PossibilityValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelFeatureId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Possibilities_HotelFeatures_HotelFeatureId",
                        column: x => x.HotelFeatureId,
                        principalTable: "HotelFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeRoom",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typevalue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelFeatureId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeRoom_HotelFeatures_HotelFeatureId",
                        column: x => x.HotelFeatureId,
                        principalTable: "HotelFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Awards_HotelFeatureId",
                table: "Awards",
                column: "HotelFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatures_ProductId",
                table: "HotelFeatures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_HotelFeatureId",
                table: "Possibilities",
                column: "HotelFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeRoom_HotelFeatureId",
                table: "TypeRoom",
                column: "HotelFeatureId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_HotelFeatures_HotelFeatureId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Products_ProductId",
                table: "Awards");

            migrationBuilder.DropTable(
                name: "Possibilities");

            migrationBuilder.DropTable(
                name: "TypeRoom");

            migrationBuilder.DropTable(
                name: "HotelFeatures");

            migrationBuilder.DropIndex(
                name: "IX_Awards_HotelFeatureId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "DisPlayName",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "HotelFeatureId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AddressInfos");

            migrationBuilder.AddColumn<string>(
                name: "Excellencelocation",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "star",
                table: "Products",
                type: "tinyint",
                maxLength: 5,
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Awards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Awards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rooms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_ProductId",
                table: "Room",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Products_ProductId",
                table: "Awards",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
