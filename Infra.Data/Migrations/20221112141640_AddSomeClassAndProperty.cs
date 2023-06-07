using Microsoft.EntityFrameworkCore.Migrations;

namespace FinderProject.Infra.Data.Migrations
{
    public partial class AddSomeClassAndProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressInfo_Products_ProductId",
                table: "AddressInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_awards_Products_ProductId",
                table: "awards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_awards",
                table: "awards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressInfo",
                table: "AddressInfo");

            migrationBuilder.RenameTable(
                name: "awards",
                newName: "Awards");

            migrationBuilder.RenameTable(
                name: "AddressInfo",
                newName: "AddressInfos");

            migrationBuilder.RenameIndex(
                name: "IX_awards_ProductId",
                table: "Awards",
                newName: "IX_Awards_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressInfo_ProductId",
                table: "AddressInfos",
                newName: "IX_AddressInfos_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Awards",
                table: "Awards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressInfos",
                table: "AddressInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressInfos_Products_ProductId",
                table: "AddressInfos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Products_ProductId",
                table: "Awards",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressInfos_Products_ProductId",
                table: "AddressInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Products_ProductId",
                table: "Awards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Awards",
                table: "Awards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressInfos",
                table: "AddressInfos");

            migrationBuilder.RenameTable(
                name: "Awards",
                newName: "awards");

            migrationBuilder.RenameTable(
                name: "AddressInfos",
                newName: "AddressInfo");

            migrationBuilder.RenameIndex(
                name: "IX_Awards_ProductId",
                table: "awards",
                newName: "IX_awards_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressInfos_ProductId",
                table: "AddressInfo",
                newName: "IX_AddressInfo_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_awards",
                table: "awards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressInfo",
                table: "AddressInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressInfo_Products_ProductId",
                table: "AddressInfo",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_awards_Products_ProductId",
                table: "awards",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
