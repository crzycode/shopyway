using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopyway.Migrations
{
    public partial class sdfsfhjhjdfghbgdh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "products");

            migrationBuilder.DropColumn(
                name: "off_now",
                table: "products");

            migrationBuilder.DropColumn(
                name: "offer_price",
                table: "products");

            migrationBuilder.DropColumn(
                name: "original_price",
                table: "products");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "products");

            migrationBuilder.DropColumn(
                name: "total_rating",
                table: "products");

            migrationBuilder.DropColumn(
                name: "total_reviews",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "u_id",
                table: "products",
                newName: "File_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File_name",
                table: "products",
                newName: "u_id");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "off_now",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "offer_price",
                table: "products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "original_price",
                table: "products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "rating",
                table: "products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "total_rating",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "total_reviews",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
