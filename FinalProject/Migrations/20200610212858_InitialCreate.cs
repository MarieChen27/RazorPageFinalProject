using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumID);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtistName = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    AlbumsAlbumID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistID);
                    table.ForeignKey(
                        name: "FK_Artists_Albums_AlbumsAlbumID",
                        column: x => x.AlbumsAlbumID,
                        principalTable: "Albums",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SongName = table.Column<string>(nullable: true),
                    SongLength = table.Column<TimeSpan>(nullable: false),
                    AlbumID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongID);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Albums",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_AlbumsAlbumID",
                table: "Artists",
                column: "AlbumsAlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs",
                column: "AlbumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
