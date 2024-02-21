using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAndCategoryWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayedOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
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
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "DisplayedOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "SciFi" },
                    { 3, 3, "History" },
                    { 4, 4, "Classical Literature" },
                    { 5, 5, "Programming" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Leo Tolstoy", 1, "A novel by Leo Tolstoy", "ISBN1", 200.0, 180.0, 160.0, 170.0, "Anna Karenina" },
                    { 2, "Gustave Flaubert", 2, "A novel by Gustave Flaubert", "ISBN2", 150.0, 140.0, 120.0, 130.0, "Madame Bovary" },
                    { 3, "Leo Tolstoy", 1, "A novel by Leo Tolstoy", "ISBN3", 300.0, 280.0, 260.0, 270.0, "War and Peace" },
                    { 4, "F. Scott Fitzgerald", 2, "A novel by F. Scott Fitzgerald", "ISBN4", 120.0, 110.0, 90.0, 100.0, "The Great Gatsby" },
                    { 5, "Vladimir Nabokov", 2, "A novel by Vladimir Nabokov", "ISBN5", 210.0, 200.0, 180.0, 190.0, "Lolita" },
                    { 6, "George Eliot", 3, "A novel by George Eliot", "ISBN6", 220.0, 210.0, 190.0, 200.0, "Middlemarch" },
                    { 7, "George Orwell", 2, "A novel by George Orwell", "ISBN7", 230.0, 220.0, 200.0, 210.0, "1984" },
                    { 8, "J.R.R. Tolkien", 1, "A novel by J.R.R. Tolkien", "ISBN8", 240.0, 230.0, 210.0, 220.0, "The Lord of the Rings" },
                    { 9, "Khaled Hosseini", 4, "A novel by Khaled Hosseini", "ISBN9", 250.0, 240.0, 220.0, 230.0, "The Kite Runner" },
                    { 10, "J.K. Rowling", 2, "A novel by J.K. Rowling", "ISBN10", 260.0, 250.0, 230.0, 240.0, "Harry Potter and the Philosopher's Stone" },
                    { 11, "Robert C. Martin", 5, "A book by Robert C. Martin", "ISBN16", 350.0, 340.0, 320.0, 330.0, "Clean Code: A Handbook of Agile Software Craftsmanship" },
                    { 12, "Frederick P. Brooks Jr.", 5, "A book by Frederick P. Brooks Jr.", "ISBN17", 360.0, 350.0, 330.0, 340.0, "The Mythical Man-Month: Essays on Software Engineering" },
                    { 13, "Andrew Hunt and David Thomas", 5, "A book by Andrew Hunt and David Thomas", "ISBN18", 370.0, 360.0, 340.0, 350.0, "The Pragmatic Programmer: Your Journey to Mastery" },
                    { 14, "Eric Matthes", 5, "A book by Eric Matthes", "ISBN19", 380.0, 370.0, 350.0, 360.0, "Python Crash Course: A Hands-On, Project-Based Introduction to Programming" },
                    { 15, "Jon Stokes", 5, "A book by Jon Stokes", "ISBN20", 390.0, 380.0, 360.0, 370.0, "Inside the Machine: An Illustrated Introduction to Microprocessors and Computer Architecture" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
