using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Refah.EntityFrameworkCore.Migrations
{
    public partial class Add_ProductConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductType_CategoryRef",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "*******",
                newSchema: "Production");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "Production",
                table: "*******",
                newName: "====");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Production",
                table: "*******",
                newName: "Pi");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryRef",
                schema: "Production",
                table: "*******",
                newName: "IX_*******_CategoryRef");

            migrationBuilder.AlterColumn<string>(
                name: "====",
                schema: "Production",
                table: "*******",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_*******",
                schema: "Production",
                table: "*******",
                column: "Pi");

            migrationBuilder.AddForeignKey(
                name: "FK_*******_ProductType_CategoryRef",
                schema: "Production",
                table: "*******",
                column: "CategoryRef",
                principalSchema: "Production",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_*******_ProductType_CategoryRef",
                schema: "Production",
                table: "*******");

            migrationBuilder.DropPrimaryKey(
                name: "PK_*******",
                schema: "Production",
                table: "*******");

            migrationBuilder.RenameTable(
                name: "*******",
                schema: "Production",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "====",
                table: "Products",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Pi",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_*******_CategoryRef",
                table: "Products",
                newName: "IX_Products_CategoryRef");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductType_CategoryRef",
                table: "Products",
                column: "CategoryRef",
                principalSchema: "Production",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
