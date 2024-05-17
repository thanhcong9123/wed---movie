using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppFilm.Net.Migrations
{
    /// <inheritdoc />
    public partial class InitPeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "PeopleDirectorConnMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPeople = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleDirectorConnMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleDirectorConnMovies_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleDirectorConnMovies_People_IdPeople",
                        column: x => x.IdPeople,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeoplePerformerConnMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPeople = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeoplePerformerConnMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeoplePerformerConnMovies_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeoplePerformerConnMovies_People_IdPeople",
                        column: x => x.IdPeople,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

     

            migrationBuilder.CreateIndex(
                name: "IX_PeopleDirectorConnMovies_IdMovie",
                table: "PeopleDirectorConnMovies",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleDirectorConnMovies_IdPeople",
                table: "PeopleDirectorConnMovies",
                column: "IdPeople");

            migrationBuilder.CreateIndex(
                name: "IX_PeoplePerformerConnMovies_IdMovie",
                table: "PeoplePerformerConnMovies",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_PeoplePerformerConnMovies_IdPeople",
                table: "PeoplePerformerConnMovies",
                column: "IdPeople");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreConnMovie");

            migrationBuilder.DropTable(
                name: "ItemMovie");

            migrationBuilder.DropTable(
                name: "MovieTypeConnMovie");

            migrationBuilder.DropTable(
                name: "NationConnMovie");

            migrationBuilder.DropTable(
                name: "PeopleConnJob");

            migrationBuilder.DropTable(
                name: "PeopleDirectorConnMovies");

            migrationBuilder.DropTable(
                name: "PeoplePerformerConnMovies");

            migrationBuilder.DropTable(
                name: "SeasonsConnLinkMovie");

            migrationBuilder.DropTable(
                name: "SeasonsConnMovie");

            migrationBuilder.DropTable(
                name: "SeasonsConnPeople");

            migrationBuilder.DropTable(
                name: "TrailersConnMovie");

            migrationBuilder.DropTable(
                name: "ViewDay");

            migrationBuilder.DropTable(
                name: "ViewMonth");

            migrationBuilder.DropTable(
                name: "ViewWeek");

            migrationBuilder.DropTable(
                name: "YearsConnMovie");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "MovieType");

            migrationBuilder.DropTable(
                name: "Nation");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "LinkMovie");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Trailers");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Years");
        }
    }
}
