using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopyway.Migrations
{
    public partial class sdfsfhjhjdfghbgdhd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Electronic_products",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electronic_products", x => x.Product_id);
                });

            migrationBuilder.CreateTable(
                name: "Electronics_product_category",
                columns: table => new
                {
                    El_Category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electronics_product_category", x => x.El_Category_id);
                });

            migrationBuilder.CreateTable(
                name: "Mobile_accessory_category",
                columns: table => new
                {
                    El_Category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile_accessory_category", x => x.El_Category_id);
                });

            migrationBuilder.CreateTable(
                name: "Mobile_accessory_product",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile_accessory_product", x => x.Product_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Electronic_products");

            migrationBuilder.DropTable(
                name: "Electronics_product_category");

            migrationBuilder.DropTable(
                name: "Mobile_accessory_category");

            migrationBuilder.DropTable(
                name: "Mobile_accessory_product");
        }
    }
}
