using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Learning.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addeddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    CategId = table.Column<int>(type: "int", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_categs_CategId",
                        column: x => x.CategId,
                        principalTable: "categs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "asxsa", "saxx " },
                    { 2, "asdc dx c ", "sdaew" },
                    { 3, "asdc dx c ", "sdaew" },
                    { 4, "asdc dx c ", "sdaew" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategId", "Description", "ListPrice", "Title", "imageUrl" },
                values: new object[] { 1, 2, "Hi", 90.0, "Hi", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategId",
                table: "Products",
                column: "CategId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "categs");
        }
    }
}
