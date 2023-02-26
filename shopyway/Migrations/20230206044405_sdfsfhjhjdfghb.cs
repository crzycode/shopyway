using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopyway.Migrations
{
    public partial class sdfsfhjhjdfghb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ajiomen",
                columns: table => new
                {
                    Ajio_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ajiomen", x => x.Ajio_id);
                });

            migrationBuilder.CreateTable(
                name: "Ajiowomen",
                columns: table => new
                {
                    Ajio_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ajiowomen", x => x.Ajio_id);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    City_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostOfficeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.City_id);
                });

            migrationBuilder.CreateTable(
                name: "elec_category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elec_category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "fashion_Categories",
                columns: table => new
                {
                    fashion_cat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fashion_Categories", x => x.fashion_cat_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    u_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    offer_price = table.Column<double>(type: "float", nullable: false),
                    original_price = table.Column<double>(type: "float", nullable: false),
                    off_now = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_rating = table.Column<int>(type: "int", nullable: false),
                    total_reviews = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Product_id);
                });

            migrationBuilder.CreateTable(
                name: "top_clothes",
                columns: table => new
                {
                    Ajio_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_top_clothes", x => x.Ajio_id);
                });

            migrationBuilder.CreateTable(
                name: "topdeals",
                columns: table => new
                {
                    Deal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deal_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topdeals", x => x.Deal_id);
                });

            migrationBuilder.CreateTable(
                name: "topElec",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    u_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    offer_price = table.Column<double>(type: "float", nullable: false),
                    original_price = table.Column<double>(type: "float", nullable: false),
                    off_now = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_rating = table.Column<int>(type: "int", nullable: false),
                    total_reviews = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topElec", x => x.Product_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Mobilenumber = table.Column<long>(type: "bigint", nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Pincode = table.Column<int>(type: "int", nullable: false),
                    User_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Sinceactive = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.User_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ajiomen");

            migrationBuilder.DropTable(
                name: "Ajiowomen");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "elec_category");

            migrationBuilder.DropTable(
                name: "fashion_Categories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "top_clothes");

            migrationBuilder.DropTable(
                name: "topdeals");

            migrationBuilder.DropTable(
                name: "topElec");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
