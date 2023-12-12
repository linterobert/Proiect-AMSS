using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMOPS.Infrastructure.Migrations
{
    public partial class addconfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_UserID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Product_ProductID",
                table: "ProductImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserID",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Product_ProductID",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "ProductImage",
                newName: "ProductImages");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserID",
                table: "Reviews",
                newName: "IX_Reviews_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ProductID",
                table: "Reviews",
                newName: "IX_Reviews_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImage_ProductID",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_UserID",
                table: "Products",
                newName: "IX_Products_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ReviewID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "ProductImageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserID",
                table: "Products",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserID",
                table: "Reviews",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductID",
                table: "Reviews",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductID",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImage");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserID",
                table: "Review",
                newName: "IX_Review_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ProductID",
                table: "Review",
                newName: "IX_Review_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserID",
                table: "Product",
                newName: "IX_Product_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImage",
                newName: "IX_ProductImage_ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "ProductImage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ReviewID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage",
                column: "ProductImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_UserID",
                table: "Product",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Product_ProductID",
                table: "ProductImage",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserID",
                table: "Review",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Product_ProductID",
                table: "Review",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");
        }
    }
}
