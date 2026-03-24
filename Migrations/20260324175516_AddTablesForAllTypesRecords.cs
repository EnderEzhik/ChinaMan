using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChinaMan.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesForAllTypesRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.CreateTable(
                name: "AbandonedMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AbandonReason = table.Column<string>(type: "TEXT", nullable: false),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbandonedMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbandonedMovies_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewedMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ViewedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewedMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewedMovies_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WantToViewMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WantToViewMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WantToViewMovies_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchingMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchingMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchingMovies_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbandonedMovies_FilmId",
                table: "AbandonedMovies",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewedMovies_FilmId",
                table: "ViewedMovies",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_WantToViewMovies_FilmId",
                table: "WantToViewMovies",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchingMovies_FilmId",
                table: "WatchingMovies",
                column: "FilmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbandonedMovies");

            migrationBuilder.DropTable(
                name: "ViewedMovies");

            migrationBuilder.DropTable(
                name: "WantToViewMovies");

            migrationBuilder.DropTable(
                name: "WatchingMovies");

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    ViewedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Views_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Views_FilmId",
                table: "Views",
                column: "FilmId");
        }
    }
}
