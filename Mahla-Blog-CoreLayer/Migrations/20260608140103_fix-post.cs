using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahla_Blog_DataLayer.Migrations
{
    public partial class fixpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Posts",
                type: "int",
                maxLength: 300,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubCategoryId",
                table: "Posts",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_SubCategoryId",
                table: "Posts",
                column: "SubCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_SubCategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SubCategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
