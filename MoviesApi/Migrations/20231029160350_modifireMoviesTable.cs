using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApi.Migrations
{
    public partial class modifireMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenreId1",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_GenreId1",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "movies");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateIndex(
                name: "IX_movies_GenreId",
                table: "movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_GenreId",
                table: "movies");

            migrationBuilder.AlterColumn<byte>(
                name: "GenreId",
                table: "movies",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GenreId1",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_movies_GenreId1",
                table: "movies",
                column: "GenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenreId1",
                table: "movies",
                column: "GenreId1",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
