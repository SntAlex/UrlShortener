using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AlexGolikov.UrlShortener.Data.DB.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OriginalUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginalUrls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShortUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    OriginalUrlId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortUrls_OriginalUrls_OriginalUrlId",
                        column: x => x.OriginalUrlId,
                        principalTable: "OriginalUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OriginalUrls_Url",
                table: "OriginalUrls",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_OriginalUrlId",
                table: "ShortUrls",
                column: "OriginalUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_Url",
                table: "ShortUrls",
                column: "Url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortUrls");

            migrationBuilder.DropTable(
                name: "OriginalUrls");
        }
    }
}
