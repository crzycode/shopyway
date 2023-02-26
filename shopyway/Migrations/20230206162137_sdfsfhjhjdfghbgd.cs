using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopyway.Migrations
{
    public partial class sdfsfhjhjdfghbgd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Men_section",
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
                    table.PrimaryKey("PK_Men_section", x => x.Ajio_id);
                });

            migrationBuilder.CreateTable(
                name: "Women_section",
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
                    table.PrimaryKey("PK_Women_section", x => x.Ajio_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Men_section");

            migrationBuilder.DropTable(
                name: "Women_section");
        }
    }
}
