using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.UniqueConstraint("AK_Genre_GenreName", x => x.GenreName);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediumName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medium", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: false),
                    MediumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_Label_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_Medium_MediumId",
                        column: x => x.MediumId,
                        principalTable: "Medium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 1, "Techno" },
                    { 2, "EDM" }
                });

            migrationBuilder.InsertData(
                table: "Label",
                columns: new[] { "Id", "Country", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Sweden", "drumcode@gmail.com", "Drumcode" },
                    { 2, "Sweden", "le7els@gmail.com", "LE7ELS" }
                });

            migrationBuilder.InsertData(
                table: "Medium",
                columns: new[] { "Id", "MediumName" },
                values: new object[,]
                {
                    { 1, "Vinyl" },
                    { 2, "CD" },
                    { 3, "Cassette tape" }
                });

            migrationBuilder.InsertData(
                table: "Producer",
                columns: new[] { "Id", "ArtistName", "Birthday", "Country", "Email", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Avicii", new DateTime(1989, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweden", "avicii@gmail.com", "Tim", "Bergling" },
                    { 2, "Sebastian Ingrosso", new DateTime(1983, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweden", "sebastianingrosso@gmail.com", "Sebastian", "Ingrosso" },
                    { 3, "Amelie Lens", new DateTime(1990, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belgium", "lens@gmail.com", "Amelie", "Lens" },
                    { 4, "Joris Voorn", new DateTime(1977, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands", "jorisvoorn@gmail.com", "Joris", "Voorn" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "City", "Country", "Email", "Lastname", "Name", "Password", "Role", "Telephone" },
                values: new object[,]
                {
                    { 1, "Adresa 1", "Novi Sad", "Serbia", "has@gmail.com", "Has", "Vitomir", "vitapuska", "User", "555333" },
                    { 2, "Moja adresa 359", "Belgrade", "Serbia", "admin@admin.com", "Danilovic", "Marko", "admin", "Admin", "553265" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "Id", "Address", "City", "Comment", "OrderDate", "Payment", "PaymentMethod", "Subtotal", "UserId" },
                values: new object[] { 1, "Bulevar umetnosti 16a", "Beograd", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", 14.52m, 1 });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "Id", "Duration", "GenreId", "LabelId", "MediumId", "PictureUrl", "Price", "ProducerId", "PublishDate", "Quantity", "TrackName" },
                values: new object[,]
                {
                    { 1, 8.23m, 1, 1, 1, "picture", 14.99m, 3, new DateTime(2018, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, "Your Mind" },
                    { 2, 4.29m, 2, 2, 2, "picture", 14.99m, 1, new DateTime(2011, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Levels" },
                    { 3, 6.57m, 1, 1, 3, "picture", 14.99m, 4, new DateTime(2012, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Goodbye fly" },
                    { 4, 3.23m, 2, 2, 2, "picture", 14.99m, 2, new DateTime(2017, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "More than you know" }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "CartId", "Quantity", "TrackId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_TrackId",
                table: "CartItem",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_GenreId",
                table: "Track",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_LabelId",
                table: "Track",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_MediumId",
                table: "Track",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_ProducerId",
                table: "Track",
                column: "ProducerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Medium");

            migrationBuilder.DropTable(
                name: "Producer");
        }
    }
}
