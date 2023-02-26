using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopyway.Migrations
{
    public partial class dfsafbgghjghj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File_name",
                table: "Mobile_accessory_product",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "File_name",
                table: "Mobile_accessory_category",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "File_name",
                table: "Electronic_products",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Mobile_accessory_product",
                newName: "File_name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Mobile_accessory_category",
                newName: "File_name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Electronic_products",
                newName: "File_name");
        }
    }
}
