using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMusicApp.Migrations
{
    public partial class Addedrelationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumID",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Song_AlbumID",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Album_ArtistId",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "AlbumID",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Album");

            migrationBuilder.AddColumn<int>(
                name: "AlbumsId",
                table: "Song",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtistsId",
                table: "Album",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Song_AlbumsId",
                table: "Song",
                column: "AlbumsId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistsId",
                table: "Album",
                column: "ArtistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistsId",
                table: "Album",
                column: "ArtistsId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumsId",
                table: "Song",
                column: "AlbumsId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistsId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumsId",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Song_AlbumsId",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Album_ArtistsId",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "AlbumsId",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "ArtistsId",
                table: "Album");

            migrationBuilder.AddColumn<int>(
                name: "AlbumID",
                table: "Song",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Album",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Song_AlbumID",
                table: "Song",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumID",
                table: "Song",
                column: "AlbumID",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
