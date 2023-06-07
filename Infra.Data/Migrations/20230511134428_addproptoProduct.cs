using Microsoft.EntityFrameworkCore.Migrations;

namespace FinderProject.Infra.Data.Migrations
{
    public partial class addproptoProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Possibilities_HotelFeatures_HotelFeatureId",
                table: "Possibilities");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeRoom_HotelFeatures_HotelFeatureId",
                table: "TypeRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeRoom",
                table: "TypeRoom");

            migrationBuilder.DropColumn(
                name: "numberRoom",
                table: "HotelFeatures");

            migrationBuilder.DropColumn(
                name: "star",
                table: "HotelFeatures");

            migrationBuilder.RenameTable(
                name: "TypeRoom",
                newName: "TypeRooms");

            migrationBuilder.RenameColumn(
                name: "HotelFeatureId",
                table: "Possibilities",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Possibilities_HotelFeatureId",
                table: "Possibilities",
                newName: "IX_Possibilities_ProductId");

            migrationBuilder.RenameColumn(
                name: "HotelFeatureId",
                table: "TypeRooms",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_TypeRoom_HotelFeatureId",
                table: "TypeRooms",
                newName: "IX_TypeRooms_ProductId");

            migrationBuilder.AddColumn<byte>(
                name: "Score",
                table: "Products",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "numberRoom",
                table: "Products",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeRooms",
                table: "TypeRooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibilities_Products_ProductId",
                table: "Possibilities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeRooms_Products_ProductId",
                table: "TypeRooms",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Possibilities_Products_ProductId",
                table: "Possibilities");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeRooms_Products_ProductId",
                table: "TypeRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeRooms",
                table: "TypeRooms");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "numberRoom",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "TypeRooms",
                newName: "TypeRoom");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Possibilities",
                newName: "HotelFeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_Possibilities_ProductId",
                table: "Possibilities",
                newName: "IX_Possibilities_HotelFeatureId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "TypeRoom",
                newName: "HotelFeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_TypeRooms_ProductId",
                table: "TypeRoom",
                newName: "IX_TypeRoom_HotelFeatureId");

            migrationBuilder.AddColumn<byte>(
                name: "numberRoom",
                table: "HotelFeatures",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "star",
                table: "HotelFeatures",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeRoom",
                table: "TypeRoom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibilities_HotelFeatures_HotelFeatureId",
                table: "Possibilities",
                column: "HotelFeatureId",
                principalTable: "HotelFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeRoom_HotelFeatures_HotelFeatureId",
                table: "TypeRoom",
                column: "HotelFeatureId",
                principalTable: "HotelFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
