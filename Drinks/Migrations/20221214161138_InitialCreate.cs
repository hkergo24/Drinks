using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drinks.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "IngredientIds", "Name" },
                values: new object[,]
                {
                    { 1, "[1,5]", "Expresso" },
                    { 2, "[1,5,5]", "Allongé" },
                    { 3, "[1,3,5,6]", "Capuccino" },
                    { 4, "[2,5,6,6,6,7,7]", "Chocolat" },
                    { 5, "[5,5,4]", "The" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { 1, 1.0, "Cafe" },
                    { 2, 0.10000000000000001, "Sucre" },
                    { 3, 0.5, "Creme" },
                    { 4, 2.0, "The" },
                    { 5, 0.20000000000000001, "Eau" },
                    { 6, 1.0, "Chocolat" },
                    { 7, 0.40000000000000002, "Lait" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
