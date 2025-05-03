using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookoria.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "John Doe", "A complete guide to ASP.NET Core.", "1234567890", 50.0, 45.0, 35.0, 40.0, "ASP.NET Core Guide" },
                    { 2, "Jane Smith", "Master Linq with examples.", "0987654321", 60.0, 55.0, 45.0, 50.0, "Linq Mastery" },
                    { 3, "Jane Smith", "Master Linq with examples.", "0987654321", 60.0, 55.0, 45.0, 50.0, "mvc" },
                    { 4, "Jane Smith", "LINQ with examples.", "0987654321", 60.0, 55.0, 45.0, 50.0, "Linq Mastery" },
                    { 5, "Jane Smith", "Master Entity Framework with examples.", "0987654321", 60.0, 55.0, 45.0, 50.0, "Entity Framework Mastery" },
                    { 6, "Jane Smith", "Master Entity Framework with examples.", "0987654321", 60.0, 55.0, 45.0, 50.0, "Entity Framework Mastery" },
                    { 7, "Jane Smith", "Master Entity Framework with examples.", "0987654321", 60.0, 55.0, 45.0, 50.0, "Entity Framework Mastery" },
                    { 8, "Jane Smith", "Master Entity Framework with examples.", "0987654321", 60.0, 55.0, 45.0, 50.0, "Entity Framework Mastery" },
                    { 9, "Jane Smith", "Master Entity Framework with examples.", "0987654321", 60.0, 55.0, 45.0, 50.0, "Entity Framework Mastery" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
