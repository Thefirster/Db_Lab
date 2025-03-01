using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class init0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "singers",
                columns: table => new
                {
                    SingerID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Nationality = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DebutDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_singers", x => x.SingerID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    AlbumID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Profile = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SingerID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_albums_singers_SingerID",
                        column: x => x.SingerID,
                        principalTable: "singers",
                        principalColumn: "SingerID");
                });

            migrationBuilder.CreateTable(
                name: "songTables",
                columns: table => new
                {
                    SongTableID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Profile = table.Column<string>(type: "TEXT", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsPublic = table.Column<string>(type: "TEXT", nullable: false),
                    UserID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songTables", x => x.SongTableID);
                    table.ForeignKey(
                        name: "FK_songTables_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "musiccs",
                columns: table => new
                {
                    MusicID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Style = table.Column<string>(type: "TEXT", nullable: false),
                    Lyricist = table.Column<string>(type: "TEXT", nullable: false),
                    Composer = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AlbumID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musiccs", x => x.MusicID);
                    table.ForeignKey(
                        name: "FK_musiccs_albums_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "albums",
                        principalColumn: "AlbumID");
                });

            migrationBuilder.CreateTable(
                name: "songs",
                columns: table => new
                {
                    SongID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MusicID = table.Column<Guid>(type: "TEXT", nullable: true),
                    SongTableID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songs", x => x.SongID);
                    table.ForeignKey(
                        name: "FK_songs_musiccs_MusicID",
                        column: x => x.MusicID,
                        principalTable: "musiccs",
                        principalColumn: "MusicID");
                    table.ForeignKey(
                        name: "FK_songs_songTables_SongTableID",
                        column: x => x.SongTableID,
                        principalTable: "songTables",
                        principalColumn: "SongTableID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_albums_AlbumID",
                table: "albums",
                column: "AlbumID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_albums_SingerID",
                table: "albums",
                column: "SingerID");

            migrationBuilder.CreateIndex(
                name: "IX_musiccs_AlbumID",
                table: "musiccs",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_musiccs_MusicID",
                table: "musiccs",
                column: "MusicID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_singers_SingerID",
                table: "singers",
                column: "SingerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_songs_MusicID",
                table: "songs",
                column: "MusicID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_songs_SongID",
                table: "songs",
                column: "SongID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_songs_SongTableID",
                table: "songs",
                column: "SongTableID");

            migrationBuilder.CreateIndex(
                name: "IX_songTables_SongTableID",
                table: "songTables",
                column: "SongTableID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_songTables_UserID",
                table: "songTables",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserID",
                table: "users",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "songs");

            migrationBuilder.DropTable(
                name: "musiccs");

            migrationBuilder.DropTable(
                name: "songTables");

            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "singers");
        }
    }
}
