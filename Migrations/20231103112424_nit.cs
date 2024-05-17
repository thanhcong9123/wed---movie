using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppFilm.Net.Migrations
{
    /// <inheritdoc />
    public partial class nit : Migration
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
                    NameGenre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameJob = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEPISODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Episodes = table.Column<int>(type: "int", nullable: false),
                    ImgEpisodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkMovie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMovieType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameNation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePeople = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceofBirth = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameSSVN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Part = table.Column<int>(type: "int", nullable: false),
                    Episodes = table.Column<int>(type: "int", nullable: false),
                    imgSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trailers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeopleConnJob",
                columns: table => new
                {
                    IdJob = table.Column<int>(type: "int", nullable: false),
                    IdPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleConnJob", x => new { x.IdJob, x.IdPeople });
                    table.ForeignKey(
                        name: "FK_PeopleConnJob_Job_IdJob",
                        column: x => x.IdJob,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleConnJob_People_IdPeople",
                        column: x => x.IdPeople,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeasonsConnLinkMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSeason = table.Column<int>(type: "int", nullable: false),
                    IdLinkMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonsConnLinkMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonsConnLinkMovie_LinkMovie_IdLinkMovie",
                        column: x => x.IdLinkMovie,
                        principalTable: "LinkMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonsConnLinkMovie_Season_IdSeason",
                        column: x => x.IdSeason,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeasonsConnPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSeason = table.Column<int>(type: "int", nullable: false),
                    IdPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonsConnPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonsConnPeople_People_IdPeople",
                        column: x => x.IdPeople,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonsConnPeople_Season_IdSeason",
                        column: x => x.IdSeason,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameVN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdYears = table.Column<int>(type: "int", nullable: false),
                    IdMovieType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_MovieType_IdMovieType",
                        column: x => x.IdMovieType,
                        principalTable: "MovieType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Years_IdYears",
                        column: x => x.IdYears,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreConnMovie",
                columns: table => new
                {
                    IdGenre = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreConnMovie", x => new { x.IdMovie, x.IdGenre });
                    table.ForeignKey(
                        name: "FK_GenreConnMovie_Genre_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreConnMovie_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemMovie_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NationConnMovie",
                columns: table => new
                {
                    IdNation = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationConnMovie", x => new { x.IdMovie, x.IdNation });
                    table.ForeignKey(
                        name: "FK_NationConnMovie_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NationConnMovie_Nation_IdNation",
                        column: x => x.IdNation,
                        principalTable: "Nation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleDirectorConnMovies",
                columns: table => new
                {
                    IdPeople = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleDirectorConnMovies", x => new { x.IdMovie, x.IdPeople });
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
                    IdPeople = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeoplePerformerConnMovies", x => new { x.IdMovie, x.IdPeople });
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

            migrationBuilder.CreateTable(
                name: "SeasonsConnMovie",
                columns: table => new
                {
                    IdSeason = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonsConnMovie", x => new { x.IdMovie, x.IdSeason });
                    table.ForeignKey(
                        name: "FK_SeasonsConnMovie_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonsConnMovie_Season_IdSeason",
                        column: x => x.IdSeason,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrailersConnMovie",
                columns: table => new
                {
                    IdTrailer = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailersConnMovie", x => new { x.IdMovie, x.IdTrailer });
                    table.ForeignKey(
                        name: "FK_TrailersConnMovie_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrailersConnMovie_Trailers_IdTrailer",
                        column: x => x.IdTrailer,
                        principalTable: "Trailers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewDay_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewMonth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewMonth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewMonth_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewWeek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewWeek_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreConnMovie_IdGenre",
                table: "GenreConnMovie",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMovie_IdMovie",
                table: "ItemMovie",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_IdMovieType",
                table: "Movie",
                column: "IdMovieType");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_IdYears",
                table: "Movie",
                column: "IdYears");

            migrationBuilder.CreateIndex(
                name: "IX_NationConnMovie_IdNation",
                table: "NationConnMovie",
                column: "IdNation");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleConnJob_IdPeople",
                table: "PeopleConnJob",
                column: "IdPeople");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleDirectorConnMovies_IdPeople",
                table: "PeopleDirectorConnMovies",
                column: "IdPeople");

            migrationBuilder.CreateIndex(
                name: "IX_PeoplePerformerConnMovies_IdPeople",
                table: "PeoplePerformerConnMovies",
                column: "IdPeople");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonsConnLinkMovie_IdLinkMovie",
                table: "SeasonsConnLinkMovie",
                column: "IdLinkMovie");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonsConnLinkMovie_IdSeason",
                table: "SeasonsConnLinkMovie",
                column: "IdSeason");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonsConnMovie_IdSeason",
                table: "SeasonsConnMovie",
                column: "IdSeason");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonsConnPeople_IdPeople",
                table: "SeasonsConnPeople",
                column: "IdPeople");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonsConnPeople_IdSeason",
                table: "SeasonsConnPeople",
                column: "IdSeason");

            migrationBuilder.CreateIndex(
                name: "IX_TrailersConnMovie_IdTrailer",
                table: "TrailersConnMovie",
                column: "IdTrailer");

            migrationBuilder.CreateIndex(
                name: "IX_ViewDay_IdMovie",
                table: "ViewDay",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_ViewMonth_IdMovie",
                table: "ViewMonth",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_ViewWeek_IdMovie",
                table: "ViewWeek",
                column: "IdMovie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreConnMovie");

            migrationBuilder.DropTable(
                name: "ItemMovie");

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
                name: "Genre");

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
                name: "MovieType");

            migrationBuilder.DropTable(
                name: "Years");
        }
    }
}
